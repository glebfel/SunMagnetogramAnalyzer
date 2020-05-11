using System;

namespace SunMagnetogramAnalyzer
{
    partial class CalcForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalcForm));
			this.minAmplTrackBar = new System.Windows.Forms.TrackBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.maxAmplTrackBar = new System.Windows.Forms.TrackBar();
			this.maxAmplLabel = new System.Windows.Forms.Label();
			this.minAmplLabel = new System.Windows.Forms.Label();
			this.maxAmplTextBox = new System.Windows.Forms.TextBox();
			this.minAmplTextBox = new System.Windows.Forms.TextBox();
			this.calcButton = new System.Windows.Forms.Button();
			this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.saveButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.minAmplTrackBar)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxAmplTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
			this.SuspendLayout();
			// 
			// minAmplTrackBar
			// 
			this.minAmplTrackBar.Location = new System.Drawing.Point(8, 23);
			this.minAmplTrackBar.Margin = new System.Windows.Forms.Padding(4);
			this.minAmplTrackBar.Name = "minAmplTrackBar";
			this.minAmplTrackBar.Size = new System.Drawing.Size(782, 56);
			this.minAmplTrackBar.TabIndex = 0;
			this.minAmplTrackBar.Scroll += new System.EventHandler(this.minAmplTrackBar_Scroll);
			this.minAmplTrackBar.ValueChanged += new System.EventHandler(this.MinAmplTrackBar_ValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.maxAmplTrackBar);
			this.groupBox1.Controls.Add(this.maxAmplLabel);
			this.groupBox1.Controls.Add(this.minAmplLabel);
			this.groupBox1.Controls.Add(this.maxAmplTextBox);
			this.groupBox1.Controls.Add(this.minAmplTextBox);
			this.groupBox1.Controls.Add(this.minAmplTrackBar);
			this.groupBox1.Location = new System.Drawing.Point(24, 13);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(1073, 148);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Диапазон магнитного поля (Гс)";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// maxAmplTrackBar
			// 
			this.maxAmplTrackBar.Location = new System.Drawing.Point(8, 86);
			this.maxAmplTrackBar.Margin = new System.Windows.Forms.Padding(4);
			this.maxAmplTrackBar.Name = "maxAmplTrackBar";
			this.maxAmplTrackBar.Size = new System.Drawing.Size(782, 56);
			this.maxAmplTrackBar.TabIndex = 3;
			this.maxAmplTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.maxAmplTrackBar.Scroll += new System.EventHandler(this.maxAmplTrackBar_Scroll);
			this.maxAmplTrackBar.ValueChanged += new System.EventHandler(this.MaxAmplTrackBar_ValueChanged);
			// 
			// maxAmplLabel
			// 
			this.maxAmplLabel.AutoSize = true;
			this.maxAmplLabel.Location = new System.Drawing.Point(823, 125);
			this.maxAmplLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.maxAmplLabel.Name = "maxAmplLabel";
			this.maxAmplLabel.Size = new System.Drawing.Size(0, 17);
			this.maxAmplLabel.TabIndex = 2;
			// 
			// minAmplLabel
			// 
			this.minAmplLabel.AutoSize = true;
			this.minAmplLabel.Location = new System.Drawing.Point(823, 46);
			this.minAmplLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.minAmplLabel.Name = "minAmplLabel";
			this.minAmplLabel.Size = new System.Drawing.Size(0, 17);
			this.minAmplLabel.TabIndex = 2;
			// 
			// maxAmplTextBox
			// 
			this.maxAmplTextBox.Enabled = false;
			this.maxAmplTextBox.Location = new System.Drawing.Point(816, 99);
			this.maxAmplTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.maxAmplTextBox.Name = "maxAmplTextBox";
			this.maxAmplTextBox.Size = new System.Drawing.Size(145, 22);
			this.maxAmplTextBox.TabIndex = 1;
			this.maxAmplTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// minAmplTextBox
			// 
			this.minAmplTextBox.Enabled = false;
			this.minAmplTextBox.Location = new System.Drawing.Point(816, 20);
			this.minAmplTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.minAmplTextBox.Name = "minAmplTextBox";
			this.minAmplTextBox.Size = new System.Drawing.Size(145, 22);
			this.minAmplTextBox.TabIndex = 1;
			this.minAmplTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.minAmplTextBox.TextChanged += new System.EventHandler(this.MinAmplTextBox_TextChanged);
			// 
			// calcButton
			// 
			this.calcButton.Location = new System.Drawing.Point(892, 576);
			this.calcButton.Margin = new System.Windows.Forms.Padding(4);
			this.calcButton.Name = "calcButton";
			this.calcButton.Size = new System.Drawing.Size(205, 28);
			this.calcButton.TabIndex = 4;
			this.calcButton.Text = "Рассчитать изменение";
			this.calcButton.UseVisualStyleBackColor = true;
			this.calcButton.Click += new System.EventHandler(this.CalcButton_Click);
			// 
			// dataChart
			// 
			chartArea1.Name = "ChartArea1";
			this.dataChart.ChartAreas.Add(chartArea1);
			this.dataChart.Location = new System.Drawing.Point(24, 169);
			this.dataChart.Margin = new System.Windows.Forms.Padding(4);
			this.dataChart.Name = "dataChart";
			this.dataChart.Size = new System.Drawing.Size(1073, 384);
			this.dataChart.TabIndex = 5;
			this.dataChart.Text = "chart1";
			this.dataChart.Click += new System.EventHandler(this.dataChart_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(24, 576);
			this.progressBar.Margin = new System.Windows.Forms.Padding(4);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(818, 28);
			this.progressBar.TabIndex = 6;
			this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
			// 
			// saveButton
			// 
			this.saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.saveButton.Enabled = false;
			this.saveButton.Location = new System.Drawing.Point(892, 612);
			this.saveButton.Margin = new System.Windows.Forms.Padding(4);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(205, 28);
			this.saveButton.TabIndex = 7;
			this.saveButton.Text = "Сохранить график";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.EnabledChanged += new System.EventHandler(this.saveButton_EnabledChanged);
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click_1);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// CalcForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1121, 653);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.dataChart);
			this.Controls.Add(this.calcButton);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CalcForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Изменение средней велечины магнитного поля по полярности";
			this.Load += new System.EventHandler(this.CalcForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.minAmplTrackBar)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxAmplTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
			this.ResumeLayout(false);

        }

		



		#endregion

		private System.Windows.Forms.TrackBar minAmplTrackBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label minAmplLabel;
        private System.Windows.Forms.TextBox minAmplTextBox;
        private System.Windows.Forms.TrackBar maxAmplTrackBar;
        private System.Windows.Forms.Label maxAmplLabel;
        private System.Windows.Forms.TextBox maxAmplTextBox;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
	}
}