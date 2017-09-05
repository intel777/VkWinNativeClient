namespace VK_Access_Token_client
{
    partial class Captcha
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
            this.Captcha_Solve = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Captcha_img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Captcha_img)).BeginInit();
            this.SuspendLayout();
            // 
            // Captcha_Solve
            // 
            this.Captcha_Solve.Location = new System.Drawing.Point(12, 88);
            this.Captcha_Solve.Name = "Captcha_Solve";
            this.Captcha_Solve.Size = new System.Drawing.Size(180, 20);
            this.Captcha_Solve.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Captcha_img
            // 
            this.Captcha_img.Location = new System.Drawing.Point(12, 12);
            this.Captcha_img.Name = "Captcha_img";
            this.Captcha_img.Size = new System.Drawing.Size(180, 70);
            this.Captcha_img.TabIndex = 4;
            this.Captcha_img.TabStop = false;
            // 
            // Captcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 144);
            this.Controls.Add(this.Captcha_img);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Captcha_Solve);
            this.Name = "Captcha";
            this.Text = "Captcha Required";
            this.Load += new System.EventHandler(this.Captcha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Captcha_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Captcha_Solve;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox Captcha_img;
    }
}