namespace PDFtoWhateverC
{
    partial class FormImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageViewer));
            this.listViewCuts = new System.Windows.Forms.ListView();
            this.panelCutSplit = new System.Windows.Forms.Panel();
            this.pictureBoxCutSplit = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerGetSplits = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolTipImageViewer = new System.Windows.Forms.ToolTip(this.components);
            this.panelCutSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCutSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCuts
            // 
            this.listViewCuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCuts.Location = new System.Drawing.Point(0, 0);
            this.listViewCuts.Name = "listViewCuts";
            this.listViewCuts.Size = new System.Drawing.Size(512, 677);
            this.listViewCuts.TabIndex = 0;
            this.toolTipImageViewer.SetToolTip(this.listViewCuts, "Delete key or Backspace key\r\nwill delete the image file. ");
            this.listViewCuts.UseCompatibleStateImageBehavior = false;
            this.listViewCuts.SelectedIndexChanged += new System.EventHandler(this.listViewCuts_SelectedIndexChanged);
            this.listViewCuts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewCuts_KeyUp);
            // 
            // panelCutSplit
            // 
            this.panelCutSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCutSplit.Controls.Add(this.pictureBoxCutSplit);
            this.panelCutSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCutSplit.Location = new System.Drawing.Point(0, 0);
            this.panelCutSplit.Name = "panelCutSplit";
            this.panelCutSplit.Size = new System.Drawing.Size(494, 677);
            this.panelCutSplit.TabIndex = 1;
            // 
            // pictureBoxCutSplit
            // 
            this.pictureBoxCutSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCutSplit.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCutSplit.Name = "pictureBoxCutSplit";
            this.pictureBoxCutSplit.Size = new System.Drawing.Size(492, 675);
            this.pictureBoxCutSplit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCutSplit.TabIndex = 0;
            this.pictureBoxCutSplit.TabStop = false;
            // 
            // backgroundWorkerGetSplits
            // 
            this.backgroundWorkerGetSplits.WorkerSupportsCancellation = true;
            this.backgroundWorkerGetSplits.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGetSplits_DoWork);
            this.backgroundWorkerGetSplits.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerGetSplits_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewCuts);
            this.splitContainer1.Panel1MinSize = 256;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelCutSplit);
            this.splitContainer1.Panel2MinSize = 382;
            this.splitContainer1.Size = new System.Drawing.Size(1012, 677);
            this.splitContainer1.SplitterDistance = 512;
            this.splitContainer1.SplitterIncrement = 256;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 2;
            // 
            // FormImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 677);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormImageViewer";
            this.Text = "ImageViewerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormImageViewer_FormClosing);
            this.Shown += new System.EventHandler(this.FormImageViewer_Shown);
            this.panelCutSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCutSplit)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewCuts;
        private System.Windows.Forms.Panel panelCutSplit;
        private System.Windows.Forms.PictureBox pictureBoxCutSplit;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetSplits;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTipImageViewer;
    }
}