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
using System.Web;
using Newtonsoft.Json.Linq;


namespace VK_Access_Token_client
{
    public partial class LoginForm : Form
    {

        string access_token;
        public LoginForm()
        {
            InitializeComponent();
            PlatformSelector.SelectedIndex = 0;
        }

        private void TokenAuth(string access_token)
        {
            LoadingDialog Loading = new LoadingDialog();
            Loading.Show();
            Application.DoEvents();
            WebRequest request = WebRequest.Create("https://api.vk.com/method/users.get?access_token=" + access_token);
            WebResponse response = request.GetResponse();
            var encoding = UTF8Encoding.ASCII;
            string userid;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string response_text = reader.ReadToEnd();
                JObject response_json = JObject.Parse(response_text);
                userid = (string)response_json.SelectToken("response[0].uid");
            }
            var vk = new VkApi();
            vk.Authorize(access_token, long.Parse(userid));
            var user_info = vk.Users.Get(vk.UserId.Value);
            GlobalVars.self_id = long.Parse(userid);
            GlobalVars.api = vk;
            Main frm = new Main();
            frm.Show();
            Loading.Close();
            this.Hide();
        }

        private void LoginToken_Button_Click(object sender, EventArgs e)
        {
            access_token = text_access_token.Text;
            TokenAuth(access_token);
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

        private void LoginByPassword_Button_Click(object sender, EventArgs e)
        {
            LoadingDialog Loading = new LoadingDialog();
            Loading.Show();
            Application.DoEvents();
            string facode = string.Empty;
            string platform;
            Dictionary<int, string> platforms = new Dictionary<int, string>
            {
                {0, "client_id=2274003&client_secret=hHbZxrka2uZ6jB1inYsH" },
                {1, "client_id=3140623&client_secret=VeWdmVclDCtn6ihuP1nt" },
                {2, "client_id=3682744&client_secret=mY6CDUswIVdJLCD3j15n" },
                {3, "client_id=3502561&client_secret=omvP3y2MZmpREFZJDNHd" }
            }; 
            string username = WebUtility.UrlEncode(Login_text.Text);
            string password = WebUtility.UrlEncode(Password_text.Text);
            if (TSV_Code.Enabled)
            {
                if (TSV_Code.Text != "")
                {
                    facode = "&code=" + TSV_Code.Text;
                }
                else
                {
                    MessageBox.Show("Enter 2FA code to login", "Error");
                    return;
                }
            }
            int platformIndex = PlatformSelector.SelectedIndex;
            platform = platforms[platformIndex];
            string requestUrl = "https://oauth.vk.com/token?scope=all&" + platform + "&lang=en&grant_type=password&username=" + username + "&password=" + password + facode;
            WebRequest request = WebRequest.Create(requestUrl);
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    string Out = sr.ReadToEnd();
                    JObject login_response = JObject.Parse(Out);
                    string access_token = login_response.SelectToken("access_token").ToString();
                }
            }
            catch(WebException err)
            {
                using (WebResponse response = err.Response)
                {
                    string text = string.Empty;
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        text = reader.ReadToEnd();
                    }
                    JObject error = JObject.Parse(text);
                    if (error.SelectToken("error").ToString() == "need_captcha")
                    {
                        Captcha captcha_processor = new Captcha();
                        captcha_processor.captcha_url = WebUtility.UrlDecode(error.SelectToken("captcha_img").ToString());
                        captcha_processor.captcha_sid = error.SelectToken("captcha_sid").ToString();
                        captcha_processor.request_url = requestUrl;
                        captcha_processor.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(text, "Error code: " + httpResponse.StatusCode);
                        return;
                    }
                }
            }
            Loading.Close();
            TokenAuth(access_token);
        }
    }

    public static class GlobalVars
    {
        public static VkApi api;
        public static long self_id;
    }
}