using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using Microsoft.Win32;


namespace PDFtoWhateverC {
    public partial class FormPDFtoWhatever : Form {
        int qtySources = 0;
        string currentSourceFolder = string.Empty;
        string currentTargetFolder = string.Empty;
        string msgFileMissing = "File Is Missing!";
        string msgInProcess = "In Process";
        string msgProcessedInto = "Processed into ";
        string msgNotProcessed = "Not Proccessed";
        string msgOutPutType = "JPGs";
        string outPutExtType = ".jpg";
        string checkAllState = "P";
        ListViewItem lastSelectedItem = null;
        int progTickMult = 8;
        int inDxZeroMissing = -99999;
        public string cutSuffixText = "_Page-";
        public PDFtoWhateverC.FormImageViewer thisSplitsViewer;

        public FormPDFtoWhatever() {
            InitializeComponent();
        }   

        private void FormPDFtoWhatever_Load(object sender, EventArgs e) {
            // CheckForGS();  // check currently not working
            GetPrefs();
            doAnyArguments();
            buttonHalt.Enabled = false;
            currentSourceFolder = textBoxSourceFolder.Text.Trim();
            CheckSourceStatus(currentSourceFolder);
            CheckTargetStatus(currentTargetFolder);
            CheckForExistingOutput();
            ResizeListViewheaders();
        }

        private void GetPrefs() {
            currentSourceFolder = Properties.Settings.Default.sourceFolder;
            textBoxSourceFolder.Text = currentSourceFolder;
            currentTargetFolder = Properties.Settings.Default.targetFolder;
            textBoxTargetFolder.Text = currentTargetFolder;
        }

        private void buttonStart_MouseClick(object sender, MouseEventArgs e) {
            StartProcess();
        }

        private void textBoxSourceFolder_MouseDoubleClick(object sender, MouseEventArgs e) {
            PickSourceFolder();
        }

        private void PickSourceFolder() {
            string thePickStr = String.Empty;
            currentSourceFolder = textBoxSourceFolder.Text.Trim();
            folderBrowserDialogPicker.SelectedPath = currentSourceFolder;
            DialogResult thePick = folderBrowserDialogPicker.ShowDialog();
            if (thePick == System.Windows.Forms.DialogResult.OK) {
                thePickStr = folderBrowserDialogPicker.SelectedPath.ToString();
                textBoxSourceFolder.Text = thePickStr;
                currentSourceFolder = thePickStr;

                if (textBoxTargetFolder.Text == "") {
                    textBoxTargetFolder.Text = currentSourceFolder;
                    currentTargetFolder = currentSourceFolder;
                }
            }
            CheckSourceStatus(currentSourceFolder);
            CheckTargetStatus(currentTargetFolder);
            CheckForExistingOutput();
        }

        private void textBoxTargetFolder_MouseDoubleClick(object sender, MouseEventArgs e) {
            PickTargetFolder();
        }

        private void PickTargetFolder() {
            string outputFolder;

            if (textBoxTargetFolder.Text == "") {
                outputFolder = textBoxSourceFolder.Text.Trim();
            } else {
                outputFolder = textBoxTargetFolder.Text.Trim();
            }

            folderBrowserDialogPicker.SelectedPath = outputFolder;
            DialogResult thePick = folderBrowserDialogPicker.ShowDialog();
            if (thePick == System.Windows.Forms.DialogResult.OK) {
                string thePickStr = folderBrowserDialogPicker.SelectedPath.ToString();
                textBoxTargetFolder.Text = thePickStr;
                currentTargetFolder = thePickStr;
            }
            CheckTargetStatus(currentTargetFolder);
            CheckForExistingOutput();
        }
        private void CheckSourceStatus(string theSourceFolder) {
            if (Directory.Exists(theSourceFolder)) {
                qtySources = NumberOfPDFSourceFilesHere(theSourceFolder);
                labelSourceFolder.Text = "Source Folder has " + qtySources.ToString() + " PDFs";
                labelSourceFolder.ForeColor = Color.Black;
            } else {
                labelSourceFolder.Text = "Source Folder Does Not Exist";
                labelSourceFolder.ForeColor = Color.Red;
            }
        }

        private void CheckTargetStatus(string _currentTargetFolder) {
            buttonStart.Enabled = false;
            labelTargetFolder.Text = "Target Folder Does Not Exist";
            labelTargetFolder.ForeColor = Color.Red;
            if (!_currentTargetFolder.Equals("")) {
                if (Directory.Exists(_currentTargetFolder)) {
                    if (qtySources > 0) {
                        buttonStart.Enabled = true;
                    }
                    labelTargetFolder.Text = "Target Folder Exists";
                    labelTargetFolder.ForeColor = Color.Black;
                }
            }
        }

        private void CheckForExistingOutput() {
            string[] targetCuts = null;
            if (currentTargetFolder == string.Empty) {
                return;
            }
            if (Directory.Exists(currentTargetFolder)) {
                try {
                    targetCuts = Directory.GetFiles(currentTargetFolder, "*" + outPutExtType);
                    if (targetCuts.Length == 0) { return; }
                    listViewSourcePDFs.SuspendLayout();
                    foreach (ListViewItem thisItem in listViewSourcePDFs.Items) {
                        String pdfName = Path.GetFileNameWithoutExtension(thisItem.SubItems[0].Text);
                        int cnt = targetCuts.Where(x => Path.GetFileNameWithoutExtension(x).StartsWith(pdfName + cutSuffixText, StringComparison.CurrentCultureIgnoreCase)).Count();
                        if (cnt > 0) {
                            thisItem.Checked = false;
                            thisItem.SubItems[1].Text = Convert.ToString(cnt) + "   Existing " + msgOutPutType;
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            ResizeListViewheaders();
            listViewSourcePDFs.ResumeLayout();
        }

        private void StartProcess() {
            string sourceFolder = currentSourceFolder;
            string targetFolder = currentTargetFolder;

            buttonStart.Enabled = false;
            buttonHalt.Enabled = true;
            labelStatus.Text = "Starting processing at " + sourceFolder + ".";
            listViewSourcePDFs.Enabled = false;

            int cntTotal = listViewSourcePDFs.CheckedItems.Count;
            progressBarConvert.Maximum = cntTotal * progTickMult;  // first mark means started
            progressBarConvert.Minimum = 0;
            progressBarConvert.Step = 1;
            progressBarConvert.Visible = true;
            progressBarConvert.Value = 1;  // show some progress

            List<string> SourcesList = new List<string>();
            foreach (ListViewItem thisItem in listViewSourcePDFs.CheckedItems) {
                String pdfName = sourceFolder + "/" + thisItem.SubItems[0].Text;
                SourcesList.Add(pdfName);
                thisItem.SubItems[1].Text = "Queued";
            }
            thisBackWrkARgs thisArg = new thisBackWrkARgs();
            thisArg.SourceList = SourcesList;
            thisArg.targetFolder = targetFolder;
            thisArg.cutSuffixText = cutSuffixText;
            thisArg.outPutExtType = outPutExtType;
            if (!backgroundWorker1.IsBusy) {
                backgroundWorker1.RunWorkerAsync(thisArg);
            }
        }

        private int NumberOfPDFSourceFilesHere(string folderName) {
            string[] sourcePDFS = null;
            try {
                listViewSourcePDFs.SuspendLayout();
                listViewSourcePDFs.Items.Clear();
                sourcePDFS = Directory.GetFiles(folderName, "*.pdf");
                foreach (string item in sourcePDFS) {
                    string itemName = Path.GetFileName(item);
                    string[] subItem = new string[2];
                    subItem[0] = itemName;
                    subItem[1] = msgNotProcessed;
                    ListViewItem thisItem = new ListViewItem(subItem);
                    thisItem.Checked = true;
                    listViewSourcePDFs.Items.Add(thisItem);
                }
                listViewSourcePDFs.ResumeLayout();
            } catch (Exception ex) {
                MessageBox.Show("Exception caught at NumberOfPDFSourceFilesHere\n" + ex.Message);
            }

            if (!(sourcePDFS == null)) {
                return sourcePDFS.Length;
            }
            
            else
            {
                return 0;
            }
        }

        private void textBoxSourceFolder_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {

                e.Effect = DragDropEffects.All;

            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxSourceFolder_DragDrop(object sender, DragEventArgs e) {

            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (Directory.Exists(files[0])) {
                    textBoxSourceFolder.Text = files[0];
                    labelSourceFolder.Text = "Source Folder has " + NumberOfPDFSourceFilesHere(files[0]) + " PDFs";
                    if (textBoxTargetFolder.Text == "") {
                        textBoxTargetFolder.Text = files[0];
                        currentSourceFolder = files[0];
                        CheckSourceStatus(currentSourceFolder);
                        CheckTargetStatus(currentTargetFolder);
                        CheckForExistingOutput();
                        ResizeListViewheaders();
                    }
                }
            }
        }

        private void textBoxTargetFolder_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.All;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxTargetFolder_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (Directory.Exists(files[0])) {
                    textBoxTargetFolder.Text = files[0];
                    currentTargetFolder = files[0];
                    CheckTargetStatus(currentTargetFolder);
                    CheckForExistingOutput();
                    ResizeListViewheaders();
                }
            }
        }

        private void buttonHalt_MouseClick(object sender, MouseEventArgs e) {
            backgroundWorker1.CancelAsync();
            labelStatus.Text = "Will Cancel After => " + labelStatus.Text;
        }

        private void buttonGoSource_MouseClick(object sender, MouseEventArgs e) {
            System.Diagnostics.Process.Start("explorer.exe", currentSourceFolder);
        }

        private void buttonGoTarget_MouseClick(object sender, MouseEventArgs e) {
            System.Diagnostics.Process.Start("explorer.exe", currentTargetFolder);
        }

        private void textBoxSourceFolder_TextChanged(object sender, EventArgs e) {
            currentSourceFolder = textBoxSourceFolder.Text.Trim();
            CheckSourceStatus(currentSourceFolder);
            CheckTargetStatus(currentTargetFolder);
            CheckForExistingOutput();
        }

        private void textBoxTargetFolder_TextChanged(object sender, EventArgs e) {
            currentTargetFolder = textBoxTargetFolder.Text.Trim();
            CheckTargetStatus(currentTargetFolder);
            CheckForExistingOutput();
        }

        private void FormPDFtoWhatever_ResizeEnd(object sender, EventArgs e) {
            ResizeListViewheaders();
        }

        private void ResizeListViewheaders() {
            for (int i = 0; i < listViewSourcePDFs.Columns.Count - 1; i++) {
                listViewSourcePDFs.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewSourcePDFs.Columns[listViewSourcePDFs.Columns.Count - 1].Width = -2;
            }
            reportChecked();
        }

        private void listViewSourcePDFs_ItemChecked(object sender, ItemCheckedEventArgs e) {
            reportChecked();
        }

        private void reportChecked() {
            if (Directory.Exists(currentSourceFolder)) {
                string qtyT = listViewSourcePDFs.Items.Count.ToString();
                string qtyP = listViewSourcePDFs.CheckedItems.Count.ToString();
                this.labelSourceFolder.Text = "Source Folder has " + qtyT + " PDFs with " + qtyP + " items checked for processing.";
            }
            progressBarConvert.Visible = false;
            progressBarConvert.Value = 0;
            buttonStart.Enabled = false;
            if (listViewSourcePDFs.CheckedItems.Count > 0 && Directory.Exists(currentTargetFolder)) { buttonStart.Enabled = true; }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            thisBackWrkARgs thisArg = e.Argument as thisBackWrkARgs;
            int inDx = 0;
            foreach (string fullPDFpathname in thisArg.SourceList) {
                if (File.Exists(fullPDFpathname)) {
                    backgroundWorker1.ReportProgress(inDx, Path.GetFileName(fullPDFpathname));
                    PDFtoWhateverC.ConvertPDF.ConvertPDFToMultipleImagesAKS(fullPDFpathname, thisArg.targetFolder, thisArg.cutSuffixText, thisArg.outPutExtType);
                    inDx++;
                } else  // source file became missing on the way!
                  {
                    // negative progress signals a missing file but inDxZeroMissing used for indx found missing
                    if (inDx == 0) {
                        backgroundWorker1.ReportProgress(inDxZeroMissing, Path.GetFileName(fullPDFpathname));
                    } else {
                        backgroundWorker1.ReportProgress(-inDx, Path.GetFileName(fullPDFpathname));
                    }
                    inDx++;
                }

                //if cancellation is pending, cancel work.  
                if (backgroundWorker1.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void ReportOnCancel() {
            foreach (ListViewItem thisItem in listViewSourcePDFs.CheckedItems) {
                if (thisItem.SubItems[1].Text == msgInProcess) {
                    string _PDFname = Path.GetFileNameWithoutExtension(thisItem.SubItems[0].Text.ToLower());
                    int cnt = QtyOfJPGS(_PDFname, currentTargetFolder);
                    thisItem.SubItems[1].Text = msgProcessedInto + Convert.ToString(cnt) + " " + msgOutPutType;
                    ;
                }
                if (thisItem.SubItems[1].Text == "Queued") {
                    thisItem.SubItems[1].Text = "Canceled";
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                labelStatus.Text = "Canceled .... The processing is incomplete.";
                progressBarConvert.Value = 0;
                progressBarConvert.Visible = false;
                ReportOnCancel();
            } else if (e.Error != null) {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
                progressBarConvert.Value = 0;
                progressBarConvert.Visible = false;
            } else {
                thisBackWrkARgs thisArg = e.Result as thisBackWrkARgs;
                progressBarConvert.Visible = true;
                progressBarConvert.Value = progressBarConvert.Maximum;
                labelStatus.Text = "Done Creating PDF cut splits";
                labelStatus.Font = new Font(labelStatus.Font, FontStyle.Bold);
                string _PDFname = Path.GetFileNameWithoutExtension(listViewSourcePDFs.CheckedItems[listViewSourcePDFs.CheckedItems.Count - 1].SubItems[0].Text.ToLower());
                int cnt = QtyOfJPGS(_PDFname, currentTargetFolder);
                if (!listViewSourcePDFs.CheckedItems[listViewSourcePDFs.CheckedItems.Count - 1].SubItems[1].Text.Equals(msgFileMissing)) {
                    listViewSourcePDFs.CheckedItems[listViewSourcePDFs.CheckedItems.Count - 1].SubItems[1].Text = msgProcessedInto + Convert.ToString(cnt) + " " + msgOutPutType;
                }
            }




            /// The problem solved by this is that the progress bar needs to reach 100% and then go away
            /// by itself. There is an animation delay going on in that that bar step to 100% but the
            /// progressbar visible command closes out the bar before that animation duration gets anywhere.
            /// This results in no progress shown for the last step.  A sleep thread does
            /// not work because the progress bar animation up to that 100% sleeps in the same thread.
            if (progressBarConvert.Value == progressBarConvert.Maximum) {
                DateTime Tthen = DateTime.Now;
                do {
                    Application.DoEvents();
                } while (Tthen.AddSeconds(1) > DateTime.Now);
                progressBarConvert.Visible = false;
            }

            buttonStart.Enabled = true;
            buttonHalt.Enabled = false;
            listViewSourcePDFs.Enabled = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            int indX = e.ProgressPercentage;
            string f = e.UserState.ToString();
            int topRange = listViewSourcePDFs.CheckedItems.Count - 1;

            if (indX >= 0)  // some result
            {
                if (indX == 0) {
                    listViewSourcePDFs.CheckedItems[indX].SubItems[1].Text = msgInProcess;
                } else {
                    string _PDFname = Path.GetFileNameWithoutExtension(listViewSourcePDFs.CheckedItems[indX - 1].SubItems[0].Text.ToLower());
                    int cnt = QtyOfJPGS(_PDFname, currentTargetFolder);
                    if (!listViewSourcePDFs.CheckedItems[indX - 1].SubItems[1].Text.Equals(msgFileMissing)) {
                        listViewSourcePDFs.CheckedItems[indX - 1].SubItems[1].Text = msgProcessedInto + Convert.ToString(cnt) + " " + msgOutPutType;
                    }
                    listViewSourcePDFs.CheckedItems[indX].SubItems[1].Text = msgInProcess;
                    progressBarConvert.Visible = true;
                    progressBarConvert.Value = (indX * progTickMult);
                }
            } else  // A negative index is being used to signal file was found missing.
              {
                if (indX > inDxZeroMissing) // ie not indx 0 found missing
                {
                    listViewSourcePDFs.CheckedItems[(-indX)].SubItems[1].Text = msgFileMissing;
                } else  // indx 0 was found missing
                  {
                    listViewSourcePDFs.CheckedItems[0].SubItems[1].Text = msgFileMissing;
                }

            }
            labelStatus.Text = Convert.ToString(indX + 1) + " / " + (progressBarConvert.Maximum / progTickMult).ToString() + "  " + "Currently working on: " + f;
            labelStatus.Font = new Font(labelStatus.Font, FontStyle.Regular);
        }

        private void buttonBrowseSource_MouseClick(object sender, MouseEventArgs e) {
            PickSourceFolder();
        }

        private void buttonBrowseTarget_MouseClick(object sender, MouseEventArgs e) {
            PickTargetFolder();
        }

        private int QtyOfJPGS(string _PDFName, string _currentTargetFolder) {
            int cnt = 0;
            string[] targetCuts = null;
            if (_currentTargetFolder == string.Empty) {
                return cnt;
            }
            if (Directory.Exists(_currentTargetFolder)) {
                try {
                    targetCuts = Directory.GetFiles(_currentTargetFolder, "*" + outPutExtType);
                    if (targetCuts.Length == 0) { return 0; }
                    cnt = targetCuts.Where(x => Path.GetFileNameWithoutExtension(x).StartsWith(_PDFName + cutSuffixText, StringComparison.CurrentCultureIgnoreCase)).Count();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            return cnt;
        }

        public void CheckForGS() {
            // What you are looking for are this two registry keys:
            //HKEY_LOCAL_MACHINE\SOFTWARE\GPL Ghostscript
            //HKEY_LOCAL_MACHINE\SOFTWARE\AFPL Ghostscript
            //If Ghostscript is installed on the machine, you should find at least one of above.
            //Those keys contain installed Ghostscript version sub-keys...which contains string values which points to dll / exe file

            RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\GPL Ghostscript");
            if (Key != null) {
                MessageBox.Show("GhostScript Is Installed");
            } else {
                MessageBox.Show("GhostScript Is Not Installed");
            }
        }

        private void FormPDFtoWhatever_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default["sourceFolder"] = currentSourceFolder;
            Properties.Settings.Default["targetFolder"] = currentTargetFolder;
            Properties.Settings.Default.Save();
        }

        private void listViewSourcePDFs_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                ListView thisLV = (ListView)sender;
                String matchToThis = Path.GetFileNameWithoutExtension(thisLV.FocusedItem.Text) + cutSuffixText + "*" + outPutExtType;
                string[] targetCuts = null;
                targetCuts = Directory.GetFiles(currentTargetFolder, matchToThis);
                if (targetCuts.Length > 0) {
                    foreach (string fPName in targetCuts.Reverse()) {
                        System.Diagnostics.Process.Start("explorer.exe", fPName);
                    }
                }
            }
        }

        private void SetOutputType() {
            switch (comboBoxOutPutType.Text) {
                case ".jpg":
                    msgOutPutType = "JPGs";
                    outPutExtType = ".jpg";
                    break;
                case ".png":
                    msgOutPutType = "PNGs";
                    outPutExtType = ".png";
                    break;
                case ".gif":
                    msgOutPutType = "GIFs";
                    outPutExtType = ".gif";
                    break;
                case ".tif":
                    msgOutPutType = "TIFs";
                    outPutExtType = ".tif";
                    break;
                case ".bmp":
                    msgOutPutType = "BMPs";
                    outPutExtType = ".bmp";
                    break;
                default:
                    msgOutPutType = "JPGs";
                    outPutExtType = ".jpg";
                    break;
            }
            CheckSourceStatus(currentSourceFolder);
            CheckForExistingOutput();
        }

        private void comboBoxOutPutType_SelectedIndexChanged(object sender, EventArgs e) {
            SetOutputType();
        }

        private void buttonUnCheckAll_MouseClick(object sender, MouseEventArgs e) {
            // checkAllState used to be the button's text value which makked to a symbol
            // in a windows font. What remains is a dirty fix.
            switch (checkAllState) {
                case "O":
                    CheckListViewItems(listViewSourcePDFs, false);
                    checkAllState = "P";
                    toolTipSplitsMaker.SetToolTip(buttonUnCheckAll, "Check All");
                    break;
                case "P":
                    CheckListViewItems(listViewSourcePDFs, true);
                    checkAllState = "O";
                    toolTipSplitsMaker.SetToolTip(buttonUnCheckAll, "Uncheck All");
                    break;
                default:
                    CheckListViewItems(listViewSourcePDFs, true);
                    checkAllState = "O";
                    toolTipSplitsMaker.SetToolTip(buttonUnCheckAll, "Uncheck All");
                    break;
            }
        }

        private void CheckListViewItems(ListView _thisListView, bool _YesNo) {
            foreach (ListViewItem listItem in _thisListView.Items) {
                listItem.Checked = _YesNo;
            }
        }

        private void buttonRefresh_MouseClick(object sender, MouseEventArgs e) {
            UpDateTheDisplays();
        }

        private void buttonRefresh2_MouseClick(object sender, MouseEventArgs e) {
            UpDateTheDisplays();
        }

        internal void UpDateTheDisplays() {
            CheckSourceStatus(currentSourceFolder);
            CheckForExistingOutput();
            lastSelectedItem = null;
        }

        private void listViewSourcePDFs_SelectedIndexChanged(object sender, EventArgs e) {
            {
                ListView thisLV = (ListView)sender;
                if (thisLV.SelectedItems.Count > 0) {
                    ListViewItem thisItem = thisLV.SelectedItems[0];
                    lastSelectedItem = thisItem;
                    if (checkBoxSplitsViewer.Checked) {
                        SplitsViewThisListViewItem(thisItem);
                    }
                }
            }
        }

        private void SplitsViewThisListViewItem(ListViewItem thisItem) {
            string itemStat = thisItem.SubItems[1].Text; //== msgInProcess)
            if (itemStat != msgInProcess && itemStat != msgNotProcessed) {
                String matchToThis = Path.GetFileNameWithoutExtension(thisItem.SubItems[0].Text) + cutSuffixText + "*" + outPutExtType;
                if (thisSplitsViewer != null) {
                    thisSplitsViewer.Show();
                    thisSplitsViewer.DisplaySplitsMatchingThis(currentTargetFolder, matchToThis);
                } else {
                    thisSplitsViewer = new FormImageViewer(currentTargetFolder, matchToThis, this);
                    thisSplitsViewer.Show();
                }
            } else {
                // need to clear the viewer
                if (thisSplitsViewer != null) {
                    thisSplitsViewer.ClearPreviousContext();
                }
            }
        }

        private void RemoveOrClearImageViewer() {
            if (thisSplitsViewer != null) {
                thisSplitsViewer.Hide();
            }
        }

        private void checkBoxSplitsViewer_Click(object sender, EventArgs e) {
            switch (this.checkBoxSplitsViewer.Checked) {
                case true:  // user just turned on the viewer checkbox
                    RemoveOrClearImageViewer();

                    if (lastSelectedItem != null) {
                        listViewSourcePDFs.Focus();
                        lastSelectedItem.Selected = true;
                        SplitsViewThisListViewItem(lastSelectedItem);
                    }
                    break;
                case false: // user just turned off the viewer checkbox
                    RemoveOrClearImageViewer();
                    break;
                default:
                    break;
            }
        }

        private void doAnyArguments() {
            string cutsFolder = "-c";
            string splitsFolder = "-s";

            string[] args = Environment.GetCommandLineArgs();

            foreach (string item in args) {
                //MessageBox.Show(item);
                string cleanItem = item.Trim();
                if (cleanItem.Length > 2) {
                    if (cleanItem.StartsWith(cutsFolder)) {
                        string cFolder = cleanItem.Remove(0, cutsFolder.Length);
                        textBoxSourceFolder.Text = cFolder;
                    }
                    if (cleanItem.StartsWith(splitsFolder)) {
                        string sFolder = cleanItem.Remove(0, splitsFolder.Length);
                        textBoxTargetFolder.Text = sFolder;
                    }
                }
            }
        }


    }   // class end


    public class thisBackWrkARgs {
        public List<string> SourceList { get; set; }
        public string targetFolder { get; set; }
        public string cutSuffixText { get; set; }
        public string outPutExtType { get; set; }
    }




}
