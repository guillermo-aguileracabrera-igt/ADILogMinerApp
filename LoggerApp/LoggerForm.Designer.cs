
namespace LoggerApp
{
    partial class LoggerForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.totalRowLbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchGroupBox = new System.Windows.Forms.GroupBox();
            this.datesRangeRadioButtonCheckBox = new System.Windows.Forms.CheckBox();
            this.levelTextBox = new System.Windows.Forms.TextBox();
            this.search2DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.search1DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchFileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileNameCheckBox = new System.Windows.Forms.CheckBox();
            this.levelCheckBox = new System.Windows.Forms.CheckBox();
            this.textCheckBox = new System.Windows.Forms.CheckBox();
            this.limitMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.limitCheckBox = new System.Windows.Forms.CheckBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchMessageTextBox = new System.Windows.Forms.TextBox();
            this.insertTab = new System.Windows.Forms.TabPage();
            this.totalResultsLbl = new System.Windows.Forms.Label();
            this.resultsListView = new System.Windows.Forms.ListView();
            this.InsertGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tenResultsRadioButton = new System.Windows.Forms.RadioButton();
            this.hundredResultsRadioButton = new System.Windows.Forms.RadioButton();
            this.insert2DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.insert1DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.fileAttributesRadioButton = new System.Windows.Forms.RadioButton();
            this.allFilesRadioButton = new System.Windows.Forms.RadioButton();
            this.logDateCheckBox = new System.Windows.Forms.CheckBox();
            this.messageTextCheckBox = new System.Windows.Forms.CheckBox();
            this.patternCheckBox = new System.Windows.Forms.CheckBox();
            this.insertGoButton = new System.Windows.Forms.Button();
            this.testSearchButton = new System.Windows.Forms.Button();
            this.clearSearchButton = new System.Windows.Forms.Button();
            this.clearTableBtn = new System.Windows.Forms.Button();
            this.filePatternTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.searchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SearchGroupBox.SuspendLayout();
            this.insertTab.SuspendLayout();
            this.InsertGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.searchTab);
            this.tabControl1.Controls.Add(this.insertTab);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 518);
            this.tabControl1.TabIndex = 0;
            // 
            // searchTab
            // 
            this.searchTab.AutoScroll = true;
            this.searchTab.Controls.Add(this.totalRowLbl);
            this.searchTab.Controls.Add(this.dataGridView1);
            this.searchTab.Controls.Add(this.SearchGroupBox);
            this.searchTab.Location = new System.Drawing.Point(4, 22);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(772, 492);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "Search";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // totalRowLbl
            // 
            this.totalRowLbl.AutoSize = true;
            this.totalRowLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totalRowLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRowLbl.Location = new System.Drawing.Point(3, 476);
            this.totalRowLbl.Name = "totalRowLbl";
            this.totalRowLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.totalRowLbl.Size = new System.Drawing.Size(77, 13);
            this.totalRowLbl.TabIndex = 4;
            this.totalRowLbl.Text = " rows found.";
            this.totalRowLbl.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(8, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(758, 310);
            this.dataGridView1.TabIndex = 3;
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.Controls.Add(this.datesRangeRadioButtonCheckBox);
            this.SearchGroupBox.Controls.Add(this.levelTextBox);
            this.SearchGroupBox.Controls.Add(this.search2DateTimePicker);
            this.SearchGroupBox.Controls.Add(this.search1DateTimePicker);
            this.SearchGroupBox.Controls.Add(this.searchFileNameTextBox);
            this.SearchGroupBox.Controls.Add(this.fileNameCheckBox);
            this.SearchGroupBox.Controls.Add(this.levelCheckBox);
            this.SearchGroupBox.Controls.Add(this.textCheckBox);
            this.SearchGroupBox.Controls.Add(this.limitMaskedTextBox);
            this.SearchGroupBox.Controls.Add(this.limitCheckBox);
            this.SearchGroupBox.Controls.Add(this.clearBtn);
            this.SearchGroupBox.Controls.Add(this.searchBtn);
            this.SearchGroupBox.Controls.Add(this.searchMessageTextBox);
            this.SearchGroupBox.Location = new System.Drawing.Point(8, 20);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(758, 125);
            this.SearchGroupBox.TabIndex = 0;
            this.SearchGroupBox.TabStop = false;
            this.SearchGroupBox.Text = "Search existing records in the Database:";
            // 
            // datesRangeRadioButtonCheckBox
            // 
            this.datesRangeRadioButtonCheckBox.AutoSize = true;
            this.datesRangeRadioButtonCheckBox.Location = new System.Drawing.Point(256, 96);
            this.datesRangeRadioButtonCheckBox.Name = "datesRangeRadioButtonCheckBox";
            this.datesRangeRadioButtonCheckBox.Size = new System.Drawing.Size(89, 17);
            this.datesRangeRadioButtonCheckBox.TabIndex = 18;
            this.datesRangeRadioButtonCheckBox.Text = "Dates Range";
            this.datesRangeRadioButtonCheckBox.UseVisualStyleBackColor = true;
            // 
            // levelTextBox
            // 
            this.levelTextBox.Enabled = false;
            this.levelTextBox.Location = new System.Drawing.Point(121, 24);
            this.levelTextBox.MaxLength = 5;
            this.levelTextBox.Name = "levelTextBox";
            this.levelTextBox.Size = new System.Drawing.Size(100, 20);
            this.levelTextBox.TabIndex = 5;
            // 
            // search2DateTimePicker
            // 
            this.search2DateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.search2DateTimePicker.Enabled = false;
            this.search2DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.search2DateTimePicker.Location = new System.Drawing.Point(530, 93);
            this.search2DateTimePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.search2DateTimePicker.Name = "search2DateTimePicker";
            this.search2DateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.search2DateTimePicker.TabIndex = 16;
            this.search2DateTimePicker.Value = new System.DateTime(2024, 1, 31, 0, 0, 0, 0);
            // 
            // search1DateTimePicker
            // 
            this.search1DateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.search1DateTimePicker.Enabled = false;
            this.search1DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.search1DateTimePicker.Location = new System.Drawing.Point(392, 93);
            this.search1DateTimePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.search1DateTimePicker.Name = "search1DateTimePicker";
            this.search1DateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.search1DateTimePicker.TabIndex = 15;
            this.search1DateTimePicker.Value = new System.DateTime(2024, 1, 31, 0, 0, 0, 0);
            // 
            // searchFileNameTextBox
            // 
            this.searchFileNameTextBox.Enabled = false;
            this.searchFileNameTextBox.Location = new System.Drawing.Point(392, 60);
            this.searchFileNameTextBox.MaxLength = 50;
            this.searchFileNameTextBox.Name = "searchFileNameTextBox";
            this.searchFileNameTextBox.Size = new System.Drawing.Size(263, 20);
            this.searchFileNameTextBox.TabIndex = 14;
            // 
            // fileNameCheckBox
            // 
            this.fileNameCheckBox.AutoSize = true;
            this.fileNameCheckBox.Location = new System.Drawing.Point(256, 62);
            this.fileNameCheckBox.Name = "fileNameCheckBox";
            this.fileNameCheckBox.Size = new System.Drawing.Size(71, 17);
            this.fileNameCheckBox.TabIndex = 5;
            this.fileNameCheckBox.Text = "File name";
            this.fileNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // levelCheckBox
            // 
            this.levelCheckBox.AutoSize = true;
            this.levelCheckBox.Location = new System.Drawing.Point(6, 27);
            this.levelCheckBox.Name = "levelCheckBox";
            this.levelCheckBox.Size = new System.Drawing.Size(52, 17);
            this.levelCheckBox.TabIndex = 5;
            this.levelCheckBox.Text = "Level";
            this.levelCheckBox.UseVisualStyleBackColor = true;
            // 
            // textCheckBox
            // 
            this.textCheckBox.AutoSize = true;
            this.textCheckBox.Location = new System.Drawing.Point(256, 27);
            this.textCheckBox.Name = "textCheckBox";
            this.textCheckBox.Size = new System.Drawing.Size(47, 17);
            this.textCheckBox.TabIndex = 5;
            this.textCheckBox.Text = "Text";
            this.textCheckBox.UseVisualStyleBackColor = true;
            // 
            // limitMaskedTextBox
            // 
            this.limitMaskedTextBox.Enabled = false;
            this.limitMaskedTextBox.Location = new System.Drawing.Point(121, 62);
            this.limitMaskedTextBox.Mask = "09999";
            this.limitMaskedTextBox.Name = "limitMaskedTextBox";
            this.limitMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.limitMaskedTextBox.TabIndex = 13;
            this.limitMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // limitCheckBox
            // 
            this.limitCheckBox.AutoSize = true;
            this.limitCheckBox.Location = new System.Drawing.Point(6, 62);
            this.limitCheckBox.Name = "limitCheckBox";
            this.limitCheckBox.Size = new System.Drawing.Size(80, 17);
            this.limitCheckBox.TabIndex = 12;
            this.limitCheckBox.Text = "Limit results";
            this.limitCheckBox.UseVisualStyleBackColor = true;
            this.limitCheckBox.CheckedChanged += new System.EventHandler(this.limitCheckBox_CheckedChanged);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(677, 90);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 10;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Enabled = false;
            this.searchBtn.Location = new System.Drawing.Point(677, 27);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchMessageTextBox
            // 
            this.searchMessageTextBox.Enabled = false;
            this.searchMessageTextBox.Location = new System.Drawing.Point(392, 27);
            this.searchMessageTextBox.MaxLength = 50;
            this.searchMessageTextBox.Name = "searchMessageTextBox";
            this.searchMessageTextBox.Size = new System.Drawing.Size(263, 20);
            this.searchMessageTextBox.TabIndex = 7;
            // 
            // insertTab
            // 
            this.insertTab.AutoScroll = true;
            this.insertTab.Controls.Add(this.totalResultsLbl);
            this.insertTab.Controls.Add(this.resultsListView);
            this.insertTab.Controls.Add(this.InsertGroupBox);
            this.insertTab.Location = new System.Drawing.Point(4, 22);
            this.insertTab.Name = "insertTab";
            this.insertTab.Padding = new System.Windows.Forms.Padding(3);
            this.insertTab.Size = new System.Drawing.Size(772, 492);
            this.insertTab.TabIndex = 1;
            this.insertTab.Text = "Insert";
            this.insertTab.UseVisualStyleBackColor = true;
            // 
            // totalResultsLbl
            // 
            this.totalResultsLbl.AutoSize = true;
            this.totalResultsLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totalResultsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalResultsLbl.Location = new System.Drawing.Point(3, 476);
            this.totalResultsLbl.Name = "totalResultsLbl";
            this.totalResultsLbl.Size = new System.Drawing.Size(0, 13);
            this.totalResultsLbl.TabIndex = 2;
            this.totalResultsLbl.Visible = false;
            // 
            // resultsListView
            // 
            this.resultsListView.BackColor = System.Drawing.SystemColors.Info;
            this.resultsListView.GridLines = true;
            this.resultsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.resultsListView.HideSelection = false;
            this.resultsListView.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.resultsListView.Location = new System.Drawing.Point(8, 151);
            this.resultsListView.MultiSelect = false;
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(758, 322);
            this.resultsListView.TabIndex = 1;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            this.resultsListView.View = System.Windows.Forms.View.List;
            // 
            // InsertGroupBox
            // 
            this.InsertGroupBox.Controls.Add(this.groupBox1);
            this.InsertGroupBox.Controls.Add(this.insert2DateTimePicker);
            this.InsertGroupBox.Controls.Add(this.insert1DateTimePicker);
            this.InsertGroupBox.Controls.Add(this.messageTextBox);
            this.InsertGroupBox.Controls.Add(this.fileAttributesRadioButton);
            this.InsertGroupBox.Controls.Add(this.allFilesRadioButton);
            this.InsertGroupBox.Controls.Add(this.logDateCheckBox);
            this.InsertGroupBox.Controls.Add(this.messageTextCheckBox);
            this.InsertGroupBox.Controls.Add(this.patternCheckBox);
            this.InsertGroupBox.Controls.Add(this.insertGoButton);
            this.InsertGroupBox.Controls.Add(this.testSearchButton);
            this.InsertGroupBox.Controls.Add(this.clearSearchButton);
            this.InsertGroupBox.Controls.Add(this.clearTableBtn);
            this.InsertGroupBox.Controls.Add(this.filePatternTextBox);
            this.InsertGroupBox.Location = new System.Drawing.Point(8, 20);
            this.InsertGroupBox.Name = "InsertGroupBox";
            this.InsertGroupBox.Size = new System.Drawing.Size(758, 125);
            this.InsertGroupBox.TabIndex = 0;
            this.InsertGroupBox.TabStop = false;
            this.InsertGroupBox.Text = "Search log files in folder to be inserted in the Database:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tenResultsRadioButton);
            this.groupBox1.Controls.Add(this.hundredResultsRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(652, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 30);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // tenResultsRadioButton
            // 
            this.tenResultsRadioButton.AutoSize = true;
            this.tenResultsRadioButton.Location = new System.Drawing.Point(6, 7);
            this.tenResultsRadioButton.Name = "tenResultsRadioButton";
            this.tenResultsRadioButton.Size = new System.Drawing.Size(37, 17);
            this.tenResultsRadioButton.TabIndex = 13;
            this.tenResultsRadioButton.Text = "10";
            this.tenResultsRadioButton.UseVisualStyleBackColor = true;
            // 
            // hundredResultsRadioButton
            // 
            this.hundredResultsRadioButton.AutoSize = true;
            this.hundredResultsRadioButton.Location = new System.Drawing.Point(57, 7);
            this.hundredResultsRadioButton.Name = "hundredResultsRadioButton";
            this.hundredResultsRadioButton.Size = new System.Drawing.Size(43, 17);
            this.hundredResultsRadioButton.TabIndex = 14;
            this.hundredResultsRadioButton.Text = "100";
            this.hundredResultsRadioButton.UseVisualStyleBackColor = true;
            // 
            // insert2DateTimePicker
            // 
            this.insert2DateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.insert2DateTimePicker.Enabled = false;
            this.insert2DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.insert2DateTimePicker.Location = new System.Drawing.Point(376, 95);
            this.insert2DateTimePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.insert2DateTimePicker.Name = "insert2DateTimePicker";
            this.insert2DateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.insert2DateTimePicker.TabIndex = 3;
            this.insert2DateTimePicker.Value = new System.DateTime(2024, 1, 31, 0, 0, 0, 0);
            // 
            // insert1DateTimePicker
            // 
            this.insert1DateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.insert1DateTimePicker.Enabled = false;
            this.insert1DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.insert1DateTimePicker.Location = new System.Drawing.Point(236, 95);
            this.insert1DateTimePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.insert1DateTimePicker.Name = "insert1DateTimePicker";
            this.insert1DateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.insert1DateTimePicker.TabIndex = 3;
            this.insert1DateTimePicker.Value = new System.DateTime(2024, 1, 31, 0, 0, 0, 0);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Enabled = false;
            this.messageTextBox.Location = new System.Drawing.Point(236, 62);
            this.messageTextBox.MaxLength = 50;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(265, 20);
            this.messageTextBox.TabIndex = 12;
            // 
            // fileAttributesRadioButton
            // 
            this.fileAttributesRadioButton.AutoSize = true;
            this.fileAttributesRadioButton.Location = new System.Drawing.Point(6, 61);
            this.fileAttributesRadioButton.Name = "fileAttributesRadioButton";
            this.fileAttributesRadioButton.Size = new System.Drawing.Size(87, 17);
            this.fileAttributesRadioButton.TabIndex = 3;
            this.fileAttributesRadioButton.Text = "File attributes";
            this.fileAttributesRadioButton.UseVisualStyleBackColor = true;
            // 
            // allFilesRadioButton
            // 
            this.allFilesRadioButton.AutoSize = true;
            this.allFilesRadioButton.Location = new System.Drawing.Point(6, 27);
            this.allFilesRadioButton.Name = "allFilesRadioButton";
            this.allFilesRadioButton.Size = new System.Drawing.Size(57, 17);
            this.allFilesRadioButton.TabIndex = 3;
            this.allFilesRadioButton.Text = "All files";
            this.allFilesRadioButton.UseVisualStyleBackColor = true;
            // 
            // logDateCheckBox
            // 
            this.logDateCheckBox.AutoSize = true;
            this.logDateCheckBox.Enabled = false;
            this.logDateCheckBox.Location = new System.Drawing.Point(105, 98);
            this.logDateCheckBox.Name = "logDateCheckBox";
            this.logDateCheckBox.Size = new System.Drawing.Size(68, 17);
            this.logDateCheckBox.TabIndex = 3;
            this.logDateCheckBox.Text = "Log date";
            this.logDateCheckBox.UseVisualStyleBackColor = true;
            // 
            // messageTextCheckBox
            // 
            this.messageTextCheckBox.AutoSize = true;
            this.messageTextCheckBox.Enabled = false;
            this.messageTextCheckBox.Location = new System.Drawing.Point(105, 62);
            this.messageTextCheckBox.Name = "messageTextCheckBox";
            this.messageTextCheckBox.Size = new System.Drawing.Size(98, 17);
            this.messageTextCheckBox.TabIndex = 3;
            this.messageTextCheckBox.Text = "Text (message)";
            this.messageTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // patternCheckBox
            // 
            this.patternCheckBox.AutoSize = true;
            this.patternCheckBox.Enabled = false;
            this.patternCheckBox.Location = new System.Drawing.Point(105, 26);
            this.patternCheckBox.Name = "patternCheckBox";
            this.patternCheckBox.Size = new System.Drawing.Size(113, 17);
            this.patternCheckBox.TabIndex = 3;
            this.patternCheckBox.Text = "File name (pattern)";
            this.patternCheckBox.UseVisualStyleBackColor = true;
            // 
            // insertGoButton
            // 
            this.insertGoButton.Enabled = false;
            this.insertGoButton.Location = new System.Drawing.Point(652, 24);
            this.insertGoButton.Name = "insertGoButton";
            this.insertGoButton.Size = new System.Drawing.Size(100, 23);
            this.insertGoButton.TabIndex = 1;
            this.insertGoButton.Text = "Go";
            this.insertGoButton.UseVisualStyleBackColor = true;
            this.insertGoButton.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // testSearchButton
            // 
            this.testSearchButton.Enabled = false;
            this.testSearchButton.Location = new System.Drawing.Point(533, 58);
            this.testSearchButton.Name = "testSearchButton";
            this.testSearchButton.Size = new System.Drawing.Size(100, 23);
            this.testSearchButton.TabIndex = 11;
            this.testSearchButton.Text = "Test";
            this.testSearchButton.UseVisualStyleBackColor = true;
            this.testSearchButton.Click += new System.EventHandler(this.testSearchFilesBtn_Click);
            // 
            // clearSearchButton
            // 
            this.clearSearchButton.Location = new System.Drawing.Point(533, 24);
            this.clearSearchButton.Name = "clearSearchButton";
            this.clearSearchButton.Size = new System.Drawing.Size(100, 23);
            this.clearSearchButton.TabIndex = 10;
            this.clearSearchButton.Text = "Clear Search";
            this.clearSearchButton.UseVisualStyleBackColor = true;
            this.clearSearchButton.Click += new System.EventHandler(this.clearSearchBtn_Click);
            // 
            // clearTableBtn
            // 
            this.clearTableBtn.Location = new System.Drawing.Point(533, 94);
            this.clearTableBtn.Name = "clearTableBtn";
            this.clearTableBtn.Size = new System.Drawing.Size(100, 23);
            this.clearTableBtn.TabIndex = 9;
            this.clearTableBtn.Text = "Clear Log table";
            this.clearTableBtn.UseVisualStyleBackColor = true;
            this.clearTableBtn.Click += new System.EventHandler(this.clearTableBtn_Click);
            // 
            // filePatternTextBox
            // 
            this.filePatternTextBox.Enabled = false;
            this.filePatternTextBox.Location = new System.Drawing.Point(236, 24);
            this.filePatternTextBox.MaxLength = 50;
            this.filePatternTextBox.Name = "filePatternTextBox";
            this.filePatternTextBox.Size = new System.Drawing.Size(265, 20);
            this.filePatternTextBox.TabIndex = 6;
            // 
            // LoggerForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoggerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logger App";
            this.tabControl1.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            this.insertTab.ResumeLayout(false);
            this.insertTab.PerformLayout();
            this.InsertGroupBox.ResumeLayout(false);
            this.InsertGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.TabPage insertTab;
        private System.Windows.Forms.GroupBox SearchGroupBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label totalRowLbl;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.CheckBox limitCheckBox;
        private System.Windows.Forms.MaskedTextBox limitMaskedTextBox;
        private System.Windows.Forms.GroupBox InsertGroupBox;
        private System.Windows.Forms.Button testSearchButton;
        private System.Windows.Forms.Button clearSearchButton;
        private System.Windows.Forms.Button clearTableBtn;
        private System.Windows.Forms.TextBox filePatternTextBox;
        private System.Windows.Forms.Button insertGoButton;
        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.Label totalResultsLbl;
        private System.Windows.Forms.CheckBox fileNameCheckBox;
        private System.Windows.Forms.CheckBox levelCheckBox;
        private System.Windows.Forms.CheckBox textCheckBox;
        private System.Windows.Forms.CheckBox patternCheckBox;
        private System.Windows.Forms.CheckBox logDateCheckBox;
        private System.Windows.Forms.CheckBox messageTextCheckBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.RadioButton fileAttributesRadioButton;
        private System.Windows.Forms.RadioButton allFilesRadioButton;
        private System.Windows.Forms.TextBox searchFileNameTextBox;
        private System.Windows.Forms.DateTimePicker search1DateTimePicker;
        private System.Windows.Forms.DateTimePicker search2DateTimePicker;
        private System.Windows.Forms.DateTimePicker insert1DateTimePicker;
        private System.Windows.Forms.DateTimePicker insert2DateTimePicker;
        private System.Windows.Forms.TextBox levelTextBox;
        private System.Windows.Forms.TextBox searchMessageTextBox;
        private System.Windows.Forms.RadioButton hundredResultsRadioButton;
        private System.Windows.Forms.RadioButton tenResultsRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox datesRangeRadioButtonCheckBox;
    }
}

