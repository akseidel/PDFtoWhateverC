namespace PDFtoWhateverC
{
    partial class FormPDFtoWhatever
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDFtoWhatever));
            this.textBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.labelSourceFolder = new System.Windows.Forms.Label();
            this.labelTargetFolder = new System.Windows.Forms.Label();
            this.textBoxTargetFolder = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.folderBrowserDialogPicker = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBarConvert = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.toolTipSplitsMaker = new System.Windows.Forms.ToolTip(this.components);
            this.buttonBrowseSource = new System.Windows.Forms.Button();
            this.buttonBrowseTarget = new System.Windows.Forms.Button();
            this.listViewSourcePDFs = new System.Windows.Forms.ListView();
            this.columnSourcePDF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxOutPutType = new System.Windows.Forms.ComboBox();
            this.buttonUnCheckAll = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonRefresh2 = new System.Windows.Forms.Button();
            this.checkBoxSplitsViewer = new System.Windows.Forms.CheckBox();
            this.buttonGoSource = new System.Windows.Forms.Button();
            this.buttonGoTarget = new System.Windows.Forms.Button();
            this.buttonHalt = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSourceFolder
            // 
            this.textBoxSourceFolder.AllowDrop = true;
            this.textBoxSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PDFtoWhateverC.Properties.Settings.Default, "sourceFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxSourceFolder.Location = new System.Drawing.Point(13, 59);
            this.textBoxSourceFolder.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSourceFolder.Multiline = true;
            this.textBoxSourceFolder.Name = "textBoxSourceFolder";
            this.textBoxSourceFolder.Size = new System.Drawing.Size(489, 48);
            this.textBoxSourceFolder.TabIndex = 0;
            this.textBoxSourceFolder.Text = global::PDFtoWhateverC.Properties.Settings.Default.sourceFolder;
            this.toolTipSplitsMaker.SetToolTip(this.textBoxSourceFolder, "Drag and drop folder here or doubleclick.");
            this.textBoxSourceFolder.TextChanged += new System.EventHandler(this.textBoxSourceFolder_TextChanged);
            this.textBoxSourceFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFolder_DragDrop);
            this.textBoxSourceFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFolder_DragEnter);
            this.textBoxSourceFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxSourceFolder_MouseDoubleClick);
            // 
            // labelSourceFolder
            // 
            this.labelSourceFolder.AutoSize = true;
            this.labelSourceFolder.Location = new System.Drawing.Point(13, 40);
            this.labelSourceFolder.Name = "labelSourceFolder";
            this.labelSourceFolder.Size = new System.Drawing.Size(93, 16);
            this.labelSourceFolder.TabIndex = 1;
            this.labelSourceFolder.Text = "Source Folder";
            this.toolTipSplitsMaker.SetToolTip(this.labelSourceFolder, "Where the PDF source files are found. ");
            // 
            // labelTargetFolder
            // 
            this.labelTargetFolder.AutoSize = true;
            this.labelTargetFolder.Location = new System.Drawing.Point(13, 111);
            this.labelTargetFolder.Name = "labelTargetFolder";
            this.labelTargetFolder.Size = new System.Drawing.Size(126, 16);
            this.labelTargetFolder.TabIndex = 3;
            this.labelTargetFolder.Text = "Splits Target Folder";
            this.toolTipSplitsMaker.SetToolTip(this.labelTargetFolder, "Where the splits will be placed.");
            // 
            // textBoxTargetFolder
            // 
            this.textBoxTargetFolder.AllowDrop = true;
            this.textBoxTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTargetFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PDFtoWhateverC.Properties.Settings.Default, "targetFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxTargetFolder.Location = new System.Drawing.Point(13, 130);
            this.textBoxTargetFolder.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTargetFolder.Multiline = true;
            this.textBoxTargetFolder.Name = "textBoxTargetFolder";
            this.textBoxTargetFolder.Size = new System.Drawing.Size(489, 48);
            this.textBoxTargetFolder.TabIndex = 2;
            this.textBoxTargetFolder.Text = global::PDFtoWhateverC.Properties.Settings.Default.targetFolder;
            this.toolTipSplitsMaker.SetToolTip(this.textBoxTargetFolder, "Drag and drop folder here or doubleclick.");
            this.textBoxTargetFolder.TextChanged += new System.EventHandler(this.textBoxTargetFolder_TextChanged);
            this.textBoxTargetFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxTargetFolder_DragDrop);
            this.textBoxTargetFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxTargetFolder_DragEnter);
            this.textBoxTargetFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxTargetFolder_MouseDoubleClick);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Location = new System.Drawing.Point(688, 59);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(84, 48);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start Process";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonStart_MouseClick);
            // 
            // progressBarConvert
            // 
            this.progressBarConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarConvert.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarConvert.Location = new System.Drawing.Point(43, 185);
            this.progressBarConvert.Name = "progressBarConvert";
            this.progressBarConvert.Size = new System.Drawing.Size(579, 19);
            this.progressBarConvert.Step = 1;
            this.progressBarConvert.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarConvert.TabIndex = 5;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.Location = new System.Drawing.Point(13, 5);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(603, 34);
            this.labelStatus.TabIndex = 6;
            // 
            // buttonBrowseSource
            // 
            this.buttonBrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseSource.Location = new System.Drawing.Point(562, 59);
            this.buttonBrowseSource.Name = "buttonBrowseSource";
            this.buttonBrowseSource.Size = new System.Drawing.Size(58, 48);
            this.buttonBrowseSource.TabIndex = 11;
            this.buttonBrowseSource.Text = "Pick Folder";
            this.toolTipSplitsMaker.SetToolTip(this.buttonBrowseSource, "Select folder");
            this.buttonBrowseSource.UseVisualStyleBackColor = true;
            this.buttonBrowseSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonBrowseSource_MouseClick);
            // 
            // buttonBrowseTarget
            // 
            this.buttonBrowseTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseTarget.Location = new System.Drawing.Point(562, 130);
            this.buttonBrowseTarget.Name = "buttonBrowseTarget";
            this.buttonBrowseTarget.Size = new System.Drawing.Size(58, 48);
            this.buttonBrowseTarget.TabIndex = 12;
            this.buttonBrowseTarget.Text = "Pick Folder";
            this.toolTipSplitsMaker.SetToolTip(this.buttonBrowseTarget, "Select folder");
            this.buttonBrowseTarget.UseVisualStyleBackColor = true;
            this.buttonBrowseTarget.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonBrowseTarget_MouseClick);
            // 
            // listViewSourcePDFs
            // 
            this.listViewSourcePDFs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSourcePDFs.CheckBoxes = true;
            this.listViewSourcePDFs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSourcePDF,
            this.columnStatus});
            this.listViewSourcePDFs.FullRowSelect = true;
            this.listViewSourcePDFs.GridLines = true;
            this.listViewSourcePDFs.Location = new System.Drawing.Point(16, 210);
            this.listViewSourcePDFs.Name = "listViewSourcePDFs";
            this.listViewSourcePDFs.Size = new System.Drawing.Size(756, 239);
            this.listViewSourcePDFs.TabIndex = 10;
            this.toolTipSplitsMaker.SetToolTip(this.listViewSourcePDFs, resources.GetString("listViewSourcePDFs.ToolTip"));
            this.listViewSourcePDFs.UseCompatibleStateImageBehavior = false;
            this.listViewSourcePDFs.View = System.Windows.Forms.View.Details;
            this.listViewSourcePDFs.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewSourcePDFs_ItemChecked);
            this.listViewSourcePDFs.SelectedIndexChanged += new System.EventHandler(this.listViewSourcePDFs_SelectedIndexChanged);
            this.listViewSourcePDFs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSourcePDFs_MouseClick);
            // 
            // columnSourcePDF
            // 
            this.columnSourcePDF.Text = "Source PDF";
            this.columnSourcePDF.Width = 570;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStatus.Width = 180;
            // 
            // comboBoxOutPutType
            // 
            this.comboBoxOutPutType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOutPutType.AutoCompleteCustomSource.AddRange(new string[] {
            ".jpg",
            ".png",
            ".gif",
            ".tif",
            ".bmp"});
            this.comboBoxOutPutType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxOutPutType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxOutPutType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOutPutType.FormattingEnabled = true;
            this.comboBoxOutPutType.Items.AddRange(new object[] {
            ".jpg",
            ".png",
            ".gif",
            ".tif",
            ".bmp"});
            this.comboBoxOutPutType.Location = new System.Drawing.Point(688, 13);
            this.comboBoxOutPutType.Name = "comboBoxOutPutType";
            this.comboBoxOutPutType.Size = new System.Drawing.Size(84, 24);
            this.comboBoxOutPutType.TabIndex = 13;
            this.comboBoxOutPutType.Text = ".jpg";
            this.toolTipSplitsMaker.SetToolTip(this.comboBoxOutPutType, "Conversion Type");
            this.comboBoxOutPutType.SelectedIndexChanged += new System.EventHandler(this.comboBoxOutPutType_SelectedIndexChanged);
            // 
            // buttonUnCheckAll
            // 
            this.buttonUnCheckAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUnCheckAll.BackgroundImage")));
            this.buttonUnCheckAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUnCheckAll.FlatAppearance.BorderSize = 0;
            this.buttonUnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonUnCheckAll.Location = new System.Drawing.Point(16, 185);
            this.buttonUnCheckAll.Name = "buttonUnCheckAll";
            this.buttonUnCheckAll.Size = new System.Drawing.Size(21, 19);
            this.buttonUnCheckAll.TabIndex = 15;
            this.toolTipSplitsMaker.SetToolTip(this.buttonUnCheckAll, "Check All");
            this.buttonUnCheckAll.UseVisualStyleBackColor = true;
            this.buttonUnCheckAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonUnCheckAll_MouseClick);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.BackgroundImage")));
            this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(509, 59);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(48, 48);
            this.buttonRefresh.TabIndex = 16;
            this.toolTipSplitsMaker.SetToolTip(this.buttonRefresh, "Refresh List");
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonRefresh_MouseClick);
            // 
            // buttonRefresh2
            // 
            this.buttonRefresh2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRefresh2.BackgroundImage")));
            this.buttonRefresh2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRefresh2.FlatAppearance.BorderSize = 0;
            this.buttonRefresh2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonRefresh2.Location = new System.Drawing.Point(509, 130);
            this.buttonRefresh2.Name = "buttonRefresh2";
            this.buttonRefresh2.Size = new System.Drawing.Size(48, 48);
            this.buttonRefresh2.TabIndex = 17;
            this.toolTipSplitsMaker.SetToolTip(this.buttonRefresh2, "Refresh List");
            this.buttonRefresh2.UseVisualStyleBackColor = true;
            this.buttonRefresh2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonRefresh2_MouseClick);
            // 
            // checkBoxSplitsViewer
            // 
            this.checkBoxSplitsViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSplitsViewer.AutoSize = true;
            this.checkBoxSplitsViewer.Location = new System.Drawing.Point(640, 185);
            this.checkBoxSplitsViewer.Name = "checkBoxSplitsViewer";
            this.checkBoxSplitsViewer.Size = new System.Drawing.Size(104, 20);
            this.checkBoxSplitsViewer.TabIndex = 18;
            this.checkBoxSplitsViewer.Text = "Splits Viewer";
            this.toolTipSplitsMaker.SetToolTip(this.checkBoxSplitsViewer, "The Splits Viewer will show all the\r\nimages together for the selected item.\r\nSpli" +
        "ts images can be culled in the\r\nSplits Viewer. ");
            this.checkBoxSplitsViewer.UseVisualStyleBackColor = true;
            this.checkBoxSplitsViewer.Click += new System.EventHandler(this.checkBoxSplitsViewer_Click);
            // 
            // buttonGoSource
            // 
            this.buttonGoSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGoSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoSource.Location = new System.Drawing.Point(625, 59);
            this.buttonGoSource.Name = "buttonGoSource";
            this.buttonGoSource.Size = new System.Drawing.Size(58, 48);
            this.buttonGoSource.TabIndex = 7;
            this.buttonGoSource.Text = "Open Here";
            this.buttonGoSource.UseVisualStyleBackColor = true;
            this.buttonGoSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGoSource_MouseClick);
            // 
            // buttonGoTarget
            // 
            this.buttonGoTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGoTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoTarget.Location = new System.Drawing.Point(625, 130);
            this.buttonGoTarget.Name = "buttonGoTarget";
            this.buttonGoTarget.Size = new System.Drawing.Size(58, 48);
            this.buttonGoTarget.TabIndex = 8;
            this.buttonGoTarget.Text = "Open Here";
            this.buttonGoTarget.UseVisualStyleBackColor = true;
            this.buttonGoTarget.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGoTarget_MouseClick);
            // 
            // buttonHalt
            // 
            this.buttonHalt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHalt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonHalt.Enabled = false;
            this.buttonHalt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHalt.Location = new System.Drawing.Point(688, 130);
            this.buttonHalt.Name = "buttonHalt";
            this.buttonHalt.Size = new System.Drawing.Size(84, 48);
            this.buttonHalt.TabIndex = 9;
            this.buttonHalt.Text = "Halt";
            this.buttonHalt.UseVisualStyleBackColor = false;
            this.buttonHalt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonHalt_MouseClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(619, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Output\r\nType";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPDFtoWhatever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.checkBoxSplitsViewer);
            this.Controls.Add(this.buttonRefresh2);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonUnCheckAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxOutPutType);
            this.Controls.Add(this.buttonBrowseTarget);
            this.Controls.Add(this.buttonBrowseSource);
            this.Controls.Add(this.listViewSourcePDFs);
            this.Controls.Add(this.buttonHalt);
            this.Controls.Add(this.buttonGoTarget);
            this.Controls.Add(this.buttonGoSource);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBarConvert);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelTargetFolder);
            this.Controls.Add(this.textBoxTargetFolder);
            this.Controls.Add(this.labelSourceFolder);
            this.Controls.Add(this.textBoxSourceFolder);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FormPDFtoWhatever";
            this.Text = "PDF Splits Maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPDFtoWhatever_FormClosing);
            this.Load += new System.EventHandler(this.FormPDFtoWhatever_Load);
            this.ResizeEnd += new System.EventHandler(this.FormPDFtoWhatever_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSourceFolder;
        private System.Windows.Forms.Label labelSourceFolder;
        private System.Windows.Forms.Label labelTargetFolder;
        private System.Windows.Forms.TextBox textBoxTargetFolder;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPicker;
        private System.Windows.Forms.ProgressBar progressBarConvert;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ToolTip toolTipSplitsMaker;
        private System.Windows.Forms.Button buttonGoSource;
        private System.Windows.Forms.Button buttonGoTarget;
        private System.Windows.Forms.Button buttonHalt;
        private System.Windows.Forms.ListView listViewSourcePDFs;
        private System.Windows.Forms.ColumnHeader columnSourcePDF;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonBrowseSource;
        private System.Windows.Forms.Button buttonBrowseTarget;
        private System.Windows.Forms.ComboBox comboBoxOutPutType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUnCheckAll;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonRefresh2;
        private System.Windows.Forms.CheckBox checkBoxSplitsViewer;
    }
}

