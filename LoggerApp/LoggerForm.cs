using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerApp
{
    public partial class LoggerForm : Form
    {
        private string path = ConfigurationManager.AppSettings["Path"];
        private static string connectionString;
        private const string removeChars = "*?&^$#@!()+,;’\'\\"; //:-<>
        private const string reduceMultiSpace = @"[ ]{2,}";
        private int rows = 0;
        private Dictionary<FileInfo, List<List<string>>> dic = new Dictionary<FileInfo, List<List<string>>>();
        private bool isDatesRangeRadioButtonChecked = false;
        private bool isTenResultsRadioButtonChecked = false;
        private bool isHundredResultsRadioButtonChecked = false;

        public LoggerForm(string connStr)
        {
            InitializeComponent();

            connectionString = connStr;

            //Search group
            levelCheckBox.CheckedChanged += new System.EventHandler(searchOptions_CheckedChanged);
            fileNameCheckBox.CheckedChanged += new System.EventHandler(searchOptions_CheckedChanged);
            datesRangeRadioButtonCheckBox.CheckedChanged += new System.EventHandler(searchOptions_CheckedChanged);
            textCheckBox.CheckedChanged += new System.EventHandler(searchOptions_CheckedChanged);

            searchMessageTextBox.KeyUp += searchMessageTextBox_KeyUp;
            levelTextBox.KeyUp += levelTextBox_KeyUp;
            searchFileNameTextBox.KeyUp += searchFileNameTextBox_KeyUp;
            search1DateTimePicker.ValueChanged += search1DateTimePicker_ValueChanged;
            search2DateTimePicker.ValueChanged += search2DateTimePicker_ValueChanged;
            limitCheckBox.CheckedChanged += limitCheckBox_CheckedChanged;

            search1DateTimePicker.MaxDate = DateTime.Today;
            search1DateTimePicker.Value = search1DateTimePicker.MaxDate;
            search2DateTimePicker.MaxDate = DateTime.Today;
            search2DateTimePicker.Value = search2DateTimePicker.MaxDate;



            //Insert group
            allFilesRadioButton.CheckedChanged += new System.EventHandler(insertOptions_CheckedChanged);
            fileAttributesRadioButton.CheckedChanged += new System.EventHandler(insertOptions_CheckedChanged);

            patternCheckBox.CheckedChanged += new System.EventHandler(insertSubOptions_CheckedChanged);
            messageTextCheckBox.CheckedChanged += new System.EventHandler(insertSubOptions_CheckedChanged);
            logDateCheckBox.CheckedChanged += new System.EventHandler(insertSubOptions_CheckedChanged);

            tenResultsRadioButton.Click += tenResultsRadioButton_Click;
            hundredResultsRadioButton.Click += hundredResultsRadioButton_Click;

            tenResultsRadioButton.CheckedChanged += new System.EventHandler(ResultsRadioButton_CheckedChanged);
            hundredResultsRadioButton.CheckedChanged += new System.EventHandler(ResultsRadioButton_CheckedChanged);

            filePatternTextBox.KeyUp += filePatternTextBox_KeyUp;
            messageTextBox.KeyUp += messageTextBox_KeyUp;
            insert1DateTimePicker.ValueChanged += insertDateTimePicker_ValueChanged;
            insert2DateTimePicker.ValueChanged += insertDateTimePicker_ValueChanged;

            insert1DateTimePicker.MaxDate = DateTime.Today;
            insert1DateTimePicker.Value = search1DateTimePicker.MaxDate;
            insert2DateTimePicker.MaxDate = DateTime.Today;
            insert2DateTimePicker.Value = search2DateTimePicker.MaxDate;

            allFilesRadioButton.Checked = true;
            tenResultsRadioButton.Enabled = true;
            hundredResultsRadioButton.Enabled = true;

            //Common
            this.FormClosed += LoggerForm_FormClosed;
        }

        //SEARCH
        private void searchOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (datesRangeRadioButtonCheckBox.Checked)
            {
                isDatesRangeRadioButtonChecked = true;
                search1DateTimePicker.Enabled = true;
                search2DateTimePicker.Enabled = true;

                if (search1DateTimePicker.Enabled && search2DateTimePicker.Enabled && search1DateTimePicker.Value <= search2DateTimePicker.Value && search2DateTimePicker.Value <= DateTime.Now)
                {
                    searchBtn.Enabled = true;
                }
                else
                {
                    searchBtn.Enabled = false;
                }
            }
            else
            {
                isDatesRangeRadioButtonChecked = false;
                search2DateTimePicker.Enabled = false;
            }

            if (textCheckBox.Checked)
            {
                searchMessageTextBox.Enabled = true;

                if (!String.IsNullOrWhiteSpace(searchMessageTextBox.Text) && !String.IsNullOrEmpty(searchMessageTextBox.Text))
                {
                    searchBtn.Enabled = true;
                }
                else
                {
                    searchBtn.Enabled = false;
                }
            }
            else
            {
                searchMessageTextBox.Enabled = false;
            }

            if(levelCheckBox.Checked)
            {
                levelTextBox.Enabled = true;

                if(!String.IsNullOrWhiteSpace(levelTextBox.Text) && !String.IsNullOrEmpty(levelTextBox.Text))
                {
                    searchBtn.Enabled = true;
                }
                else
                {
                    searchBtn.Enabled = false;
                }
            }
            else
            {
                levelTextBox.Enabled = false;
            }

            if(fileNameCheckBox.Checked)
            {
                searchFileNameTextBox.Enabled = true;

                if(!String.IsNullOrWhiteSpace(searchFileNameTextBox.Text) && !String.IsNullOrEmpty(searchFileNameTextBox.Text))
                {
                    searchBtn.Enabled = true;
                }
                else
                {
                    searchBtn.Enabled = false;
                }
            }
            else
            {
                searchFileNameTextBox.Enabled = false;
            }
        }

        private void limitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (limitCheckBox.Checked)
            {
                limitMaskedTextBox.Enabled = true;
            }
            else
            {
                limitMaskedTextBox.Enabled = false;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Proc_Search_ADI_Logs", conn))
                {
                    try
                    {
                        string msg = "";
                        DateTime? sDate1 = null;
                        DateTime? sDate2 = null;
                        string lvl = "";
                        string filename = "";
                        string limit = "0";
                        DataTable table = new DataTable();

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        if (textCheckBox.Checked && !String.IsNullOrEmpty(searchMessageTextBox.Text) && !String.IsNullOrWhiteSpace(searchMessageTextBox.Text))
                        {
                            msg = CleanString(searchMessageTextBox.Text.Trim());
                        }
                        if (datesRangeRadioButtonCheckBox.Checked && search1DateTimePicker.Enabled && search2DateTimePicker.Enabled && search1DateTimePicker.Value <= search2DateTimePicker.Value && search2DateTimePicker.Value <= DateTime.Now)
                        {
                            sDate1 = search1DateTimePicker.Value;
                            sDate2 = search2DateTimePicker.Value;
                        }
                        if(!datesRangeRadioButtonCheckBox.Checked && !search1DateTimePicker.Enabled && !search2DateTimePicker.Enabled)
                        {
                            sDate1 = null;
                            sDate2 = null;
                        }
                        if (levelCheckBox.Checked && !String.IsNullOrWhiteSpace(levelTextBox.Text) && !String.IsNullOrEmpty(levelTextBox.Text))
                        {
                            lvl = CleanString(levelTextBox.Text.Trim());
                        }
                        if (fileNameCheckBox.Checked && !String.IsNullOrWhiteSpace(searchFileNameTextBox.Text) && !String.IsNullOrEmpty(searchFileNameTextBox.Text))
                        {
                            filename = CleanString(searchFileNameTextBox.Text.Trim());
                        }
                        if (limitCheckBox.Checked && Int32.TryParse(limitMaskedTextBox.Text, out int num))
                        {
                            limit = limitMaskedTextBox.Text.Trim();
                        }

                        cmd.Parameters.AddWithValue("@Message", msg); // Message / Text
                        cmd.Parameters.AddWithValue("@Date1",sDate1); // Date
                        cmd.Parameters.AddWithValue("@Date2", sDate2); //Dates Range
                        cmd.Parameters.AddWithValue("@Level", lvl); // Level
                        cmd.Parameters.AddWithValue("@FileName", filename); // File name
                        cmd.Parameters.AddWithValue("@Limit", Convert.ToInt32(limit));

                        //string query = cmd.CommandText;

                        //foreach (SqlParameter p in cmd.Parameters)
                        //{
                        //    query = query.Replace(p.ParameterName, p.Value.ToString());
                        //}

                        //query.ToString();

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = table;
                            totalRowLbl.Text = table.Rows.Count.ToString() + " rows found.";
                            totalRowLbl.Visible = true;
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("No records found.", "Warning", MessageBoxButtons.OK);

                            if (dialogResult == DialogResult.OK)
                            {
                                clearSearchForm();
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        WriteToFile($"Exception --> searchBtn --> { ex.Message }");
                    }
                }
            }
        }

        private void searchMessageTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (textCheckBox.Checked && !String.IsNullOrWhiteSpace(searchMessageTextBox.Text) && !String.IsNullOrEmpty(searchMessageTextBox.Text))
            {
                searchBtn.Enabled = true;
            }
            else
            {
                searchBtn.Enabled = false;
            }
        }

        private void levelTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(levelCheckBox.Checked && !String.IsNullOrWhiteSpace(levelTextBox.Text) && !String.IsNullOrEmpty(levelTextBox.Text))
            {
                searchBtn.Enabled = true;
            }
            else
            {
                searchBtn.Enabled = false;
            }
        }

        private void searchFileNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(fileNameCheckBox.Checked && !String.IsNullOrWhiteSpace(searchFileNameTextBox.Text) && !String.IsNullOrEmpty(searchFileNameTextBox.Text))
            {
                searchBtn.Enabled = true;
            }
            else
            {
                searchBtn.Enabled = false;
            }
        }

        private void search1DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (datesRangeRadioButtonCheckBox.Checked)
            {
                if (search2DateTimePicker.Value < search1DateTimePicker.Value)
                {
                    searchBtn.Enabled = false;

                    return;
                }
            }

            searchBtn.Enabled = true;
        }

        private void search2DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (search2DateTimePicker.Value > DateTime.Now || search2DateTimePicker.Value < search1DateTimePicker.Value)
            {
                searchBtn.Enabled = false;

                return;
            }

            searchBtn.Enabled = true;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearSearchForm();
        }

        private void clearSearchForm()
        {
            searchMessageTextBox.Text = String.Empty;
            searchMessageTextBox.Enabled = false;
            searchFileNameTextBox.Text = String.Empty;
            searchFileNameTextBox.Enabled = false;
            levelTextBox.Text = String.Empty;
            levelTextBox.Enabled = false;
            search1DateTimePicker.Value = search1DateTimePicker.MaxDate;
            search1DateTimePicker.Enabled = false;
            search2DateTimePicker.Value = search2DateTimePicker.MaxDate;
            search2DateTimePicker.Enabled = false;
            textCheckBox.Checked = false;
            datesRangeRadioButtonCheckBox.Checked = false;
            isDatesRangeRadioButtonChecked = false;
            levelCheckBox.Checked = false;
            fileNameCheckBox.Checked = false;
            searchBtn.Enabled = false;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            limitCheckBox.Checked = false;
            limitMaskedTextBox.Text = String.Empty;
            limitMaskedTextBox.Enabled = false;
            totalRowLbl.Text = "";
            totalResultsLbl.Visible = false;
        }


        //INSERT
        private void insertOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (allFilesRadioButton.Checked)
            {
                patternCheckBox.Enabled = false;
                patternCheckBox.Checked = false;
                messageTextCheckBox.Enabled = false;
                messageTextCheckBox.Checked = false;
                logDateCheckBox.Enabled = false;
                logDateCheckBox.Checked = false;
                filePatternTextBox.Enabled = false;
                filePatternTextBox.Text = String.Empty;
                messageTextBox.Enabled = false;
                messageTextBox.Text = String.Empty;
                insert1DateTimePicker.Enabled = false;
                insert1DateTimePicker.Value = insert1DateTimePicker.MaxDate;
                insert2DateTimePicker.Enabled = false;
                insert2DateTimePicker.Value = insert2DateTimePicker.MaxDate;
                //testSearchButton.Enabled = true;
                clearSearchButton.Enabled = false;
                insertGoButton.Enabled = true;
                tenResultsRadioButton.Enabled = true;
                hundredResultsRadioButton.Enabled = true;
            }
            else if (fileAttributesRadioButton.Checked)
            {
                patternCheckBox.Enabled = true;
                messageTextCheckBox.Enabled = true;
                logDateCheckBox.Enabled = true;
                clearSearchButton.Enabled = true;
                //testSearchButton.Enabled = false;
                insertGoButton.Enabled = false;
                tenResultsRadioButton.Enabled = true;
                hundredResultsRadioButton.Enabled = true;
            }
        }

        private void insertSubOptions_CheckedChanged(Object sender, EventArgs e)
        {
            if(patternCheckBox.Checked)
            {
                filePatternTextBox.Enabled = true;
                tenResultsRadioButton.Enabled = true;
                hundredResultsRadioButton.Enabled = true;
            }
            else if(!patternCheckBox.Checked)
            {
                filePatternTextBox.Enabled = false;
                tenResultsRadioButton.Enabled = false;
                hundredResultsRadioButton.Enabled = false;
            }
            
            if(messageTextCheckBox.Checked)
            {
                messageTextBox.Enabled = true;
                tenResultsRadioButton.Enabled = true;
                hundredResultsRadioButton.Enabled = true;
            }
            else if(!messageTextCheckBox.Checked)
            {
                messageTextBox.Enabled = false;
                tenResultsRadioButton.Enabled = false;
                hundredResultsRadioButton.Enabled = false;
            }

            if(logDateCheckBox.Checked)
            {
                insert1DateTimePicker.Enabled = true;
                insert2DateTimePicker.Enabled = true;
                tenResultsRadioButton.Enabled = true;
                hundredResultsRadioButton.Enabled = true;
            }
            else if (!logDateCheckBox.Checked)
            {
                insert1DateTimePicker.Enabled = false;
                insert2DateTimePicker.Enabled = false;
                tenResultsRadioButton.Enabled = false;
                hundredResultsRadioButton.Enabled = false;
            }
        }

        private void tenResultsRadioButton_Click(object sender, EventArgs e)
        {
            if (tenResultsRadioButton.Checked && !isTenResultsRadioButtonChecked)
            {
                tenResultsRadioButton.Checked = false;
            }
            else
            {
                tenResultsRadioButton.Checked = true;
                isTenResultsRadioButtonChecked = false;
            }
        }

        private void hundredResultsRadioButton_Click(object sender, EventArgs e)
        {
            if (hundredResultsRadioButton.Checked && !isHundredResultsRadioButtonChecked)
            {
                hundredResultsRadioButton.Checked = false;
            }
            else
            {
                hundredResultsRadioButton.Checked = true;
                isHundredResultsRadioButtonChecked = false;
            }
        }

        private void ResultsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(tenResultsRadioButton.Checked)
            {
                isTenResultsRadioButtonChecked = true;
                testSearchButton.Enabled = true;
            }
            else if (hundredResultsRadioButton.Checked)
            {
                isHundredResultsRadioButtonChecked = true;
                testSearchButton.Enabled = true;
            }
            else
            {
                isTenResultsRadioButtonChecked = false;
                isHundredResultsRadioButtonChecked = false;
                testSearchButton.Enabled = false;
            }
        }

        private void clearSearchBtn_Click(object sender, EventArgs e)
        {
            clearInsertForm();
        }

        private void clearInsertForm()
        {
            allFilesRadioButton.Checked = true;
            fileAttributesRadioButton.Checked = false;
            patternCheckBox.Checked = false;
            patternCheckBox.Enabled = false;
            messageTextCheckBox.Checked = false;
            messageTextCheckBox.Enabled = false;
            logDateCheckBox.Checked = false;
            logDateCheckBox.Enabled = false;
            filePatternTextBox.Text = String.Empty;
            filePatternTextBox.Enabled = false;
            messageTextBox.Text = String.Empty;
            messageTextBox.Enabled = false;
            insert1DateTimePicker.Value = insert1DateTimePicker.MaxDate;
            insert1DateTimePicker.Enabled = false;
            insert2DateTimePicker.Value = insert2DateTimePicker.MaxDate;
            insert2DateTimePicker.Enabled = false;
            insertGoButton.Enabled = true;
            //testSearchButton.Enabled = true;
            resultsListView.Clear();
            totalResultsLbl.Visible = false;
            isHundredResultsRadioButtonChecked = false;
            isTenResultsRadioButtonChecked = false;
            tenResultsRadioButton.Checked = false;
            hundredResultsRadioButton.Checked = false;
        }

        private void clearTableBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will delete all records in the Log table. Are you sure you want to proceed?", "Delete records", MessageBoxButtons.OKCancel);

            if(dialogResult == DialogResult.OK)
            {
                ClearLogTable();
            }
        }

        private void filePatternTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (patternCheckBox.Checked && !String.IsNullOrWhiteSpace(filePatternTextBox.Text) && !String.IsNullOrEmpty(filePatternTextBox.Text))
            {
                //testSearchButton.Enabled = true;
                tenResultsRadioButton.Enabled = true;
                hundredResultsRadioButton.Enabled = true;
                insertGoButton.Enabled = true;
            }
            else
            {
                //testSearchButton.Enabled = false;
                tenResultsRadioButton.Enabled = false;
                hundredResultsRadioButton.Enabled = false;
                insertGoButton.Enabled = false;
            }
        }

        private void messageTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(messageTextCheckBox.Checked && !String.IsNullOrWhiteSpace(messageTextBox.Text) && !String.IsNullOrEmpty(messageTextBox.Text))
            {
                //testSearchButton.Enabled = true;
                tenResultsRadioButton.Enabled = true;
                hundredResultsRadioButton.Enabled = true;
                insertGoButton.Enabled = true;
            }
            else
            {
                //testSearchButton.Enabled = false;
                tenResultsRadioButton.Enabled = false;
                hundredResultsRadioButton.Enabled = false;
                insertGoButton.Enabled = false;
            }
        }

        private void insertDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (logDateCheckBox.Checked && (insert1DateTimePicker.Value < insert2DateTimePicker.Value) && insert2DateTimePicker.Value <= DateTime.Today)
            {
                //testSearchButton.Enabled = true;
                tenResultsRadioButton.Enabled = true;
                hundredResultsRadioButton.Enabled = true;
                insertGoButton.Enabled = true;
            }
            else
            {
                //testSearchButton.Enabled = false;
                tenResultsRadioButton.Enabled = false;
                hundredResultsRadioButton.Enabled = false;
                insertGoButton.Enabled = false;
            }
        }

        private void testSearchFilesBtn_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            Search(true);

            int rows = 0;

            if (resultsListView.SelectedItems.Count == 0)
            {
                foreach (KeyValuePair<FileInfo, List<List<string>>> d in dic)
                {
                    foreach (List<string> s in d.Value)
                    {
                        rows += ExecQueries(s);
                    }
                }
            }
            else
            {
                foreach (ListViewItem r in resultsListView.SelectedItems)
                {
                    foreach (KeyValuePair<FileInfo, List<List<string>>> d in dic)
                    {
                        if (r.Text.Contains(d.Key.Name))
                        {
                            foreach (List<string> s in d.Value)
                            {
                                rows += ExecQueries(s);
                            }
                        }
                    }
                }
            }

            MessageBox.Show($"{Math.Abs(rows).ToString()} rows inserted.");
            totalResultsLbl.Text = Math.Abs(rows).ToString() + " rows inserted.";
        }

        private int FillResultsListView(List<FileInfo> results = null, List<List<string>> queries = null)
        {
            int res = 0;

            if (results != null)
            {
                foreach (FileInfo file in results)
                {
                    resultsListView.Items.Add(file.FullName);
                }

                if (results.Count() > 0)
                {
                    insertGoButton.Enabled = true;
                    clearSearchButton.Enabled = true;
                }
                else
                {
                    insertGoButton.Enabled = false;
                    clearSearchButton.Enabled = true;
                }

                res = results.Count();
            }
            else if (queries != null)
            {
                foreach (List<string> query in queries)
                {
                    resultsListView.Items.Add(String.Join(" ", query));
                }

                if (queries.Count() > 0)
                {
                    insertGoButton.Enabled = true;
                    clearSearchButton.Enabled = true;
                }
                else
                {
                    insertGoButton.Enabled = false;
                    clearSearchButton.Enabled = false;
                }

                res = queries.Count();
            }

            return res;
        }



        //COMMON

        private void ClearLogTable()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("TRUNCATE TABLE [dbo].[Log]", conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Table cleared.");
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                        WriteToFile($"clearlogtable --> {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private List<FileInfo> GetFiles(DirectoryInfo directory, string name = "")
        {
            string cleanName = CleanString(name);
            List<FileInfo> files = new List<FileInfo>();

            try
            {
                if (cleanName == "")
                {
                    files = directory.GetFiles("*.log").ToList();
                }
                else
                {
                    files = directory.GetFiles(cleanName + "*.log").ToList();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(File not found. Check for the correct folder in App.config);
                WriteToFile($"Exception -> GetFiles -> { ex.Message }");
            }

            return files;
        }

        private Dictionary<FileInfo, List<List<string>>> SearchText(List<FileInfo> files, bool isInsert = false, string lineFilter = "", DateTime? date1 = null, DateTime? date2 = null)
        {
            StreamReader reader = null;
            Dictionary<FileInfo, List<List<string>>> results = new Dictionary<FileInfo, List<List<string>>>();

            if(files.Count < 1)
            {
                return new Dictionary<FileInfo, List<List<string>>>();
            }

            foreach (FileInfo f in files)
            {
                try
                {
                    List<List<string>> queries = new List<List<string>>();
                    reader = new StreamReader(f.FullName);

                    queries.AddRange(CreateQueries(reader, f.Name, lineFilter, date1, date2));

                    if (queries.Count > 0)
                    {
                        //WriteToFile("createQueries -> " + f.Name);
                        results.Add(f, queries);
                    }
                    //else
                    //{
                    //    MessageBox.Show("No files found.");

                    //    DialogResult dialogResult = MessageBox.Show("Warning", "No records found.", MessageBoxButtons.OK);

                    //    if (dialogResult == DialogResult.OK)
                    //    {
                    //        clearInsertForm();
                    //        return results;
                    //    }
                    //    //WriteToFile($"ALARM!! NO QUERIES! -> { f.Name }");
                    //}
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    WriteToFile($"Exception -> SearchText -> { ex.Message }");
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            if (tenResultsRadioButton.Checked && tenResultsRadioButton.Enabled && !isInsert)
            {
                FileInfo k = results.FirstOrDefault(x => x.Value.Count >= 100).Key;
                List<List<string>> v = results[k].Take(10).ToList();
                return new Dictionary<FileInfo, List<List<string>>>() { { k, v } };
            }
            else if (hundredResultsRadioButton.Checked && hundredResultsRadioButton.Enabled && !isInsert)
            {
                FileInfo k = results.FirstOrDefault(x => x.Value.Count >= 100).Key;
                List<List<string>> v = results[k].Take(100).ToList();
                return new Dictionary<FileInfo, List<List<string>>>() { { k, v } };
            }

            return results;
        }

        private List<List<string>> CreateQueries(StreamReader reader, string fileName, string lineFilter = "", DateTime? date1 = null, DateTime? date2 = null)
        {
            List<List<string>> queries = new List<List<string>>();
            String line = reader.ReadLine();
            DateTime? startDate = DateTime.MinValue;
            DateTime? endDate = DateTime.MinValue;
            StringBuilder sb = new StringBuilder();
            bool isMsg = false;
            bool checkDate = false;
            int lineCounter = 0;
            string appName = "";
            string host = "";

            if(date1 == null)
            {
                date1 = DateTime.MinValue;
            }
            
            if (date2 == null)
            {
                date2 = DateTime.MinValue;
            }

            if(line == null && lineCounter == 0)
            {
                MessageBox.Show("Empty file, select other.");

                return queries;
            }

            try
            {
                while (line != null)
                {
                    lineCounter++;
                    line = line.Replace("/*", String.Empty).Replace("*/", String.Empty);
                    string[] spl = line.Replace("\t", "  ").Split(' ').Where(x => x != "").ToArray();
                    string logMsg = "";

                    if (line == "")
                    {
                        line = reader.ReadLine();
                        continue;
                    }

                    if ((!String.IsNullOrEmpty(lineFilter) && !String.IsNullOrWhiteSpace(lineFilter)) && !line.Contains(lineFilter))
                    {
                        line = reader.ReadLine();
                        continue;
                    }

                    if (date1 > DateTime.MinValue && date2 > DateTime.MinValue && date2 >= date1 && date2 <= DateTime.Today)
                    {
                        startDate = date1;
                        endDate = date2;
                        checkDate = true;
                    }

                    //if (!DateTime.TryParse(spl[0], out DateTime d3))
                    if (!DateTime.TryParseExact(spl[0], "MM/dd/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime d3))
                    {
                        if (lineCounter == 1)
                        {
                            line = reader.ReadLine();
                            continue;
                        }
                        isMsg = true;
                        sb.Append(Regex.Replace(line.Replace("\t", "  "), reduceMultiSpace, String.Empty));
                    }
                    else
                    {
                        if (isMsg)
                        {
                            if (lineCounter == 1)
                            {
                                line = reader.ReadLine();
                                continue; 
                            }
                            logMsg = sb.ToString();
                            sb.Clear();
                            isMsg = false;
                        }

                        if (spl.Length < 7)
                        {
                            if (!isMsg && logMsg == "")
                            {
                                //DateTime sDateTime = DateTime.Parse(spl[0] + " " + spl[1]);
                                //if (checkDate && ((sDateTime < startDate) || (sDateTime > endDate)))
                                DateTime sDateTime = DateTime.MinValue;
                                if (spl.Length > 2 && DateTime.TryParseExact(spl[0] + " " + spl[1], "MM/dd/yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dd))
                                {
                                    sDateTime = dd;
                                }
                                else
                                { 
                                    line = reader.ReadLine();
                                    continue;
                                }
                                string severityID = spl[2];
                                if (spl.Length == 4)
                                {
                                    logMsg = spl[3];
                                }
                                else if (spl.Length == 5)
                                {
                                    appName = spl[3];
                                    logMsg = spl[4];
                                }
                                else if (spl.Length == 6)
                                {
                                    appName = spl[3];
                                    host = spl[4] + " " + spl[5];
                                    logMsg = "";
                                }

                                List<string> query = new List<string>() { sDateTime.ToString(), appName, host, severityID, logMsg, " -- file: " + fileName };

                                queries.Add(query);
                            }
                        }
                        else
                        {
                            if (!isMsg && logMsg == "")
                            {
                                int j = 6;

                                if (spl[4].Contains("Service"))
                                {
                                    j++;
                                }

                                for (int i = j; i < spl.Length; i++)
                                {
                                    sb.Append(spl[i] + " ");
                                }

                                logMsg = sb.ToString();
                                sb.Clear();
                            }

                            DateTime sDateTime = DateTime.Parse(spl[0] + " " + spl[1]);
                            if (checkDate && ((sDateTime < startDate) || (sDateTime > endDate)))
                            {
                                line = reader.ReadLine();
                                continue;
                            }
                            string severityID = spl[2];
                            if (spl[4].Contains("Service"))
                            {
                                appName = spl[3] + " " + spl[4];
                                host = spl[5] + " " + spl[6];
                            }
                            else
                            {
                                appName = spl[3];
                                host = spl[4] + " " + spl[5];
                            }

                            List<string> query = new List<string>() { sDateTime.ToString(), appName, host, severityID, logMsg, " -- file: " + fileName };

                            queries.Add(query);
                        }
                    }

                    line = reader.ReadLine();

                    //if (tenResultsRadioButton.Checked && tenResultsRadioButton.Enabled && queries.Count >= 10)
                    //{
                    //    queries = queries.Take(10).ToList();

                    //    return queries;
                    //}
                    //else if (hundredResultsRadioButton.Checked && hundredResultsRadioButton.Enabled && queries.Count >= 100)
                    //{
                    //    queries = queries.Take(100).ToList();

                    //    return queries;
                    //}
                }

                return queries;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                WriteToFile($"Exception -> CreateQueries -> { ex.Message }");

                return queries;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
        }

        private int ExecQueries(List<string> query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Proc_Insert_ADI_Logs", conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", DateTime.Parse(query[0]));
                        cmd.Parameters.AddWithValue("@Thread", query[1]);
                        cmd.Parameters.AddWithValue("@Logger", query[2]);
                        cmd.Parameters.AddWithValue("@LevelID", query[3]);
                        cmd.Parameters.AddWithValue("@Message", query[4]);
                        cmd.Parameters.AddWithValue("@FileName", query[5].Replace(" -- file: ", ""));
                        conn.Open();
                        rows += cmd.ExecuteNonQuery();
                        //cmd.ExecuteNonQuery();
                        //string query = cmd.CommandText;

                        //foreach (SqlParameter p in cmd.Parameters)
                        //{
                        //    query = query.Replace(p.ParameterName, p.Value.ToString());
                        //}

                        //Console.WriteLine(query);

                        //Console.WriteLine($"{rows} rows inserted.");
                        //rows++;
                    }
                    catch (Exception ex)
                    {
                        cmd.Parameters.AddWithValue("@Exception", ex.Message);
                        string q = cmd.CommandText;

                        foreach (SqlParameter p in cmd.Parameters)
                        {
                            q = q.Replace(p.ParameterName, p.Value.ToString());
                            //Console.WriteLine(query);
                        }

                        //MessageBox.Show(ex.Message);
                        WriteToFile($"Exception --> ExecQueries --> {ex.Message}");
                        //add insert exception to DB!
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return rows++;
        }

        private string CleanString(string dirtyString)
        {
            int length = dirtyString.Trim().Replace(".log", "").Length;
            StringBuilder sb = new StringBuilder(length);

            foreach (char x in dirtyString.Trim().Where(c => !removeChars.Contains(c)))
            {
                sb.Append(x);
            }

            return sb.ToString();
        }

        private void WriteToFile(string Message)
        {
            string path = ConfigurationManager.AppSettings["Path"];
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = path + "\\writeLogs\\loggerApp_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        private void Search(bool isInsert = false)
        {
            resultsListView.Items.Clear();
            DirectoryInfo directory = new DirectoryInfo(path);
            int totalRes = 0;
            DateTime? date1 = null;
            DateTime? date2 = null;
            List<FileInfo> res = new List<FileInfo>();
            //res.ForEach(x => WriteToFile("searchfile - " + x.Name));
            //List<FileInfo> auxRes = new List<FileInfo>();

            totalResultsLbl.Visible = true;

            if (allFilesRadioButton.Checked)
            {
                resultsListView.Clear();

                res = GetFiles(directory);

                if (tenResultsRadioButton.Checked && tenResultsRadioButton.Enabled && !isInsert)
                {
                    res = res.Take(10).ToList();
                }
                else if (hundredResultsRadioButton.Checked && hundredResultsRadioButton.Enabled && !isInsert)
                {
                    res = res.Take(100).ToList();
                }

                totalRes = Int32.Parse(FillResultsListView(res).ToString());

                dic = SearchText(res, isInsert, CleanString(messageTextBox.Text), null, null);
            }
            else if (fileAttributesRadioButton.Checked)
            {
                resultsListView.Clear();

                if (patternCheckBox.Checked && filePatternTextBox.Enabled && !messageTextCheckBox.Checked && !logDateCheckBox.Checked) //100
                {
                    res = GetFiles(directory, CleanString(filePatternTextBox.Text));
                    dic = SearchText(res, isInsert);

                    if (tenResultsRadioButton.Checked && tenResultsRadioButton.Enabled && !isInsert)
                    {
                        res = res.Take(10).ToList();
                    }
                    else if(hundredResultsRadioButton.Checked && hundredResultsRadioButton.Enabled && !isInsert)
                    {
                        res = res.Take(100).ToList();
                    }

                    totalRes += Int32.Parse(FillResultsListView(res).ToString());
                }
                else if (!patternCheckBox.Checked && messageTextCheckBox.Checked && messageTextBox.Enabled && !logDateCheckBox.Checked) //010
                {
                    res = GetFiles(directory);
                    dic = SearchText(res, isInsert, CleanString(messageTextBox.Text));

                    foreach (var d in dic)
                    {
                        totalRes += Int32.Parse(FillResultsListView(null, d.Value).ToString());
                    }
                }
                else if (!patternCheckBox.Checked && !messageTextCheckBox.Checked && logDateCheckBox.Checked && insert1DateTimePicker.Enabled && insert2DateTimePicker.Enabled ) //001
                {
                    res = GetFiles(directory);
                    date1 = insert1DateTimePicker.Value;
                    date2 = insert2DateTimePicker.Value;
                    dic = SearchText(res, isInsert, "", date1, date2);

                    foreach (var d in dic)
                    {
                        totalRes += Int32.Parse(FillResultsListView(null, d.Value).ToString());
                    }
                }
                else if (patternCheckBox.Checked && filePatternTextBox.Enabled && messageTextCheckBox.Checked && messageTextBox.Enabled && !logDateCheckBox.Checked) //110
                {
                    res = GetFiles(directory, CleanString(filePatternTextBox.Text));
                    dic = SearchText(res, isInsert, CleanString(messageTextBox.Text));

                    foreach (var d in dic)
                    {
                        totalRes += Int32.Parse(FillResultsListView(null, d.Value).ToString());
                    }
                }
                else if (!patternCheckBox.Checked && messageTextCheckBox.Checked && messageTextBox.Enabled && logDateCheckBox.Checked && insert1DateTimePicker.Enabled && insert2DateTimePicker.Enabled) //011
                {
                    res = GetFiles(directory);
                    date1 = insert1DateTimePicker.Value;
                    date2 = insert2DateTimePicker.Value;
                    dic = SearchText(res, isInsert, CleanString(messageTextBox.Text), date1, date2);

                    foreach (var d in dic)
                    {
                        totalRes += Int32.Parse(FillResultsListView(null, d.Value).ToString());
                    }
                }
                else if (patternCheckBox.Checked && filePatternTextBox.Enabled && !messageTextCheckBox.Checked && logDateCheckBox.Checked && insert1DateTimePicker.Enabled && insert2DateTimePicker.Enabled) //101
                {
                    res = GetFiles(directory, CleanString(filePatternTextBox.Text));
                    date1 = insert1DateTimePicker.Value;
                    date2 = insert2DateTimePicker.Value;
                    dic = SearchText(res, isInsert, "", date1, date2);

                    foreach (var d in dic)
                    {
                        totalRes += Int32.Parse(FillResultsListView(null, d.Value).ToString());
                    }
                }
                else if (patternCheckBox.Checked && filePatternTextBox.Enabled && messageTextCheckBox.Checked && messageTextBox.Enabled && !logDateCheckBox.Checked) //110
                {
                    res = GetFiles(directory, CleanString(filePatternTextBox.Text));
                    dic = SearchText(res, isInsert, CleanString(messageTextBox.Text));

                    foreach (var d in dic)
                    {
                        totalRes += Int32.Parse(FillResultsListView(null, d.Value).ToString());
                    }
                }
                else if (patternCheckBox.Checked && filePatternTextBox.Enabled && messageTextCheckBox.Checked && messageTextBox.Enabled && logDateCheckBox.Checked && insert1DateTimePicker.Enabled && insert2DateTimePicker.Enabled) //111
                {
                    res = GetFiles(directory, CleanString(filePatternTextBox.Text));
                    date1 = insert1DateTimePicker.Value;
                    date2 = insert2DateTimePicker.Value;
                    dic = SearchText(res, isInsert, CleanString(messageTextBox.Text), date1, date2);

                    foreach (var d in dic)
                    {
                        totalRes += Int32.Parse(FillResultsListView(null, d.Value).ToString());
                    }
                }
            }

            totalResultsLbl.Text = totalRes.ToString() + " items found.";
        }

        private void LoggerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
