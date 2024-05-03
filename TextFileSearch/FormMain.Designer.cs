namespace TextFileSearch
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatchesFound = new System.Windows.Forms.TextBox();
            this.txtSerchTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.cbMatchCase = new System.Windows.Forms.CheckBox();
            this.txtSearchPattern = new System.Windows.Forms.TextBox();
            this.txtFileExtentions = new System.Windows.Forms.TextBox();
            this.txtParentFolderName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFillesWitheMatches = new System.Windows.Forms.TextBox();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.ColumnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLineText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmpty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(683, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(80, 29);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSearch.Location = new System.Drawing.Point(289, 142);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 55);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parent Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "File extentions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Text";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Matches Found";
            // 
            // txtMatchesFound
            // 
            this.txtMatchesFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatchesFound.Location = new System.Drawing.Point(682, 155);
            this.txtMatchesFound.Name = "txtMatchesFound";
            this.txtMatchesFound.ReadOnly = true;
            this.txtMatchesFound.Size = new System.Drawing.Size(81, 26);
            this.txtMatchesFound.TabIndex = 10;
            // 
            // txtSerchTime
            // 
            this.txtSerchTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerchTime.Location = new System.Drawing.Point(682, 126);
            this.txtSerchTime.Name = "txtSerchTime";
            this.txtSerchTime.ReadOnly = true;
            this.txtSerchTime.Size = new System.Drawing.Size(81, 26);
            this.txtSerchTime.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Serch Time";
            // 
            // cbMatchWholeWord
            // 
            this.cbMatchWholeWord.AutoSize = true;
            this.cbMatchWholeWord.Checked = global::TextFileSearch.Properties.Settings.Default.MatchWholeWord;
            this.cbMatchWholeWord.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TextFileSearch.Properties.Settings.Default, "MatchWholeWord", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbMatchWholeWord.Location = new System.Drawing.Point(6, 154);
            this.cbMatchWholeWord.Name = "cbMatchWholeWord";
            this.cbMatchWholeWord.Size = new System.Drawing.Size(155, 24);
            this.cbMatchWholeWord.TabIndex = 19;
            this.cbMatchWholeWord.Text = "Match whole word";
            this.cbMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // cbMatchCase
            // 
            this.cbMatchCase.AutoSize = true;
            this.cbMatchCase.Checked = global::TextFileSearch.Properties.Settings.Default.MatchCase;
            this.cbMatchCase.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TextFileSearch.Properties.Settings.Default, "MatchCase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbMatchCase.Location = new System.Drawing.Point(6, 125);
            this.cbMatchCase.Name = "cbMatchCase";
            this.cbMatchCase.Size = new System.Drawing.Size(110, 24);
            this.cbMatchCase.TabIndex = 18;
            this.cbMatchCase.Text = "Match case";
            this.cbMatchCase.UseVisualStyleBackColor = true;
            // 
            // txtSearchPattern
            // 
            this.txtSearchPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchPattern.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TextFileSearch.Properties.Settings.Default, "SearchPattern", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSearchPattern.Location = new System.Drawing.Point(113, 83);
            this.txtSearchPattern.Name = "txtSearchPattern";
            this.txtSearchPattern.Size = new System.Drawing.Size(567, 26);
            this.txtSearchPattern.TabIndex = 7;
            this.txtSearchPattern.Text = global::TextFileSearch.Properties.Settings.Default.SearchPattern;
            // 
            // txtFileExtentions
            // 
            this.txtFileExtentions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileExtentions.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TextFileSearch.Properties.Settings.Default, "FileExtentions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtFileExtentions.Location = new System.Drawing.Point(113, 48);
            this.txtFileExtentions.Name = "txtFileExtentions";
            this.txtFileExtentions.Size = new System.Drawing.Size(567, 26);
            this.txtFileExtentions.TabIndex = 5;
            this.txtFileExtentions.Text = global::TextFileSearch.Properties.Settings.Default.FileExtentions;
            // 
            // txtParentFolderName
            // 
            this.txtParentFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParentFolderName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TextFileSearch.Properties.Settings.Default, "ParentFolderName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtParentFolderName.Location = new System.Drawing.Point(113, 16);
            this.txtParentFolderName.Name = "txtParentFolderName";
            this.txtParentFolderName.Size = new System.Drawing.Size(567, 26);
            this.txtParentFolderName.TabIndex = 1;
            this.txtParentFolderName.Text = global::TextFileSearch.Properties.Settings.Default.ParentFolderName;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "State";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Results";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.Color.White;
            this.txtStatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtStatus.Location = new System.Drawing.Point(2, 232);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtStatus.Size = new System.Drawing.Size(764, 72);
            this.txtStatus.TabIndex = 20;
            this.txtStatus.WordWrap = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Filles Withe Matches";
            // 
            // txtFillesWitheMatches
            // 
            this.txtFillesWitheMatches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFillesWitheMatches.Location = new System.Drawing.Point(682, 184);
            this.txtFillesWitheMatches.Name = "txtFillesWitheMatches";
            this.txtFillesWitheMatches.ReadOnly = true;
            this.txtFillesWitheMatches.Size = new System.Drawing.Size(81, 26);
            this.txtFillesWitheMatches.TabIndex = 23;
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.AllowUserToAddRows = false;
            this.dataGridViewResults.AllowUserToDeleteRows = false;
            this.dataGridViewResults.AllowUserToResizeRows = false;
            this.dataGridViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFileName,
            this.ColumnLineNum,
            this.ColumnLineText,
            this.ColumnPath,
            this.ColumnEmpty});
            this.dataGridViewResults.Location = new System.Drawing.Point(2, 356);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowHeadersVisible = false;
            this.dataGridViewResults.RowHeadersWidth = 49;
            this.dataGridViewResults.Size = new System.Drawing.Size(764, 264);
            this.dataGridViewResults.TabIndex = 25;
            // 
            // ColumnFileName
            // 
            this.ColumnFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnFileName.HeaderText = "File Name";
            this.ColumnFileName.MinimumWidth = 120;
            this.ColumnFileName.Name = "ColumnFileName";
            this.ColumnFileName.ReadOnly = true;
            this.ColumnFileName.Width = 120;
            // 
            // ColumnLineNum
            // 
            this.ColumnLineNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnLineNum.HeaderText = "Line #";
            this.ColumnLineNum.MinimumWidth = 70;
            this.ColumnLineNum.Name = "ColumnLineNum";
            this.ColumnLineNum.ReadOnly = true;
            this.ColumnLineNum.Width = 81;
            // 
            // ColumnLineText
            // 
            this.ColumnLineText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnLineText.HeaderText = "Line Text";
            this.ColumnLineText.MinimumWidth = 200;
            this.ColumnLineText.Name = "ColumnLineText";
            this.ColumnLineText.ReadOnly = true;
            this.ColumnLineText.Width = 200;
            // 
            // ColumnPath
            // 
            this.ColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnPath.HeaderText = "Path";
            this.ColumnPath.MinimumWidth = 6;
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            this.ColumnPath.Width = 71;
            // 
            // ColumnEmpty
            // 
            this.ColumnEmpty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnEmpty.HeaderText = "";
            this.ColumnEmpty.MinimumWidth = 6;
            this.ColumnEmpty.Name = "ColumnEmpty";
            this.ColumnEmpty.ReadOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 623);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFillesWitheMatches);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtSearchPattern);
            this.Controls.Add(this.txtFileExtentions);
            this.Controls.Add(this.txtParentFolderName);
            this.Controls.Add(this.cbMatchWholeWord);
            this.Controls.Add(this.cbMatchCase);
            this.Controls.Add(this.txtSerchTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMatchesFound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBrowse);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Text File Search";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtParentFolderName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileExtentions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchPattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMatchesFound;
        private System.Windows.Forms.TextBox txtSerchTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbMatchWholeWord;
        private System.Windows.Forms.CheckBox cbMatchCase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFillesWitheMatches;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLineText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmpty;
    }
}

