using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            integratedSecurityCheckBox.Click += new System.EventHandler(integratedSecurityCheckBox_CheckedChanged);

            serverNameTextBox.KeyUp += serverDatabaseNamesTextBox_KeyUp;
            databaseNameTextBox.KeyUp += serverDatabaseNamesTextBox_KeyUp;
            userIdTextBox.KeyUp += serverDatabaseNamesTextBox_KeyUp;
            passwordTextBox.KeyUp += serverDatabaseNamesTextBox_KeyUp;

            integratedSecurityCheckBox.Checked = true;

            userIdTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
        }

        private void integratedSecurityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(integratedSecurityCheckBox.Checked)
            {
                userIdTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
            }
            else
            {
                userIdTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
            }
        }

        private void serverDatabaseNamesTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (integratedSecurityCheckBox.Checked)
            {
                if (!String.IsNullOrEmpty(serverNameTextBox.Text) && !String.IsNullOrWhiteSpace(serverNameTextBox.Text) && !String.IsNullOrWhiteSpace(databaseNameTextBox.Text) && !String.IsNullOrEmpty(databaseNameTextBox.Text))
                {
                    loginTestConnButton.Enabled = true;
                    loginOkButton.Enabled = true;
                }
                else
                {
                    loginTestConnButton.Enabled = false;
                    loginOkButton.Enabled = false;
                }
            }
            else
            {
                if(!String.IsNullOrEmpty(serverNameTextBox.Text) && !String.IsNullOrWhiteSpace(serverNameTextBox.Text) && !String.IsNullOrWhiteSpace(databaseNameTextBox.Text) && !String.IsNullOrEmpty(databaseNameTextBox.Text) && !String.IsNullOrWhiteSpace(userIdTextBox.Text) && !String.IsNullOrEmpty(userIdTextBox.Text) && !String.IsNullOrWhiteSpace(passwordTextBox.Text) && !String.IsNullOrEmpty(passwordTextBox.Text))
                {
                    loginTestConnButton.Enabled = true;
                    loginOkButton.Enabled = true;
                }
                else
                {
                    loginTestConnButton.Enabled = false;
                    loginOkButton.Enabled = false;
                }
            }
        }

        private void cancelLoginButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginTestConnButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(connectionTester()))
            {
                testResultTextBox.Text = "Success";
            }
            else
            {
                testResultTextBox.Text = "Failed";
            }
        }

        private void loginOkButton_Click(object sender, EventArgs e)
        {
            string connStr = connectionTester();

            if (!String.IsNullOrEmpty(connStr))
            {
                LoggerForm loggerForm = new LoggerForm(connStr);
                loggerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Connection failed. Please check your credentials and try again.");
            }
        }

        private string connectionTester()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();

            connectionStringBuilder.DataSource = serverNameTextBox.Text;
            connectionStringBuilder.InitialCatalog = databaseNameTextBox.Text;

            if (integratedSecurityCheckBox.Checked)
            {
                connectionStringBuilder.IntegratedSecurity = true;
            }
            else
            {
                connectionStringBuilder.UserID = userIdTextBox.Text;
                connectionStringBuilder.Password = passwordTextBox.Text;
            }

            string connectionString = connectionStringBuilder.ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    if (conn.State == ConnectionState.Open)
                    {
                        return connectionString;
                    }
                    else
                    {
                        testResultTextBox.Text = conn.State.ToString();
                        return String.Empty;
                    }
                }
                catch
                {
                    return String.Empty;
                }
            }
        }
    }
}
