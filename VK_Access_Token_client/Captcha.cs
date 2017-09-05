using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace VK_Access_Token_client
{
    public partial class Captcha : Form
    {
        public string CaptchaUrl;
        public string CaptchaSid;
        public string RequestUrl;
        public string Response;
        public bool Success = false;
        public Captcha()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CaptchaAnswer = Captcha_Solve.Text;
            RequestUrl = RequestUrl + "&captcha_sid=" + CaptchaSid + "&captcha_key=" + CaptchaAnswer;
            WebRequest request = WebRequest.Create(RequestUrl);
            try
            {
                using(WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    Response = sr.ReadToEnd();
                    Success = true;
                }
            }
            catch(WebException)
            {
                Success = false;
            }
            this.Close();
        }

        private void Captcha_Load(object sender, EventArgs e)
        {
            Captcha_img.ImageLocation = CaptchaUrl;
            Captcha_img.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}