using nom.tam.fits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SunMagnetogramAnalyzer
{
    public partial class CalcForceForm : Form
    {
        public FitsWrapper fits;
        public string[] files;

        public CalcForceForm(double minVal, double maxVal, DateTime minDateTime, DateTime maxDateTime)
        {
            InitializeComponent();
            minAmplTrackBar.Value = minAmplTrackBar.Minimum = maxAmplTrackBar.Minimum = 10 * (int)minVal;
            maxAmplTrackBar.Value = minAmplTrackBar.Maximum = maxAmplTrackBar.Maximum = 10 * (int)maxVal;
            
            minAmplTextBox.Text = minVal.ToString();
            maxAmplTextBox.Text = maxVal.ToString();
            minAmplLabel.Text = $"(Минимум: {minVal})";
            maxAmplLabel.Text = $"(Максимум: {maxVal})";
        }

        private void MinAmplTrackBar_ValueChanged(object sender, EventArgs e)
        {
            minAmplTextBox.Text = (minAmplTrackBar.Value / 10.0).ToString();
            if (maxAmplTrackBar.Value < minAmplTrackBar.Value)
                maxAmplTrackBar.Value = minAmplTrackBar.Value;
        }

        private void MaxAmplTrackBar_ValueChanged(object sender, EventArgs e)
        {
            maxAmplTextBox.Text = (maxAmplTrackBar.Value / 10.0).ToString();
            if (minAmplTrackBar.Value > maxAmplTrackBar.Value)
                minAmplTrackBar.Value = maxAmplTrackBar.Value;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            dataChart.Series.Clear();
            dataChart.Series.Add("SumSeries");
            dataChart.Series["SumSeries"].ChartType = SeriesChartType.Spline;
            dataChart.Series["SumSeries"].XValueType = ChartValueType.DateTime;
            dataChart.Series["SumSeries"].MarkerStyle = MarkerStyle.Circle;
            int i = 0;
            foreach (string file in files)
            {
                List<DateValue> points;
                try
                {
                    fits.CalcDependencyForce(file, minAmplTrackBar.Value / 10.0,
                                        maxAmplTrackBar.Value / 10.0, out points);
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

                foreach (DateValue point in points)
                    dataChart.Series["SumSeries"].Points.AddXY(point.Date, point.Value);
                i++;
                var progress = (int)(100 * i / files.Length);
                progressBar.Value = progress;
            }

            progressBar.Value = 0;
            // активация кнопки сохранения
            if (i > 0)
                saveButton.Enabled = true;
        }

      
        private void MinAmplTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalcForm_Load(object sender, EventArgs e)
        {

        }

        private void minAmplTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataChart_Click(object sender, EventArgs e)
        {

        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void maxAmplTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                // Вызов диалогового окна сохранения файла

                this.saveFileDialog.Title = "Сохранить график";
                // Возможные варианты начальной папки в диалоговом окне
                // openFileDialog.InitialDirectory = "c:\\"; // Диск C:
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Рабочий стол
                // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Мои Документы
                saveFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"; // Мой компьютер
                saveFileDialog.Filter = "Файлы *.jpg |*.jpg|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CheckFileExists = false;

                var saveResult = saveFileDialog.ShowDialog();
                if (saveResult != DialogResult.OK)
                {
                   
                    if (saveResult != DialogResult.Cancel)
                        MessageBox.Show(
                            $"Неправильно выбран(ы) файл(ы) \"{files}\"",
                            "Ошибка сохранения снимка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }

                dataChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                MessageBox.Show("Файл сохранен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveButton_EnabledChanged(object sender, EventArgs e)
        {
           
        }
    }
}
