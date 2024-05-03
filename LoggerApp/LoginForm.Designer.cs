
namespace LoggerApp
{
    partial class LoginForm
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
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.integratedSecurityCheckBox = new System.Windows.Forms.CheckBox();
            this.integratedLabel = new System.Windows.Forms.Label();
            this.sqlPasswordLabel = new System.Windows.Forms.Label();
            this.sqlUserIdLabel = new System.Windows.Forms.Label();
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelLoginButton = new System.Windows.Forms.Button();
            this.loginOkButton = new System.Windows.Forms.Button();
            this.loginTestConnButton = new System.Windows.Forms.Button();
            this.testResultTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.Location = new System.Drawing.Point(226, 66);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(250, 20);
            this.serverNameTextBox.TabIndex = 9;
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Location = new System.Drawing.Point(226, 97);
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.Size = new System.Drawing.Size(250, 20);
            this.databaseNameTextBox.TabIndex = 8;
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.AutoSize = true;
            this.databaseNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseNameLabel.Location = new System.Drawing.Point(28, 96);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(118, 18);
            this.databaseNameLabel.TabIndex = 7;
            this.databaseNameLabel.Text = "DataBase name:";
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.Enabled = false;
            this.userIdTextBox.Location = new System.Drawing.Point(226, 128);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(250, 20);
            this.userIdTextBox.TabIndex = 6;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(226, 161);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(250, 20);
            this.passwordTextBox.TabIndex = 6;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // integratedSecurityCheckBox
            // 
            this.integratedSecurityCheckBox.AutoSize = true;
            this.integratedSecurityCheckBox.Location = new System.Drawing.Point(226, 196);
            this.integratedSecurityCheckBox.Name = "integratedSecurityCheckBox";
            this.integratedSecurityCheckBox.Size = new System.Drawing.Size(15, 14);
            this.integratedSecurityCheckBox.TabIndex = 5;
            this.integratedSecurityCheckBox.UseVisualStyleBackColor = true;
            this.integratedSecurityCheckBox.CheckedChanged += new System.EventHandler(this.integratedSecurityCheckBox_CheckedChanged);
            // 
            // integratedLabel
            // 
            this.integratedLabel.AutoSize = true;
            this.integratedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.integratedLabel.Location = new System.Drawing.Point(28, 191);
            this.integratedLabel.Name = "integratedLabel";
            this.integratedLabel.Size = new System.Drawing.Size(76, 18);
            this.integratedLabel.TabIndex = 4;
            this.integratedLabel.Text = "Integrated:";
            // 
            // sqlPasswordLabel
            // 
            this.sqlPasswordLabel.AutoSize = true;
            this.sqlPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlPasswordLabel.Location = new System.Drawing.Point(28, 159);
            this.sqlPasswordLabel.Name = "sqlPasswordLabel";
            this.sqlPasswordLabel.Size = new System.Drawing.Size(111, 18);
            this.sqlPasswordLabel.TabIndex = 3;
            this.sqlPasswordLabel.Text = "SQL password:";
            // 
            // sqlUserIdLabel
            // 
            this.sqlUserIdLabel.AutoSize = true;
            this.sqlUserIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlUserIdLabel.Location = new System.Drawing.Point(28, 127);
            this.sqlUserIdLabel.Name = "sqlUserIdLabel";
            this.sqlUserIdLabel.Size = new System.Drawing.Size(90, 18);
            this.sqlUserIdLabel.TabIndex = 2;
            this.sqlUserIdLabel.Text = "SQL user id:";
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverNameLabel.Location = new System.Drawing.Point(28, 65);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(96, 18);
            this.serverNameLabel.TabIndex = 1;
            this.serverNameLabel.Text = "Server name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter DataBase Connection Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelLoginButton);
            this.panel1.Controls.Add(this.loginOkButton);
            this.panel1.Controls.Add(this.loginTestConnButton);
            this.panel1.Controls.Add(this.testResultTextBox);
            this.panel1.Controls.Add(this.serverNameTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.databaseNameTextBox);
            this.panel1.Controls.Add(this.serverNameLabel);
            this.panel1.Controls.Add(this.databaseNameLabel);
            this.panel1.Controls.Add(this.sqlUserIdLabel);
            this.panel1.Controls.Add(this.userIdTextBox);
            this.panel1.Controls.Add(this.sqlPasswordLabel);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.integratedLabel);
            this.panel1.Controls.Add(this.integratedSecurityCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 261);
            this.panel1.TabIndex = 7;
            // 
            // cancelLoginButton
            // 
            this.cancelLoginButton.Location = new System.Drawing.Point(510, 186);
            this.cancelLoginButton.Name = "cancelLoginButton";
            this.cancelLoginButton.Size = new System.Drawing.Size(100, 23);
            this.cancelLoginButton.TabIndex = 13;
            this.cancelLoginButton.Text = "Cancel";
            this.cancelLoginButton.UseVisualStyleBackColor = true;
            this.cancelLoginButton.Click += new System.EventHandler(this.cancelLoginButton_Click);
            // 
            // loginOkButton
            // 
            this.loginOkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.loginOkButton.Enabled = false;
            this.loginOkButton.Location = new System.Drawing.Point(651, 186);
            this.loginOkButton.Name = "loginOkButton";
            this.loginOkButton.Size = new System.Drawing.Size(100, 23);
            this.loginOkButton.TabIndex = 12;
            this.loginOkButton.Text = "Ok";
            this.loginOkButton.UseVisualStyleBackColor = true;
            this.loginOkButton.Click += new System.EventHandler(this.loginOkButton_Click);
            // 
            // loginTestConnButton
            // 
            this.loginTestConnButton.Enabled = false;
            this.loginTestConnButton.Location = new System.Drawing.Point(511, 66);
            this.loginTestConnButton.Name = "loginTestConnButton";
            this.loginTestConnButton.Size = new System.Drawing.Size(99, 23);
            this.loginTestConnButton.TabIndex = 11;
            this.loginTestConnButton.Text = "Test";
            this.loginTestConnButton.UseVisualStyleBackColor = true;
            this.loginTestConnButton.Click += new System.EventHandler(this.loginTestConnButton_Click);
            // 
            // testResultTextBox
            // 
            this.testResultTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.testResultTextBox.Enabled = false;
            this.testResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testResultTextBox.Location = new System.Drawing.Point(651, 66);
            this.testResultTextBox.Name = "testResultTextBox";
            this.testResultTextBox.Size = new System.Drawing.Size(100, 20);
            this.testResultTextBox.TabIndex = 10;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginOkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.loginOkButton;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox serverNameTextBox;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.CheckBox integratedSecurityCheckBox;
        private System.Windows.Forms.Label integratedLabel;
        private System.Windows.Forms.Label sqlPasswordLabel;
        private System.Windows.Forms.Label sqlUserIdLabel;
        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelLoginButton;
        private System.Windows.Forms.Button loginOkButton;
        private System.Windows.Forms.Button loginTestConnButton;
        private System.Windows.Forms.TextBox testResultTextBox;
    }
}