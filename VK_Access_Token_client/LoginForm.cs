using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;


namespace VK_Access_Token_client
{
    public partial class LoginForm : Form
    {
        string access_token;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginToken_Button_Click(object sender, EventArgs e)
        {
            LoadingDialog Loading = new LoadingDialog();
            Loading.Show();
            Application.DoEvents();
            access_token = text_access_token.Text;
            WebRequest request = WebRequest.Create("https://api.vk.com/method/users.get?access_token=" + access_token);
            WebResponse response = request.GetResponse();
            var encoding = UTF8Encoding.ASCII;
            string userid;
            using(var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string response_text = reader.ReadToEnd();
                JObject response_json = JObject.Parse(response_text);
                userid = (string)response_json.SelectToken("response[0].uid");
            }
            var vk = new VkApi();
            vk.Authorize(access_token, long.Parse(userid));
            var user_info = vk.Users.Get(vk.UserId.Value);
            Main frm = new Main();
            frm.self_id = long.Parse(userid);
            frm.api = vk;
            frm.Show();
            Loading.Close();
            this.Hide();
        }

        private void TSV_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!TSV_Code.Enabled)
            {
                TSV_Code.Enabled = true;
            }
            else
            {
                TSV_Code.Enabled = false;
            }
        }
    }
}

