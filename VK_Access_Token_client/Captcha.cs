using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_Access_Token_client
{
    public partial class Captcha : Form
    {
        public string captcha_url;
        public string captcha_sid;
        public string request_url;
        public string response;
        public bool success;
        public Captcha()
        {
            InitializeComponent();
            Captcha_img.ImageLocation = captcha_url;
            Captcha_img.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
