namespace VK_Access_Token_client
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
            this.Login_tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LoginByPassword_Button = new System.Windows.Forms.Button();
            this.TSV_Code = new System.Windows.Forms.TextBox();
            this.TSVCode_label = new System.Windows.Forms.Label();
            this.TSV_checkBox = new System.Windows.Forms.CheckBox();
            this.Password_text = new System.Windows.Forms.TextBox();
            this.Login_text = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Login_label = new System.Windows.Forms.Label();
            this.AccessToken = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginToken_Button = new System.Windows.Forms.Button();
            this.text_access_token = new System.Windows.Forms.TextBox();
            this.Login_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.AccessToken.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login_tabControl
            // 
            this.Login_tabControl.Controls.Add(this.tabPage1);
            this.Login_tabControl.Controls.Add(this.AccessToken);
            this.Login_tabControl.Location = new System.Drawing.Point(12, 12);
            this.Login_tabControl.Name = "Login_tabControl";
            this.Login_tabControl.SelectedIndex = 0;
            this.Login_tabControl.Size = new System.Drawing.Size(400, 163);
            this.Login_tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LoginByPassword_Button);
            this.tabPage1.Controls.Add(this.TSV_Code);
            this.tabPage1.Controls.Add(this.TSVCode_label);
            this.tabPage1.Controls.Add(this.TSV_checkBox);
            this.tabPage1.Controls.Add(this.Password_text);
            this.tabPage1.Controls.Add(this.Login_text);
            this.tabPage1.Controls.Add(this.Password_label);
            this.tabPage1.Controls.Add(this.Login_label);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(392, 137);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Username&Password";
            // 
            // LoginByPassword_Button
            // 
            this.LoginByPassword_Button.Location = new System.Drawing.Point(137, 99);
            this.LoginByPassword_Button.Name = "LoginByPassword_Button";
            this.LoginByPassword_Button.Size = new System.Drawing.Size(101, 32);
            this.LoginByPassword_Button.TabIndex = 5;
            this.LoginByPassword_Button.Text = "Login";
            this.LoginByPassword_Button.UseVisualStyleBackColor = true;
            // 
            // TSV_Code
            // 
            this.TSV_Code.Enabled = false;
            this.TSV_Code.Location = new System.Drawing.Point(271, 59);
            this.TSV_Code.Name = "TSV_Code";
            this.TSV_Code.Size = new System.Drawing.Size(115, 20);
            this.TSV_Code.TabIndex = 4;
            // 
            // TSVCode_label
            // 
            this.TSVCode_label.AutoSize = true;
            this.TSVCode_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TSVCode_label.Location = new System.Drawing.Point(209, 60);
            this.TSVCode_label.Name = "TSVCode_label";
            this.TSVCode_label.Size = new System.Drawing.Size(45, 17);
            this.TSVCode_label.TabIndex = 3;
            this.TSVCode_label.Text = "Code:";
            // 
            // TSV_checkBox
            // 
            this.TSV_checkBox.AutoSize = true;
            this.TSV_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TSV_checkBox.Location = new System.Drawing.Point(7, 59);
            this.TSV_checkBox.Name = "TSV_checkBox";
            this.TSV_checkBox.Size = new System.Drawing.Size(160, 21);
            this.TSV_checkBox.TabIndex = 2;
            this.TSV_checkBox.Text = "Two Step Verification";
            this.TSV_checkBox.UseVisualStyleBackColor = true;
            this.TSV_checkBox.CheckedChanged += new System.EventHandler(this.TSV_checkBox_CheckedChanged);
            // 
            // Password_text
            // 
            this.Password_text.Location = new System.Drawing.Point(103, 32);
            this.Password_text.Name = "Password_text";
            this.Password_text.PasswordChar = '*';
            this.Password_text.Size = new System.Drawing.Size(283, 20);
            this.Password_text.TabIndex = 1;
            // 
            // Login_text
            // 
            this.Login_text.Location = new System.Drawing.Point(103, 6);
            this.Login_text.Name = "Login_text";
            this.Login_text.Size = new System.Drawing.Size(283, 20);
            this.Login_text.TabIndex = 1;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Password_label.Location = new System.Drawing.Point(3, 33);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(73, 17);
            this.Password_label.TabIndex = 0;
            this.Password_label.Text = "Password:";
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Login_label.Location = new System.Drawing.Point(4, 7);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(47, 17);
            this.Login_label.TabIndex = 0;
            this.Login_label.Text = "Login:";
            // 
            // AccessToken
            // 
            this.AccessToken.Controls.Add(this.label1);
            this.AccessToken.Controls.Add(this.LoginToken_Button);
            this.AccessToken.Controls.Add(this.text_access_token);
            this.AccessToken.Location = new System.Drawing.Point(4, 22);
            this.AccessToken.Name = "AccessToken";
            this.AccessToken.Padding = new System.Windows.Forms.Padding(3);
            this.AccessToken.Size = new System.Drawing.Size(392, 137);
            this.AccessToken.TabIndex = 1;
            this.AccessToken.Text = "AccessToken";
            this.AccessToken.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Token:";
            // 
            // LoginToken_Button
            // 
            this.LoginToken_Button.Location = new System.Drawing.Point(148, 70);
            this.LoginToken_Button.Name = "LoginToken_Button";
            this.LoginToken_Button.Size = new System.Drawing.Size(89, 35);
            this.LoginToken_Button.TabIndex = 11;
            this.LoginToken_Button.Text = "Login";
            this.LoginToken_Button.UseVisualStyleBackColor = true;
            this.LoginToken_Button.Click += new System.EventHandler(this.LoginToken_Button_Click);
            // 
            // text_access_token
            // 
            this.text_access_token.Location = new System.Drawing.Point(69, 44);
            this.text_access_token.Name = "text_access_token";
            this.text_access_token.Size = new System.Drawing.Size(317, 20);
            this.text_access_token.TabIndex = 10;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 189);
            this.Controls.Add(this.Login_tabControl);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Login_tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.AccessToken.ResumeLayout(false);
            this.AccessToken.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Login_tabControl;
        private System.Windows.Forms.TabPage AccessToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginToken_Button;
        private System.Windows.Forms.TextBox text_access_token;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox TSV_Code;
        private System.Windows.Forms.Label TSVCode_label;
        private System.Windows.Forms.CheckBox TSV_checkBox;
        private System.Windows.Forms.TextBox Password_text;
        private System.Windows.Forms.TextBox Login_text;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Button LoginByPassword_Button;
    }
}

