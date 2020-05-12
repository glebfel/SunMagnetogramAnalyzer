namespace SunMagnetogramAnalyzer
{
	partial class CalcAbsForceForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalcAbsForceForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.maxAmplLabel = new System.Windows.Forms.Label();
			this.minAmplLabel = new System.Windows.Forms.Label();
			this.maxAmplTextBox = new System.Windows.Forms.TextBox();
			this.minAmplTextBox = new System.Windows.Forms.TextBox();
			this.maxAmplTrackBar = new System.Windows.Forms.TrackBar();
			this.minAmplTrackBar = new System.Windows.Forms.TrackBar();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.calcButton = new System.Windows.Forms.Button();
			this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.saveButton = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxAmplTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minAmplTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.maxAmplLabel);
			this.groupBox1.Controls.Add(this.minAmplLabel);
			this.groupBox1.Controls.Add(this.maxAmplTextBox);
			this.groupBox1.Controls.Add(this.minAmplTextBox);
			this.groupBox1.Controls.Add(this.maxAmplTrackBar);
			this.groupBox1.Controls.Add(this.minAmplTrackBar);
			this.groupBox1.Location = new System.Drawing.Point(13, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1095, 135);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Диапазон магнитного поля (Гс)";
			// 
			// maxAmplLabel
			// 
			this.maxAmplLabel.AutoSize = true;
			this.maxAmplLabel.Location = new System.Drawing.Point(929, 80);
			this.maxAmplLabel.Name = "maxAmplLabel";
			this.maxAmplLabel.Size = new System.Drawing.Size(46, 17);
			this.maxAmplLabel.TabIndex = 4;
			this.maxAmplLabel.Text = "label2";
			// 
			// minAmplLabel
			// 
			this.minAmplLabel.AutoSize = true;
			this.minAmplLabel.Location = new System.Drawing.Point(929, 25);
			this.minAmplLabel.Name = "minAmplLabel";
			this.minAmplLabel.Size = new System.Drawing.Size(46, 17);
			this.minAmplLabel.TabIndex = 3;
			this.minAmplLabel.Text = "label1";
			this.minAmplLabel.Click += new System.EventHandler(this.minAmplLabel_Click);
			// 
			// maxAmplTextBox
			// 
			this.maxAmplTextBox.Location = new System.Drawing.Point(794, 77);
			this.maxAmplTextBox.Name = "maxAmplTextBox";
			this.maxAmplTextBox.Size = new System.Drawing.Size(129, 22);
			this.maxAmplTextBox.TabIndex = 1;
			// 
			// minAmplTextBox
			// 
			this.minAmplTextBox.Location = new System.Drawing.Point(794, 22);
			this.minAmplTextBox.Name = "minAmplTextBox";
			this.minAmplTextBox.Size = new System.Drawing.Size(129, 22);
			this.minAmplTextBox.TabIndex = 2;
			// 
			// maxAmplTrackBar
			// 
			this.maxAmplTrackBar.Location = new System.Drawing.Point(20, 75);
			this.maxAmplTrackBar.Name = "maxAmplTrackBar";
			this.maxAmplTrackBar.Size = new System.Drawing.Size(768, 56);
			this.maxAmplTrackBar.TabIndex = 1;
			this.maxAmplTrackBar.Scroll += new System.EventHandler(this.MaxAmplTrackBar_ValueChanged);
			// 
			// minAmplTrackBar
			// 
			this.minAmplTrackBar.Location = new System.Drawing.Point(20, 22);
			this.minAmplTrackBar.Name = "minAmplTrackBar";
			this.minAmplTrackBar.Size = new System.Drawing.Size(768, 56);
			this.minAmplTrackBar.TabIndex = 0;
			this.minAmplTrackBar.Scroll += new System.EventHandler(this.MinAmplTrackBar_ValueChanged);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(13, 577);
			this.progressBar.Margin = new System.Windows.Forms.Padding(4);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(848, 28);
			this.progressBar.TabIndex = 7;
			// 
			// calcButton
			// 
			this.calcButton.Location = new System.Drawing.Point(903, 577);
			this.calcButton.Margin = new System.Windows.Forms.Padding(4);
			this.calcButton.Name = "calcButton";
			this.calcButton.Size = new System.Drawing.Size(205, 28);
			this.calcButton.TabIndex = 8;
			this.calcButton.Text = "Рассчитать изменение среднего значения поля";
			this.calcButton.UseVisualStyleBackColor = true;
			this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
			// 
			// dataChart
			// 
			chartArea1.Name = "ChartArea1";
			this.dataChart.ChartAreas.Add(chartArea1);
			this.dataChart.Location = new System.Drawing.Point(13, 163);
			this.dataChart.Margin = new System.Windows.Forms.Padding(4);
			this.dataChart.Name = "dataChart";
			this.dataChart.Size = new System.Drawing.Size(1095, 384);
			this.dataChart.TabIndex = 9;
			this.dataChart.Text = "chart1";
			this.dataChart.Click += new System.EventHandler(this.dataChart_Click_1);
			// 
			// saveButton
			// 
			this.saveButton.Enabled = false;
			this.saveButton.Location = new System.Drawing.Point(903, 612);
			this.saveButton.Margin = new System.Windows.Forms.Padding(4);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(205, 28);
			this.saveButton.TabIndex = 10;
			this.saveButton.Text = "Сохранить график";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// CalcAbsForceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1121, 653);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.dataChart);
			this.Controls.Add(this.calcButton);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CalcAbsForceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Изменение средней абсолютной величины магнитного поля";
			this.Load += new System.EventHandler(this.CalcFluxForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxAmplTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minAmplTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TrackBar maxAmplTrackBar;
		private System.Windows.Forms.TrackBar minAmplTrackBar;
		private System.Windows.Forms.TextBox maxAmplTextBox;
		private System.Windows.Forms.TextBox minAmplTextBox;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button calcButton;
		private System.Windows.Forms.Label maxAmplLabel;
		private System.Windows.Forms.Label minAmplLabel;
		private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
	}
}