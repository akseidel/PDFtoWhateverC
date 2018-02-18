using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PDFtoWhateverC
{
    public partial class FormImageViewer : Form
    {
        public string cutSuffixText = "_Page-";
        string outPutExtType;
        string _PDFName;
        string _currentTargetFolder;
        string _matchToThis;
        private FormPDFtoWhatever _theCallingForm;

        //currentTargetFolder, matchToThis
        public FormImageViewer(string currentTargetFolder, string PDFName, FormPDFtoWhatever theCallingForm)
        {
            InitializeComponent();
            _PDFName = PDFName;
            _matchToThis = PDFName;
            _currentTargetFolder = currentTargetFolder;
            _theCallingForm = theCallingForm;
            DisplaySplitsMatchingThis(_currentTargetFolder, _PDFName);       
        }

        internal void ClearPreviousContext()
        {
            listViewCuts.Clear();
            Text = "Splits Manager";
            pictureBoxCutSplit.Image = null;
        }


        internal int NumberOfImagesThisCut(string currentTargetFolder, string matchToThis)
        {
            string[] targetCuts = null;
            if (Directory.Exists(currentTargetFolder))
            {
                targetCuts = Directory.GetFiles(currentTargetFolder, matchToThis);
                return targetCuts.Length;
            }
            else
            {
                return 0;
            }
        }
        
        internal void DisplaySplitsMatchingThis(string currentTargetFolder, string matchToThis)
        {
            ClearPreviousContext();
            _matchToThis = matchToThis;
            outPutExtType = Path.GetExtension(matchToThis);
            string qtyImg = NumberOfImagesThisCut( currentTargetFolder,  matchToThis).ToString();

            this.Text = "Collecting " + qtyImg + " Thumbnails For =>  " + matchToThis ;
            this.TopMost = true;
            bkwImageSplits thisArg = new bkwImageSplits();
            thisArg.currentTargetFolder = currentTargetFolder;
            thisArg.matchToThis = matchToThis;
            if (!backgroundWorkerGetSplits.IsBusy)
            {
                backgroundWorkerGetSplits.RunWorkerAsync(thisArg);
            }
        }

        private void listViewCuts_SelectedIndexChanged(object sender, EventArgs e)
        {
            String fname = ImageFileNameAtCurrentListViewSelection(sender);
            if (fname != string.Empty)
            {
                // Trying not to keep the file open. Passing the process through the GetThumbnailImage method
                // creates a copy of the image without a file pointer back to the file. That way the file is not
                // kept open and can be deleted.
                //
                // In hindsight this way is wrong. The result is not properly scalable and looks like crap.
                //
                //   String _fname = _currentTargetFolder + "\\" + fname  + outPutExtType;
                //   Image cutI = new Bitmap(_fname);
                //   this.pictureBoxCutSplit.Image = cutI.GetThumbnailImage(cutI.Width, cutI.Height, null, new IntPtr());                
                //   cutI.Dispose();

                // This is the way Microsoft publishes as the way to avoid file locking. The image is scalable.
                FileStream fs;
                String _fname = Path.Combine(_currentTargetFolder,( fname + outPutExtType));
                fs = new System.IO.FileStream(_fname, FileMode.Open, FileAccess.Read);
                this.pictureBoxCutSplit.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }
        }

        private String ImageFileNameAtCurrentListViewSelection(object thisSender)
        {
            ListView thisLV = (ListView)thisSender;
            if (thisLV.SelectedIndices.Count <= 0)
            {
                return string.Empty;
            }
            int intselectedindex = thisLV.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String fname =  thisLV.Items[intselectedindex].Text ;
                return fname;
            }
            return string.Empty;
        }
        
        private void backgroundWorkerGetSplits_DoWork(object sender, DoWorkEventArgs e)
        {
            bkwImageSplits thisArg = e.Argument as bkwImageSplits;
            ImageList cutsImages = new ImageList();
            double ASPR = 1.0;
            string[] targetCuts = null;
            listViewCuts.SuspendLayout();
            targetCuts = Directory.GetFiles(thisArg.currentTargetFolder, thisArg.matchToThis);
            if (targetCuts.Length > 0)
            {
                foreach (string fPName in targetCuts)
                {
                    try
                    {
                        //MessageBox.Show(fPName);
                        
                        // Trying not to keep the file open. Passing the process through the GetThumbnailImage method
                        // creates a copy of the image without a file pointer back to the file. That way the file is not
                        // kept open and can be deleted.
                        Image cutI = Image.FromFile(fPName);

                        int thumbHt;
                        int thumbWd;

                        if (cutI.Width <= cutI.Height)
                        {
                            // will control for height normalized to 256, width being a fraction of height
                            // will automatically be less than 256
                            ASPR = (double)cutI.Width / (double)cutI.Height;
                            thumbHt = 256;
                            thumbWd = (int)(256 * ASPR);
                        }
                        else
                        {
                            // will control for width normalized to 256, height being a fraction of width
                            // will automatically be less than 256

                            // ASPR being negative wil be used to signal landscape later on

                            ASPR = -(double)cutI.Height / (double)cutI.Width  ;
                            thumbWd = 256;
                            thumbHt = (int)(256 * (-ASPR));
                        }

                        // format is GetThumbnailImage(thumbWidth,thumbHeight)
                        Image imgThumb = cutI.GetThumbnailImage(thumbWd, thumbHt, null, new IntPtr());
                        cutsImages.Images.Add(Path.GetFileNameWithoutExtension(fPName), imgThumb);
                        cutI.Dispose();

                   
                   // This here is another way, maybe better.     
                   //     FileStream fs;
                   //     fs = new System.IO.FileStream(fPName, FileMode.Open, FileAccess.Read);
                   //     Image imgThumb = System.Drawing.Image.FromStream(fs);
                   //     cutsImages.Images.Add(Path.GetFileNameWithoutExtension(fPName), imgThumb);
                   //     fs.Close();
                 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
            bkwImageSplits returnArgs = new bkwImageSplits();
            returnArgs.cutsImages = cutsImages;
            returnArgs.currentTargetFolder = thisArg.currentTargetFolder;
            returnArgs.matchToThis = thisArg.matchToThis;
            returnArgs.ASPR = ASPR; // The last image APSR is what will be passed on. Note that neg. means landscape 

            e.Result = returnArgs;
        }

        private void backgroundWorkerGetSplits_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bkwImageSplits theResult = e.Result as bkwImageSplits;

            ImageList cutsImages = theResult.cutsImages;

            ClearPreviousContext();
            
            int baseSF = 256;
            double ASPR = theResult.ASPR;
            
            if (ASPR > 0)
            { // portrait
                cutsImages.ImageSize = new Size((int)((double)baseSF * ASPR), baseSF);
            }
            else
            { // landscape
                cutsImages.ImageSize = new Size(baseSF, (int)((double)baseSF * (- ASPR)));
            }

            listViewCuts.LargeImageList = cutsImages;

            for (int j = 0; j < cutsImages.Images.Count; j++)
            {
                string[] arr = new String[1];
                arr[0] = cutsImages.Images.Keys[j];
                ListViewItem item = new ListViewItem(arr);
                item.ImageIndex = j;
                listViewCuts.Items.Add(item);
            }

            UpdateTitleForListContent(theResult.matchToThis);

            listViewCuts.Items[0].Focused = true;
            listViewCuts.ResumeLayout();
            listViewCuts.Items[0].Selected = true;
            Activate();  // Make form active if had been called so that esc key can dismiss.
        }

        private void UpdateTitleForListContent(String matchToThis)
        {
            int cntInList = this.listViewCuts.Items.Count;
            if (cntInList == 0)
            // special case where the last one was deleted
            {
                ClearPreviousContext();
                this.Text = "      " + " No more image splits  " + matchToThis;
            } else
            // we are ok
            {
                this.Text = "      " + this.listViewCuts.Items.Count.ToString() + " image splits  " + matchToThis;
            }       
        }

        private void FormImageViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void DeleteSelectedImageSplits()
        {
            int cNdx = this.listViewCuts.SelectedItems[0].Index;
            ListView.SelectedListViewItemCollection selItemCol = this.listViewCuts.SelectedItems;
            String msg = String.Empty;
            foreach (ListViewItem item in selItemCol)
            {
                msg += item.SubItems[0].Text + "\n";
            }
            msg = "Delete:\n\n" + msg + "\nfrom:\n\n" + _currentTargetFolder + " ? ";
            DialogResult result;
            MessageBoxIcon iconToUse = MessageBoxIcon.Information;
            if (this.listViewCuts.Items.Count == selItemCol.Count)
            {
                msg = msg + "\n\nThis deletes ALL remaining image splits.";
                iconToUse = MessageBoxIcon.Warning;
            }

            result = MessageBox.Show(msg,
                                    "Confirm",
                                    MessageBoxButtons.OKCancel,
                                    iconToUse,
                                    MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    foreach (ListViewItem item in this.listViewCuts.SelectedItems)
                    {
                        String _fname = Path.Combine(_currentTargetFolder ,( item.SubItems[0].Text + outPutExtType));
                        File.Delete(_fname);
                        this.listViewCuts.SelectedItems[0].Remove();
                    }
                    if (this.listViewCuts.Items.Count != 0)
                    {
                        cNdx = Math.Min(cNdx, (this.listViewCuts.Items.Count - 1));
                        this.listViewCuts.Items[cNdx].Selected = true;
                        this.listViewCuts.Items[cNdx].Focused = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                UpdateTitleForListContent(_matchToThis);
                _theCallingForm.UpDateTheDisplays();
            }
        }

        private void listViewCuts_KeyUp(object sender, KeyEventArgs e)
        {
            // delete key is 46, backspace is 8 (delete on Mac), esc is 27
            if (e.KeyValue == 27)
            {
                Hide();
                return;
            }
            
            if (e.KeyValue == 46 || e.KeyValue == 8)
            {
                String fname = ImageFileNameAtCurrentListViewSelection(sender);
                String _fname = Path.Combine( _currentTargetFolder ,( ImageFileNameAtCurrentListViewSelection(sender) + outPutExtType));
                if (fname != string.Empty)
                {
                    DeleteSelectedImageSplits();
                }
            }           
        }

        private void FormImageViewer_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }

    public class bkwImageSplits
    {
        public ImageList cutsImages { get; set; }
        public string currentTargetFolder { get; set; }
        public string matchToThis { get; set; }
        public double ASPR { get; set; }
    }

}
