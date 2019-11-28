using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

using Ookii.Dialogs;
using SHOpenFolderAndSelectItems;

namespace TextFileSearch
{
    public partial class FormMain : Form
    {
        VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
        Thread SearchThread;
        bool CancelSearch = false;

        public FormMain()
        {
            InitializeComponent();
            this.EnebleDoubleBuffer();
            this.MinimumSize = new Size(640, 460);

            dataGridViewResults.DefaultCellStyle.Font = new Font("Courier New", 9);

            dataGridViewResults.CellMouseDoubleClick += dataGridViewResults_CellMouseDoubleClick;

            Text += " v" + FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                .FileVersion;
        }

        void dataGridViewResults_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.Button != MouseButtons.Left) return;

            string fileName = (string)dataGridViewResults[3, e.RowIndex].Value;

            if (!File.Exists(fileName)) return;

            if (e.Button == MouseButtons.Left)
            {
                ShowSelectedInExplorer.FilesOrFolders(Path.GetDirectoryName(fileName), Path.GetFileName(fileName));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            btnCancel.Enabled = false;
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            StopSearch();
            Properties.Settings.Default.Save();
            base.OnClosing(e);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = txtParentFolderName.Text;
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtParentFolderName.Text = folderBrowserDialog.SelectedPath + "\\";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchThread = new Thread(() => Search());
            SearchThread.Start();
        }

        void Search()
        {
            string parentFolder = string.Empty;
            string[] fileExtentions = new string[0];
            string searchPattern = string.Empty;
            bool matchCase = true;
            bool matchWholeWord = true;
            bool cancelSearch = false;
            Stopwatch stopwatch = Stopwatch.StartNew();

            this.Invoke(new Action(() =>
            {
                parentFolder = txtParentFolderName.Text;
                fileExtentions = txtFileExtentions.Text.Split('|').Select(str => "." + str).ToArray();
                searchPattern = txtSearchPattern.Text;
                matchCase = cbMatchCase.Checked;
                matchWholeWord = cbMatchWholeWord.Checked;
                cancelSearch = CancelSearch = false;
            }));

            if (!Directory.Exists(parentFolder))
            {
                MessageBox.Show(string.Format("The directory {0} dose not exist!", parentFolder));
                return;
            }

            if (fileExtentions.Length == 0)
            {
                MessageBox.Show("No file extentions!");
                return;
            }

            if (string.IsNullOrEmpty(searchPattern) || searchPattern.Length == 0)
            {
                MessageBox.Show("No text to search!");
                return;
            }

            int matchesFound = 0;

            this.Invoke(new Action(() =>
            {
                SetButtonBusyState();
                txtMatchesFound.Clear();
                txtStatus.Clear();
                txtStatus.Text = "Searching...";
                dataGridViewResults.Rows.Clear();
            }));

            List<FileResult> fileResults = new List<FileResult>();
            FileResult newFileResult = null;

            //MatchedFiles = new List<string>(); // Gathers all the matches. Currently its not used.
            //List<string> newMatches = new List<string>(); // Holds the new matches of the currently searced foldr.
            List<string> folderStack = new List<string>(); // The folders to be searched. used as a stack - 
                                                           // after the folder at the top of the stack is searched, 
                                                           // it is removed and its subfolders are added to the top of the stack.
                                                           // When the stack is empty, the search is done.

            // Add root folder.
            folderStack.Add(parentFolder);

            while (folderStack.Count > 0)
            {
                string folder = folderStack[folderStack.Count - 1];
                folderStack.RemoveAt(folderStack.Count - 1);

                try
                {
                    string[] files =
                        Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                        .Where(s => fileExtentions.Where(ft => s.EndsWith(ft)).Count() > 0)
                        .ToArray();

                    foreach (string file in files)
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (newFileResult != null)
                            {
                                string filePath = newFileResult.File;
                                string fileName = Path.GetFileName(filePath);
                                foreach (LineResult lineResult in newFileResult.LineResults)
                                {
                                    dataGridViewResults.Rows.Add(fileName, lineResult.LineNum, lineResult.Line.Trim(), filePath);
                                }

                            }

                            txtStatus.Text = "Searching... \r\n" + file;
                            txtMatchesFound.Text = matchesFound.ToString();
                            txtFillesWitheMatches.Text = fileResults.Count.ToString();
                            int totalSec = (int)stopwatch.ElapsedMilliseconds / 1000;
                            int h = totalSec / 3600;
                            int m = (totalSec / 60) % 60;
                            int s = totalSec % 60;
                            txtSerchTime.Text = string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
                            cancelSearch = CancelSearch;
                        }));

                        if (cancelSearch) break;

                        newFileResult = TextSearcher.SearchTextInFile(file, searchPattern, matchCase, matchWholeWord);
                        if (newFileResult != null)
                        {
                            fileResults.Add(newFileResult);
                            matchesFound += newFileResult.LineResults.Count;
                        }
                    }
                }
                catch { }

                if (cancelSearch) break;

                try
                {
                    // Add subfolders of the current folder. 
                    // The folders are retrived in an accending order bot are used last first (FIFO) so the order is reversed.
                    folderStack.AddRange(
                        Directory.EnumerateDirectories(folder, "*", SearchOption.TopDirectoryOnly).Reverse());

                }
                catch { }
            }

            this.Invoke(new Action(() =>
            {
                if (SearchThread.IsAlive)
                {
                    if (newFileResult != null)
                    {
                        string filePath = newFileResult.File;
                        string fileName = Path.GetFileName(filePath);
                        foreach (LineResult lineResult in newFileResult.LineResults)
                        {
                            dataGridViewResults.Rows.Add(fileName, lineResult.LineNum, lineResult.Line.Trim(), filePath);
                        }
                    }

                    // Update state: search canceld\completed, total time, matches found.
                    txtMatchesFound.Text = matchesFound.ToString();
                    txtFillesWitheMatches.Text = fileResults.Count.ToString();
                    int totalSec = (int)stopwatch.ElapsedMilliseconds / 1000;
                    int h = totalSec / 3600;
                    int m = (totalSec / 60) % 60;
                    int s = totalSec % 60;
                    txtSerchTime.Text = string.Format("{0:00}:{1:00}:{2:00}", h, m, s);

                    string status = string.Empty;
                    if (CancelSearch)
                        status = "Search Canceled.";
                    else
                        status = "Search Compleated.";

                    status += string.Format(
                            " {0} matches found. Total time {1}",
                            txtMatchesFound.Text, txtSerchTime.Text);

                    txtStatus.Text = status;
                    dataGridViewResults.Refresh();
                }
                
                SetButtonIdleState();

            }));
            
        }

        private void SetButtonIdleState()
        {
            btnSearch.Enabled = true;
            btnCancel.Enabled = false;
            btnBrowse.Enabled = true;
            cbMatchCase.Enabled = true;
            cbMatchWholeWord.Enabled = true;
            txtSearchPattern.Enabled = true;
            txtParentFolderName.Enabled = true;
            txtFileExtentions.Enabled = true;
        }

        private void SetButtonBusyState()
        {
            btnSearch.Enabled = false;
            btnCancel.Enabled = true;
            btnBrowse.Enabled = false;
            cbMatchCase.Enabled = false;
            cbMatchWholeWord.Enabled = false;
            txtSearchPattern.Enabled = false;
            txtFileExtentions.Enabled = false;
            txtParentFolderName.Enabled = false;
            txtSearchPattern.BackColor = Color.White;
            txtParentFolderName.BackColor = Color.White;
            txtFileExtentions.BackColor = Color.White;

        }

        void StopSearch()
        {
            CancelSearch = true;
            if (SearchThread != null)
            {
                while (SearchThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StopSearch();
        }
    }
}
