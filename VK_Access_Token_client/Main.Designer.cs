namespace VK_Access_Token_client
{
    partial class Main
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
            this.selfprofile_button = new System.Windows.Forms.Button();
            this.SomeoneProfile_id = new System.Windows.Forms.TextBox();
            this.SomeoneProfile_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selfprofile_button
            // 
            this.selfprofile_button.Location = new System.Drawing.Point(12, 12);
            this.selfprofile_button.Name = "selfprofile_button";
            this.selfprofile_button.Size = new System.Drawing.Size(223, 29);
            this.selfprofile_button.TabIndex = 0;
            this.selfprofile_button.Text = "My Profile";
            this.selfprofile_button.UseVisualStyleBackColor = true;
            this.selfprofile_button.Click += new System.EventHandler(this.selfprofile_button_Click);
            // 
            // SomeoneProfile_id
            // 
            this.SomeoneProfile_id.Location = new System.Drawing.Point(12, 47);
            this.SomeoneProfile_id.Name = "SomeoneProfile_id";
            this.SomeoneProfile_id.Size = new System.Drawing.Size(80, 20);
            this.SomeoneProfile_id.TabIndex = 1;
            // 
            // SomeoneProfile_Button
            // 
            this.SomeoneProfile_Button.Location = new System.Drawing.Point(98, 45);
            this.SomeoneProfile_Button.Name = "SomeoneProfile_Button";
            this.SomeoneProfile_Button.Size = new System.Drawing.Size(137, 23);
            this.SomeoneProfile_Button.TabIndex = 2;
            this.SomeoneProfile_Button.Text = "ID\'s profile";
            this.SomeoneProfile_Button.UseVisualStyleBackColor = true;
            this.SomeoneProfile_Button.Click += new System.EventHandler(this.SomeoneProfile_Button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 429);
            this.Controls.Add(this.SomeoneProfile_Button);
            this.Controls.Add(this.SomeoneProfile_id);
            this.Controls.Add(this.selfprofile_button);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selfprofile_button;
        private System.Windows.Forms.TextBox SomeoneProfile_id;
        private System.Windows.Forms.Button SomeoneProfile_Button;
    }
}