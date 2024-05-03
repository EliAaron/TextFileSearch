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
        Task _searchTask;
        Task _timerTask;

        CancellationTokenSource _cancelSearch = null;

        bool _isSerching = false;
        object _syncRoot = new object();

        bool IsSearching
        {
            get { lock(_syncRoot) return _isSerching; }
            set { lock (_syncRoot) _isSerching = value; }
        }

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

            SetButtonIdleState();
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
            VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
            folderBrowserDialog.SelectedPath = txtParentFolderName.Text;
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtParentFolderName.Text = folderBrowserDialog.SelectedPath + "\\";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!IsSearching)
            {
                StartSearch();
            }
            else
            {
                StopSearch();
            }
        }

        void Search(
            string parentFolder,
            string[] fileExtentions,
            string searchPattern,
            bool matchCase,
            bool matchWholeWord,
            CancellationToken cancel)
        {
            if (!Directory.Exists(parentFolder))
            {
                MessageBox.Show(string.Format("The directory {0} dose not exist!", parentFolder));
                return;
            }

            if (fileExtentions.Length == 0)
            {
                MessageBox.Show("No file extensions!");
                return;
            }

            if (string.IsNullOrEmpty(searchPattern) || searchPattern.Length == 0)
            {
                MessageBox.Show("No text to search!");
                return;
            }

            int matchesFound = 0;

            this.BeginInvoke(new Action(() =>
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
                        this.BeginInvoke(new Action(() =>
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
                        }));

                        if (cancel.IsCancellationRequested) break;

                        newFileResult = TextSearcher.SearchTextInFile(file, searchPattern, matchCase, matchWholeWord);
                        if (newFileResult != null)
                        {
                            fileResults.Add(newFileResult);
                            matchesFound += newFileResult.LineResults.Count;
                        }
                    }
                }
                catch { }

                if (cancel.IsCancellationRequested) break;

                try
                {
                    // Add subfolders of the current folder. 
                    // The folders are retrived in an accending order bot are used last first (FIFO) so the order is reversed.
                    folderStack.AddRange(
                        Directory.EnumerateDirectories(folder, "*", SearchOption.TopDirectoryOnly).Reverse());

                }
                catch { }
            }

            this.BeginInvoke(new Action(() =>
            {
                if (IsSearching)
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

                    string status = string.Empty;
                    status = cancel.IsCancellationRequested ? "Search Canceled." : "Search Completed.";

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
            btnSearch.Text = "Start";
            btnSearch.BackColor = Color.Green;
            btnSearch.BackColor = Color.FromArgb(100, 255, 100);
            btnSearch.ForeColor = Color.FromArgb(0, 100, 0);
            btnBrowse.Enabled = true;
            cbMatchCase.Enabled = true;
            cbMatchWholeWord.Enabled = true;
            txtSearchPattern.Enabled = true;
            txtParentFolderName.Enabled = true;
            txtFileExtentions.Enabled = true;
        }

        private void SetButtonBusyState()
        {
            btnSearch.Text = "Stop";
            btnSearch.BackColor = Color.FromArgb(255, 100, 100);
            btnSearch.ForeColor = Color.FromArgb(96, 0, 0);
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

        private void StartSearch()
        {
            _cancelSearch = new CancellationTokenSource();
            IsSearching = true;

            _searchTask = Task.Factory.StartNew(() =>  Search(
                txtParentFolderName.Text,
                txtFileExtentions.Text.Split('|').Select(str => "." + str).ToArray(),
                txtSearchPattern.Text,
                cbMatchCase.Checked,
                cbMatchWholeWord.Checked,
                _cancelSearch.Token), 
                _cancelSearch.Token);

            Task.Factory.StartNew(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                while (IsSearching)
                {
                    Thread.Sleep(50);
                    this.BeginInvoke(new Action(() =>
                    {
                        int totalSec = (int)stopwatch.ElapsedMilliseconds / 1000;
                        int h = totalSec / 3600;
                        int m = (totalSec / 60) % 60;
                        int s = totalSec % 60;
                        txtSerchTime.Text = string.Format("{0:00}:{1:00}:{2:00}", h, m, s);
                    }));
                }
            },
            _cancelSearch.Token);
        }

        void StopSearch()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_searchTask != null)
            {
                _cancelSearch.Cancel();
                while (_searchTask.Status == TaskStatus.Running)
                {
                    Thread.Sleep(10);
                }
                _cancelSearch.Dispose();
                _searchTask.Dispose();
            }
            _searchTask = null;
            _cancelSearch = null;
            IsSearching = false;
            Cursor.Current = Cursors.Default;
        }
    }
}
