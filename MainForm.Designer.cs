namespace SunMagnetogramAnalyzer
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.calcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.calcToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripOpenFileButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripPreviousButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripNumberComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripNextButton = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dataPictureBox = new System.Windows.Forms.PictureBox();
			this.hduDataGridView = new System.Windows.Forms.DataGridView();
			this.KeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hduDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.helpMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(1132, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
			this.fileToolStripMenuItem.Text = "Файл";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
			this.openToolStripMenuItem.Text = "Открыть ...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
			this.exitToolStripMenuItem.Text = "Выход";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previousToolStripMenuItem,
            this.toolStripSeparator4,
            this.nextToolStripMenuItem});
			this.viewToolStripMenuItem.Enabled = false;
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
			this.viewToolStripMenuItem.Text = "Вид";
			// 
			// previousToolStripMenuItem
			// 
			this.previousToolStripMenuItem.Enabled = false;
			this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
			this.previousToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
			this.previousToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
			this.previousToolStripMenuItem.Text = "Предыдущий снимок";
			this.previousToolStripMenuItem.Click += new System.EventHandler(this.PreviousToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(304, 6);
			// 
			// nextToolStripMenuItem
			// 
			this.nextToolStripMenuItem.Enabled = false;
			this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
			this.nextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
			this.nextToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
			this.nextToolStripMenuItem.Text = "Следующий снимок";
			this.nextToolStripMenuItem.Click += new System.EventHandler(this.NextToolStripMenuItem_Click);
			// 
			// actionToolStripMenuItem
			// 
			this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcToolStripMenuItem,
            this.toolStripSeparator2,
            this.calcToolStripMenuItem2});
			this.actionToolStripMenuItem.Enabled = false;
			this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
			this.actionToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
			this.actionToolStripMenuItem.Text = "Действия";
			// 
			// calcToolStripMenuItem
			// 
			this.calcToolStripMenuItem.Enabled = false;
			this.calcToolStripMenuItem.Name = "calcToolStripMenuItem";
			this.calcToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.calcToolStripMenuItem.Size = new System.Drawing.Size(439, 26);
			this.calcToolStripMenuItem.Text = "Изменение средней величины поля";
			this.calcToolStripMenuItem.Click += new System.EventHandler(this.CalcToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(436, 6);
			// 
			// calcToolStripMenuItem2
			// 
			this.calcToolStripMenuItem2.Enabled = false;
			this.calcToolStripMenuItem2.Name = "calcToolStripMenuItem2";
			this.calcToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
			this.calcToolStripMenuItem2.Size = new System.Drawing.Size(439, 26);
			this.calcToolStripMenuItem2.Text = "Изменение среднего абсолютного потока";
			this.calcToolStripMenuItem2.Click += new System.EventHandler(this.CalcToolStripMenuItem2_Click);
			// 
			// helpMenuItem
			// 
			this.helpMenuItem.Name = "helpMenuItem";
			this.helpMenuItem.Size = new System.Drawing.Size(81, 24);
			this.helpMenuItem.Text = "Справка";
			this.helpMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenFileButton,
            this.toolStripSeparator1,
            this.toolStripPreviousButton,
            this.toolStripNumberComboBox,
            this.toolStripNextButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 28);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1132, 28);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripOpenFileButton
			// 
			this.toolStripOpenFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripOpenFileButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpenFileButton.Image")));
			this.toolStripOpenFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripOpenFileButton.Name = "toolStripOpenFileButton";
			this.toolStripOpenFileButton.Size = new System.Drawing.Size(29, 25);
			this.toolStripOpenFileButton.Text = "toolStripButton1";
			this.toolStripOpenFileButton.ToolTipText = "Открыть новый FITS-файл";
			this.toolStripOpenFileButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
			// 
			// toolStripPreviousButton
			// 
			this.toolStripPreviousButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripPreviousButton.Enabled = false;
			this.toolStripPreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPreviousButton.Image")));
			this.toolStripPreviousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripPreviousButton.Name = "toolStripPreviousButton";
			this.toolStripPreviousButton.Size = new System.Drawing.Size(29, 25);
			this.toolStripPreviousButton.Text = "Предыдущий снимок";
			this.toolStripPreviousButton.ToolTipText = "Предыдущий снимок";
			this.toolStripPreviousButton.Click += new System.EventHandler(this.PreviousToolStripMenuItem_Click);
			// 
			// toolStripNumberComboBox
			// 
			this.toolStripNumberComboBox.Enabled = false;
			this.toolStripNumberComboBox.Name = "toolStripNumberComboBox";
			this.toolStripNumberComboBox.Size = new System.Drawing.Size(105, 28);
			this.toolStripNumberComboBox.ToolTipText = "Текущий снимок";
			this.toolStripNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.ToolStripNumberComboBox_SelectedIndexChanged);
			// 
			// toolStripNextButton
			// 
			this.toolStripNextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripNextButton.Enabled = false;
			this.toolStripNextButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNextButton.Image")));
			this.toolStripNextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripNextButton.Name = "toolStripNextButton";
			this.toolStripNextButton.Size = new System.Drawing.Size(29, 25);
			this.toolStripNextButton.Text = "Следующий снимок";
			this.toolStripNextButton.ToolTipText = "Следующий снимок";
			this.toolStripNextButton.Click += new System.EventHandler(this.NextToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar,
            this.toolStripProgressLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 727);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip1.Size = new System.Drawing.Size(1132, 26);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.AutoSize = false;
			this.toolStripStatusLabel.AutoToolTip = true;
			this.toolStripStatusLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(400, 20);
			this.toolStripStatusLabel.Text = "Выберите файл(ы) для анализа";
			this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripStatusLabel.Click += new System.EventHandler(this.toolStripStatusLabel_Click);
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(133, 18);
			this.toolStripProgressBar.Visible = false;
			// 
			// toolStripProgressLabel
			// 
			this.toolStripProgressLabel.Name = "toolStripProgressLabel";
			this.toolStripProgressLabel.Size = new System.Drawing.Size(33, 20);
			this.toolStripProgressLabel.Text = "0 %";
			this.toolStripProgressLabel.Visible = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 56);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
			this.splitContainer1.Panel1.Controls.Add(this.dataPictureBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel2.Controls.Add(this.hduDataGridView);
			this.splitContainer1.Size = new System.Drawing.Size(1132, 671);
			this.splitContainer1.SplitterDistance = 833;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 3;
			this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1_SplitterMoved);
			// 
			// dataPictureBox
			// 
			this.dataPictureBox.BackColor = System.Drawing.Color.Black;
			this.dataPictureBox.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.dataPictureBox.Location = new System.Drawing.Point(0, 0);
			this.dataPictureBox.Margin = new System.Windows.Forms.Padding(4);
			this.dataPictureBox.Name = "dataPictureBox";
			this.dataPictureBox.Size = new System.Drawing.Size(787, 603);
			this.dataPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.dataPictureBox.TabIndex = 1;
			this.dataPictureBox.TabStop = false;
			this.dataPictureBox.Click += new System.EventHandler(this.DataPictureBox_Click);
			// 
			// hduDataGridView
			// 
			this.hduDataGridView.AllowUserToAddRows = false;
			this.hduDataGridView.AllowUserToDeleteRows = false;
			this.hduDataGridView.AllowUserToOrderColumns = true;
			this.hduDataGridView.AllowUserToResizeRows = false;
			this.hduDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.hduDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyColumn,
            this.ValueColumn,
            this.CommentColumn});
			this.hduDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hduDataGridView.Location = new System.Drawing.Point(0, 0);
			this.hduDataGridView.Margin = new System.Windows.Forms.Padding(4);
			this.hduDataGridView.Name = "hduDataGridView";
			this.hduDataGridView.ReadOnly = true;
			this.hduDataGridView.RowHeadersVisible = false;
			this.hduDataGridView.RowHeadersWidth = 51;
			this.hduDataGridView.Size = new System.Drawing.Size(294, 671);
			this.hduDataGridView.TabIndex = 0;
			// 
			// KeyColumn
			// 
			this.KeyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.KeyColumn.HeaderText = "Ключ";
			this.KeyColumn.MinimumWidth = 6;
			this.KeyColumn.Name = "KeyColumn";
			this.KeyColumn.ReadOnly = true;
			this.KeyColumn.Width = 72;
			// 
			// ValueColumn
			// 
			this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ValueColumn.HeaderText = "Значение";
			this.ValueColumn.MinimumWidth = 6;
			this.ValueColumn.Name = "ValueColumn";
			this.ValueColumn.ReadOnly = true;
			this.ValueColumn.Width = 102;
			// 
			// CommentColumn
			// 
			this.CommentColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.CommentColumn.HeaderText = "Комментарий";
			this.CommentColumn.MinimumWidth = 6;
			this.CommentColumn.Name = "CommentColumn";
			this.CommentColumn.ReadOnly = true;
			this.CommentColumn.Width = 127;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1132, 753);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(527, 605);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SunMagnetogramAnalyzer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hduDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.DataGridView hduDataGridView;
        private System.Windows.Forms.ToolStripButton toolStripOpenFileButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripPreviousButton;
        private System.Windows.Forms.ToolStripComboBox toolStripNumberComboBox;
        private System.Windows.Forms.ToolStripButton toolStripNextButton;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressLabel;
        private System.Windows.Forms.PictureBox dataPictureBox;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentColumn;
        private System.Windows.Forms.ToolStripMenuItem calcToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem calcToolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
	}
}

