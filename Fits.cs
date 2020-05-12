using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using nom.tam.fits;
using nom.tam.util;


namespace SunMagnetogramAnalyzer
{
    public enum BitPix { Bits8, Bits16, Bits32, Unknown }
    public class FitsWrapper
    {
        private Fits fits = null;
        private BasicHDU[] hdus = null;

        /// <summary>
        /// Определение кол-ва HDU-блоков в файле
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="hduNum">кол-во HDU-блоков</param>
        public void OpenFile(string fileName, out int hduNum)
        {
            fits = new Fits(fileName, FileAccess.Read);
            hduNum = fits.Size();
        }
        /// <summary>
        /// Считывание заголовка HDU-блока
        /// </summary>
        /// <param name="file">имя файла</param>
        /// <param name="index">порядковый номер HDU-блока</param>
        /// <param name="table">список параметров из заголовка HDU-блока</param>
        /// <param name="hasImage">наличие изображения после заголовка</param>
        /// <returns></returns>
        public bool ReadHeader(string file, int index, out List<string[]> table, out bool hasImage)
        {
            fits = new Fits(file, FileAccess.Read);
            hdus = fits.Read();

            if (hdus == null) 
            { 
                table = null; 
                hasImage = false; 
            }
            // Построчное считывание и сохранение параметров из заголовка: ключевое слово-значение-комментарий
            // сохранение в список table
            table = new List<string[]> { };
            var hdr = hdus[index].Header;

            for (int j = 0; j < hdr.NumberOfCards; j++)
            {
                var hc = new HeaderCard(hdr.GetCard(j));
                var sa = new string[3] { hc.Key, hc.Value, hc.Comment };
                table.Add(sa);
            }

            // Кол-во осей в data unit
            int naxis = 0;
            if (hdr.ContainsKey("SIMPLE"))
            {
                // Для первого HDU
                if (hdr.ContainsKey("NAXIS"))
                    naxis = hdr.GetIntValue("NAXIS");
                
            }
            else if (hdr.ContainsKey("XTENSION"))
            {
                // Для остальных HDU-расширений
                if (hdr.ContainsKey("ZNAXIS"))
                    naxis = hdr.GetIntValue("ZNAXIS");
            }
            hasImage = (naxis == 2);
            return (table.Count != 0);
        }
        /// <summary>
        /// Считывание данных HDU-блока
        /// </summary>
        /// <param name="index">порядковый номер HDU-блока</param>
        /// <param name="data">данные изображения</param>
        /// <param name="bitpix">значение BITPIX</param>
        public void ReadData(int index, out Array[] data, out BitPix bitpix)
        {
            int bits = hdus[index].BitPix;
            switch (bits)
            {
                case 8:  
                    bitpix = BitPix.Bits8; 
                    break;
                case 16:
                    bitpix = BitPix.Bits16; 
                    break;
                case 32: 
                    bitpix = BitPix.Bits32; 
                    break;
                default: 
                    bitpix = BitPix.Unknown; 
                    break;
            }
            if (bitpix != BitPix.Unknown)
            {
                data = (Array[])hdus[index].Kernel;
            }
            else
            {
                data = null;
            }
        }

        /// <summary>
        /// Закрытие FITS-файла
        /// </summary>
        public void Free()
        {
            if (fits != null) 
                fits.Close();
        }
        /// <summary>
        /// Определение минамальных и максимальных значений блока данных и дат для рассчета среднего значения силы
        /// (также для последовательности HDU-блоков в одном FITS-файле)
        /// </summary>
        /// <param name="file">имя файла</param>
        /// <param name="minVal">минимальное значение</param>
        /// <param name="maxVal">максимальное значение</param>
        /// <param name="minDateTime">самая ранняя дата записи</param>
        /// <param name="maxDateTime">самая поздняя дата записи</param>
        public void GetValueSpan(string file, out double minVal, out double maxVal, out DateTime minDateTime, out DateTime maxDateTime)
        {
            fits = new Fits(file, FileAccess.Read);
            hdus = fits.Read();

            minVal = double.MaxValue;
            maxVal = double.MinValue;
            minDateTime = DateTime.MaxValue;
            maxDateTime = DateTime.MinValue;
            if (hdus == null) 
                return;

            int naxis = 0;
            for (int i = 0; i < hdus.Length; i++)
            {
                var hdr = hdus[i].Header;
                if (!hdr.ContainsKey("SIMPLE")) 
                    break;

                // Определение границ для дат наблюдения
                minDateTime = DateTime.MaxValue;
                maxDateTime = DateTime.MinValue;

                if (!hdr.ContainsKey("DATE-OBS")) 
                    break;
                DateTime dateTime;
                if (!DateTime.TryParse(hdr.GetStringValue("DATE-OBS"), out dateTime))
                    break;
                if (dateTime < minDateTime) 
                    minDateTime = dateTime;
                if (dateTime > maxDateTime) 
                    maxDateTime = dateTime;

                // Определение границ значений в массиве данных(data-unit)
                if (hdr.ContainsKey("NAXIS"))
                    naxis = hdr.GetIntValue("NAXIS");
                if (naxis != 2) 
                    break;

                int bits = hdus[i].BitPix;
                BitPix bitpix = BitPix.Unknown;

                switch (bits)
                {
                    case 8: 
                        bitpix = BitPix.Bits8; 
                        break;
                    case 16: 
                        bitpix = BitPix.Bits16; 
                        break;
                    case 32: 
                        bitpix = BitPix.Bits32; 
                        break;
                    default: 
                        bitpix = BitPix.Unknown; 
                        break;
                }
                Array[] data;
                if (bitpix != BitPix.Unknown)
                    data = (Array[])hdus[i].Kernel;
                else
                    break;

                int width = data[0].GetLength(0);
                int height = data.GetLength(0);

                if (!hdr.ContainsKey("BSCALE") ||
                    !hdr.ContainsKey("BZERO"))
                    break;
                var bscale = hdus[i].BScale;
                var bzero = hdus[i].BZero;

                var minValue = Int32.MaxValue;
                var maxValue = Int32.MinValue;

                // Определение значения для прозрачного фона для разных типов данных.
                Int32 trnValue = 0;
                if (bitpix == BitPix.Bits8) 
                    trnValue = byte.MinValue;
                else if (bitpix == BitPix.Bits16) 
                    trnValue = Int16.MinValue;
                else if (bitpix == BitPix.Bits32) 
                    trnValue = Int32.MinValue;

                // Определений максимума и минимума значений в массиве данных(data-unit)
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        Int32 value = 0;
                        if (bitpix == BitPix.Bits8) 
                            value = ((byte[])data[y])[x];
                        else if (bitpix == BitPix.Bits16) 
                            value = ((Int16[])data[y])[x];
                        else if (bitpix == BitPix.Bits32) 
                            value = ((Int32[])data[y])[x];
                        if (value > maxValue) 
                            maxValue = value;
                        if ((value < minValue) && (value != trnValue)) 
                            minValue = value;
                    }
                // Перевод значений максимального и минимального значений в физическую велечину
                double crtMinVal = bscale * minValue + bzero;
                double crtMaxVal = bscale * maxValue + bzero;
                if (crtMinVal < minVal) 
                    minVal = crtMinVal;
                if (crtMaxVal > maxVal) 
                    maxVal = crtMaxVal;
            }
        }

        /// <summary>
        /// Создание списка пар: дата - среднее значение магнитного поля в заданном диапазоне
        /// (также для последовательности HDU-блоков в одном FITS-файле)
        /// </summary>
        /// <param name="file">имя файла</param>
        /// <param name="min">минимальное значение</param>
        /// <param name="max">максимальное значение</param>
        /// <param name="points">пара дата-сред.значение</param>
        public void CalcDependencyForce(string file, double min, double max, out List<DateValue> points)
        {
            fits = new Fits(file, FileAccess.Read);
            hdus = fits.Read();

            points = new List<DateValue> { };
            if (hdus == null) 
                return;

            int naxis = 0;
            for (int i = 0; i < hdus.Length; i++)
            {
                DateTime dateTime;
                double sum = 0.0;

                var hdr = hdus[i].Header;
                if (!hdr.ContainsKey("SIMPLE")) 
                    break;
                if (hdr.ContainsKey("NAXIS"))
                    naxis = hdr.GetIntValue("NAXIS");
                if (naxis != 2) 
                    break;
                if (!hdr.ContainsKey("DATE-OBS")) 
                    break;
                if (!DateTime.TryParse(hdr.GetStringValue("DATE-OBS"), out dateTime))
                    break;

                int bits = hdus[i].BitPix;
                BitPix bitpix = BitPix.Unknown;

                switch (bits)
                {
                    case 8: 
                        bitpix = BitPix.Bits8; 
                        break;
                    case 16: 
                        bitpix = BitPix.Bits16; 
                        break;
                    case 32: 
                        bitpix = BitPix.Bits32; 
                        break;
                    default: 
                        bitpix = BitPix.Unknown; 
                        break;
                }
                Array[] data;
                if (bitpix != BitPix.Unknown)
                    data = (Array[])hdus[i].Kernel;
                else
                    break;

                int width = data[0].GetLength(0);
                int height = data.GetLength(0);

                if (!hdr.ContainsKey("BSCALE") || !hdr.ContainsKey("BZERO"))
                    break;
                var bscale = hdus[i].BScale;
                var bzero = hdus[i].BZero;

                // Определение значения для прозрачного фона
                Int32 trnValue = 0;
                if (bitpix == BitPix.Bits8) 
                    trnValue = byte.MinValue;
                else if (bitpix == BitPix.Bits16) 
                    trnValue = Int16.MinValue;
                else if (bitpix == BitPix.Bits32) 
                    trnValue = Int32.MinValue;

                // Расчет среднего значения значения в заданном диапазоне
                int pointCount = 0;
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        Int32 value = 0;
                        if (bitpix == BitPix.Bits8) 
                            value = ((byte[])data[y])[x];
                        else if (bitpix == BitPix.Bits16) 
                            value = ((Int16[])data[y])[x];
                        else if (bitpix == BitPix.Bits32) 
                            value = ((Int32[])data[y])[x];

                        if (value != trnValue)
                        {
                            double ampl = bscale * value + bzero;
                            if ((ampl > min) && (ampl < max))
                            {
                                sum += ampl;
                                pointCount++;
                            }
                        }
                    }

                if (pointCount != 0)
                    points.Add(new DateValue(dateTime, sum / pointCount));
            }
        }
        /// <summary>
        /// Создание списка пар: дата - среднее абсолютное значение магнитного потока в заданном диапазоне
        /// (также для последовательности HDU-блоков в одном FITS-файле)
        /// </summary>
        /// <param name="file">имя файла</param>
        /// <param name="min">минимальное значение</param>
        /// <param name="max">максимальное значение</param>
        /// <param name="points">пара типа</param>
        public void CalcDependencyAbsForce(string file, double min, double max, out List<DateValue> points)
        {
            fits = new Fits(file, FileAccess.Read);
            hdus = fits.Read();

            points = new List<DateValue> { };
            if (hdus == null)
                return;

            int naxis = 0;
            for (int i = 0; i < hdus.Length; i++)
            {
                DateTime dateTime;
                double sum = 0.0;

                var hdr = hdus[i].Header;
                if (!hdr.ContainsKey("SIMPLE"))
                    break;
                if (hdr.ContainsKey("NAXIS"))
                    naxis = hdr.GetIntValue("NAXIS");
                if (naxis != 2)
                    break;
                if (!hdr.ContainsKey("DATE-OBS"))
                    break;
                if (!DateTime.TryParse(hdr.GetStringValue("DATE-OBS"), out dateTime))
                    break;

                int bits = hdus[i].BitPix;
                BitPix bitpix = BitPix.Unknown;

                switch (bits)
                {
                    case 8:
                        bitpix = BitPix.Bits8;
                        break;
                    case 16:
                        bitpix = BitPix.Bits16;
                        break;
                    case 32:
                        bitpix = BitPix.Bits32;
                        break;
                    default:
                        bitpix = BitPix.Unknown;
                        break;
                }
                Array[] data;
                if (bitpix != BitPix.Unknown)
                    data = (Array[])hdus[i].Kernel;
                else
                    break;

                int width = data[0].GetLength(0);
                int height = data.GetLength(0);

                if (!hdr.ContainsKey("BSCALE") || !hdr.ContainsKey("BZERO"))
                    break;
                var bscale = hdus[i].BScale;
                var bzero = hdus[i].BZero;

                // Определение значения для прозрачного фона
                Int32 trnValue = 0;
                if (bitpix == BitPix.Bits8)
                    trnValue = byte.MinValue;
                else if (bitpix == BitPix.Bits16)
                    trnValue = Int16.MinValue;
                else if (bitpix == BitPix.Bits32)
                    trnValue = Int32.MinValue;

                // Расчет среднего значения магнитного потока в заданном диапазоне
                int pointCount = 0;
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        Int32 value = 0;
                        if (bitpix == BitPix.Bits8)
                            value = ((byte[])data[y])[x];
                        else if (bitpix == BitPix.Bits16)
                            value = ((Int16[])data[y])[x];
                        else if (bitpix == BitPix.Bits32)
                            value = ((Int32[])data[y])[x];

                        if (value != trnValue)
                        {
                            double ampl = bscale * value + bzero;
                            if ((ampl > min) && (ampl < max))
                            {
                                if (ampl > 0)
                                    sum += ampl;
                                else
                                    sum += ampl*(-1.0);
                            }
                            pointCount++;
                        }
                    }

                if (pointCount != 0)
                    points.Add(new DateValue(dateTime, sum / pointCount));
            }
        }
    }

    public struct DateValue
    {
        public DateTime Date;
        public double Value;

        public DateValue(DateTime date, double value)
        {
            this.Date = date;
            this.Value = value;
        }
    }
}