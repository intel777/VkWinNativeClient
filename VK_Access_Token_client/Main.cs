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

namespace VK_Access_Token_client
{
    public partial class Main : Form
    {
        VkApi api = GlobalVars.api;
        long self_id = GlobalVars.self_id;
        public Main()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            var selfinfo = api.Users.Get(self_id);
            string username = selfinfo.FirstName + ' ' + selfinfo.LastName;
            this.Text = username;
            
        }

        private void selfprofile_button_Click(object sender, EventArgs e)
        {
            LoadingDialog Loading = new LoadingDialog();
            Loading.Show();
            Application.DoEvents();
            Userprofile profile = new Userprofile();
            profile.Show();
            Loading.Close();
        }

        private void SomeoneProfile_Button_Click(object sender, EventArgs e)
        {
            LoadingDialog Loading = new LoadingDialog();
            Loading.Show();
            Application.DoEvents();
            Userprofile profile = new Userprofile();
            profile.Target_id = long.Parse(SomeoneProfile_id.Text);
            profile.Show();
            Loading.Close();
        }
    }
}
