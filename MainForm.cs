using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using nom.tam.fits;
using System.Drawing.Imaging;
using System.Globalization;


namespace SunMagnetogramAnalyzer

{
    enum ControlsState { Off = 0, SingleOn = 1, MultipleOn = 2 }

    struct UnitMap
    {
        public int FileIndex;
        public int HDUIndex;

        public UnitMap(int fileIndex, int hduIndex)
        {
            FileIndex = fileIndex;
            HDUIndex = hduIndex;
        }
    }

    public partial class MainForm : Form
    {
        private List<ToolStripItem> singleSwitchableControls;
        private List<ToolStripItem> multipleSwitchableControls;
        
        private FitsWrapper fits = new FitsWrapper();
        private string[] files;
        private List<UnitMap> unitsList;
        private int crtUnitIndex = 0;
        private int hduNumber = 0;

        public MainForm()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            singleSwitchableControls = new List<ToolStripItem>
            {
                viewToolStripMenuItem
            };
            multipleSwitchableControls = new List<ToolStripItem>
            {
                previousToolStripMenuItem, nextToolStripMenuItem, actionToolStripMenuItem, calcToolStripMenuItem, calcToolStripMenuItem2,
                toolStripPreviousButton, toolStripNumberComboBox, toolStripNextButton
            };
            this.Text = $"{Application.ProductName}";
        }

        // Открыте файла(-ов)
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                toolStripStatusLabel.Text = "Выбор файла";

                // Создание рабочей директории

                string crtDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                try
                {
                    if (!Directory.Exists("fits"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory("fits");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Не удалось создать рабочую директорию \".\\fits\":\n" +
                        $"{ex.Message}",
                        "Ошибка создания рабочей директории",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Вызов диалогового окна открытия файла

                openFileDialog.Title = "Открыть FITS-файл";
                // Возможные варианты начальной папки в диалоговом окне
                // openFileDialog.InitialDirectory = "c:\\"; // Диск C:
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Рабочий стол
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Мои Документы
                openFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"; // Мой компьютер
                openFileDialog.Filter = "FITS-файлы (*.fits)|*.fits|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.CheckFileExists = true;

                var openResult = openFileDialog.ShowDialog();
                if (openResult != DialogResult.OK)
                {
                    toolStripStatusLabel.Text = "Выберите файл для анализа";
                    if (openResult != DialogResult.Cancel)
                        MessageBox.Show(
                            $"Неправильно выбран(ы) файл(ы) \"{files}\"",
                            "Ошибка открытия файла(ов)",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }

                files = new string[openFileDialog.FileNames.Length];
                unitsList = new List<UnitMap> { };
                hduNumber = 0;
                int i = 0;

                // Открытие файлов

                toolStripStatusLabel.Text = "Открытие файла(ов)";
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = true;
                toolStripProgressLabel.Text = "0 %";
                toolStripProgressLabel.Visible = true;
                
                foreach (string file in openFileDialog.FileNames)
                {
                    string workFile = crtDir + "\\fits\\" + Path.GetFileName(file);
                    try
                    {
                        if (File.Exists(workFile))
                        {
                            File.Delete(workFile);
                        }
                        File.Copy(file, workFile, true);

                        // Подключение funpack.exe для распаковки сжатых FITS-файлов
                        using (Process funpackProcess = new Process())
                        {
                            funpackProcess.StartInfo.UseShellExecute = false;
                            funpackProcess.StartInfo.FileName = ".\\Funpack.exe";
                            funpackProcess.StartInfo.Arguments = $"-F .\\fits\\{Path.GetFileName(workFile)}";
                            funpackProcess.StartInfo.CreateNoWindow = true;
                            funpackProcess.Start();
                            funpackProcess.WaitForExit();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Не удалось копировать рабочий файл \"{workFile}\" :\n" +
                            $"{ex.Message}",
                            "Ошибка создания рабочей копии файла",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    // Определение количества HDU-блоков в файле
                    int fileHDUNumber = 0;
                    try
                    {
                        fits.OpenFile(workFile, out fileHDUNumber);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Не удалось прочитать заголовки файла \"{workFile}\":\n" +
                            $"{ex.Message}",
                            "Ошибка открытия файла",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    hduNumber += fileHDUNumber;
                    for (int j = 0; j < fileHDUNumber; j++)
                        unitsList.Add(new UnitMap(i, j));
                    files[i] = workFile;
                    i++;
                    var progress = (int)(100 * i / openFileDialog.FileNames.Length);
                    toolStripProgressBar.Value = progress;
                    toolStripProgressLabel.Text = $"{progress} %";
                } //foreach file

                // Окрытие первого HDU-блока

                crtUnitIndex = 0;
                toolStripNumberComboBox.Items.Clear();
                for (int j = 1; j <= hduNumber; j++)
                    toolStripNumberComboBox.Items.Add($"{j} / {hduNumber}");
                toolStripNumberComboBox.SelectedIndex = crtUnitIndex;

                toolStripProgressBar.Visible = false;
                toolStripProgressLabel.Visible = false;
                toolStripStatusLabel.Text = "Готово";
            }
        }

        private void PreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripNumberComboBox.SelectedIndex > 0)
                toolStripNumberComboBox.SelectedIndex--;
        }

        private void ToolStripNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            crtUnitIndex = toolStripNumberComboBox.SelectedIndex;
            this.Text = $"{Application.ProductName} - {Path.GetFileName(files[unitsList[crtUnitIndex].FileIndex])}";
            HDULoad();
        }

        private void NextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripNumberComboBox.SelectedIndex < toolStripNumberComboBox.Items.Count - 1)
                toolStripNumberComboBox.SelectedIndex++;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Считывание HDU-блоков
        /// </summary>
        private void HDULoad()
        {
            // Считывание заголовка
            var table = new List<string[]> { };
            var hasImage = false;
            try
            {
                fits.ReadHeader(files[unitsList[crtUnitIndex].FileIndex], unitsList[crtUnitIndex].HDUIndex, out table, out hasImage);
            }
            catch (Exception excp)
            {
                MessageBox.Show(
                    $"Не удалось открыть заголовок №{unitsList[crtUnitIndex].HDUIndex}" +
                    $" файла \"{files[unitsList[crtUnitIndex].FileIndex]}\":\n" +
                    $"{excp.Message}",
                    "Ошибка открытия файла",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            HeaderUpdate(table);

            // Считывание снимка для первого заголовка,
            // если таковой есть (NAXIS == 2)

            if (hasImage)
            {
                var data = new Array[] { };
                BitPix bitpix;
                try
                {
                    fits.ReadData(unitsList[crtUnitIndex].HDUIndex, out data, out bitpix);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Не удалось открыть данные для HDU №{unitsList[crtUnitIndex].HDUIndex}" +
                        $" файла \"{files[unitsList[crtUnitIndex].FileIndex]}\":\n" +
                        $"{ex.Message}",
                        "Ошибка открытия файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                DataUpdate(data, bitpix);
            }
            else
                dataPictureBox.Image = new Bitmap(250, 250);

            ControlsUpdate();
        }

        private void HeaderUpdate(List<string[]> table)
        {
            hduDataGridView.Rows.Clear();
            foreach (string[] sa in table)
                hduDataGridView.Rows.Add(sa);
        }

        private void DataUpdate(Array[] data, BitPix bitpix)
        {
            if (bitpix == BitPix.Unknown) return;

            int width = data[0].GetLength(0);
            int height = data.GetLength(0);
            Bitmap bm = new Bitmap(width, height);

            var min = Int32.MaxValue;
            var max = Int32.MinValue;

            // Определение значения для прозрачного фона
            Int32 trnValue = 0;
            if (bitpix == BitPix.Bits8) trnValue = byte.MinValue;
            else if (bitpix == BitPix.Bits16) trnValue = Int16.MinValue;
            else if (bitpix == BitPix.Bits32) trnValue = Int32.MinValue;

            // Определение максимума и минимума значений магнитного поля
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    Int32 value = 0;
                    if (bitpix == BitPix.Bits8) value = ((byte[])data[y])[x];
                    else if (bitpix == BitPix.Bits16) value = ((Int16[])data[y])[x];
                    else if (bitpix == BitPix.Bits32) value = ((Int32[])data[y])[x];
                    if (value > max) 
                        max = value;
                    if ((value < min) && (value != trnValue)) 
                        min = value;
                }
            
            // Отрисовка снимка
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
                    int amp = (int)(255 * (value - min) / (max - min));
                    
                    if (value != trnValue)
                        bm.SetPixel(x, height - y, Color.FromArgb(amp, amp, amp));
                }
            dataPictureBox.Image = bm;
        }

        private void ControlsUpdate()
        {
            foreach (ToolStripItem component in singleSwitchableControls)
                component.Enabled = (hduNumber > 0);
            foreach (ToolStripItem component in multipleSwitchableControls)
                component.Enabled = (hduNumber > 1);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            fits.Free();

            // Удаление рабочей директории
            string crtDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                foreach (Process proc in Process.GetProcessesByName("SunMagnetogramAnalyzer"))
                {
                    proc.Close();
                }
                if (Directory.Exists("fits"))
                {
                    Directory.Delete("fits", true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не удалось удалить рабочую директорию \".\\fits\":\n" +
                    $"{ex.Message}",
                    "Ошибка удаления рабочей директории",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void CalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Расчет диапазона значений магнитных полей";
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;
            toolStripProgressLabel.Text = "0 %";
            toolStripProgressLabel.Visible = true;

            int i = 0;
            var minAmpl = double.MaxValue;
            var maxAmpl = double.MinValue;
            var minDateTime = DateTime.MaxValue;
            var maxDateTime = DateTime.MinValue;
            foreach (string file in files)
            {
                double crtMinAmpl, crtMaxAmpl;
                DateTime crtMinDateTime, crtMaxDateTime;
                try
                {
                    fits.GetValueSpan(file, out crtMinAmpl, out crtMaxAmpl,
                                          out crtMinDateTime, out crtMaxDateTime);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Не удалось прочитать заголовки файла \"{file}\":\n" +
                        $"{ex.Message}",
                        "Ошибка открытия файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (crtMinAmpl < minAmpl) 
                    minAmpl = crtMinAmpl;
                if (crtMaxAmpl > maxAmpl) 
                    maxAmpl = crtMaxAmpl;
                if (crtMinDateTime < minDateTime) 
                    minDateTime = crtMinDateTime;
                if (crtMaxDateTime > maxDateTime) 
                    maxDateTime = crtMaxDateTime;

                i++;
                var progress = (int)(100 * i / files.Length);
                toolStripProgressBar.Value = progress;
                toolStripProgressLabel.Text = $"{progress} %";
            }

            toolStripProgressBar.Visible = false;
            toolStripProgressLabel.Visible = false;
            toolStripStatusLabel.Text = $"Готово";

            var calcForm = new CalcForm(minAmpl, maxAmpl, minDateTime, maxDateTime);
            calcForm.fits = this.fits;
            calcForm.files = this.files;
            calcForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DataPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void CalcToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Расчет диапазона абсолютных значений магнитного потока";
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;
            toolStripProgressLabel.Text = "0 %";
            toolStripProgressLabel.Visible = true;

            int i = 0;
            var minAmpl = 0.0;
            var maxAmpl = 0.0; 
            var minDateTime = DateTime.MaxValue;
            var maxDateTime = DateTime.MinValue;
            foreach (string file in files)
            {
                double crtMinAmpl, crtMaxAmpl;
                DateTime crtMinDateTime, crtMaxDateTime;
                try
                {
                    fits.GetValueSpan(file, out crtMinAmpl, out crtMaxAmpl,
                                          out crtMinDateTime, out crtMaxDateTime);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Не удалось прочитать заголовки файла \"{file}\":\n" +
                        $"{ex.Message}",
                        "Ошибка открытия файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if ((-1.0) * crtMinAmpl < crtMaxAmpl)
                    maxAmpl = crtMaxAmpl;
                else
                    maxAmpl = (-1.0)*crtMinAmpl;
                i++;
                var progress = (int)(100 * i / files.Length);
                toolStripProgressBar.Value = progress;
                toolStripProgressLabel.Text = $"{progress} %";
            }

            toolStripProgressBar.Visible = false;
            toolStripProgressLabel.Visible = false;
            toolStripStatusLabel.Text = $"Готово";

            var calcForm2 = new CalcFluxForm(minAmpl, maxAmpl, minDateTime, maxDateTime);
            calcForm2.fits = this.fits;
            calcForm2.files = this.files;
            calcForm2.ShowDialog();
        }

        // Справка
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                string text = File.ReadAllText("help.txt", Encoding.UTF8);
                MessageBox.Show(text, "Справка", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                        $"Не удалось открыть файл help.txt" +
                        $"{ex.Message}",
                        "Ошибка открытия файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
            }
            
        }
    }
}
