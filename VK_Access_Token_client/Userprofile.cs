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
using VkNet.Enums.Filters;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;


namespace VK_Access_Token_client
{
    public partial class Userprofile : Form
    {
        public long Target_id;
        VkApi api = GlobalVars.api;
        long selfid = GlobalVars.self_id;
        VkNet.Model.User userinfo = new VkNet.Model.User();
        Dictionary<string, string> platforms = new Dictionary<string, string>();
        Dictionary<string, string> relation_statuses = new Dictionary<string, string>();
        Dictionary<string, string> contacts = new Dictionary<string, string>();
        Dictionary<string, string> relations = new Dictionary<string, string>();
        Dictionary<string, string> school = new Dictionary<string, string>();

        private static string GETDATE(string id)
        {
            WebRequest req = WebRequest.Create("http://api.vlad805.ru/vk.getDateUserRegistration?screen_name=" + id);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            return Out;
        }

        public static string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToString();
        }

        public Userprofile()
        {
            InitializeComponent();
        }

        private void Userprofile_Load(object sender, EventArgs e)
        {
            platforms.Add("1", "Mobile web");
            platforms.Add("2", "iPhone");
            platforms.Add("3", "iPad");
            platforms.Add("4", "Android");
            platforms.Add("5", "WindowsPhone");
            platforms.Add("6", "Windows10");
            platforms.Add("7", "VK Site");
            relation_statuses.Add("0", "Not Set");
            relation_statuses.Add("1", "Single");
            relation_statuses.Add("2", "In a relationship");
            relation_statuses.Add("3", "Engaged");
            relation_statuses.Add("4", "Married");
            relation_statuses.Add("5", "It's complicated");
            relation_statuses.Add("6", "Actively searching");
            relation_statuses.Add("7", "In Love");
            relation_statuses.Add("8", "In a civil union");
            if(Target_id == 0)
            {
                Target_id = selfid;
            }
            userinfo = api.Users.Get(Target_id, ProfileFields.All);
            First_name.Text = userinfo.FirstName;
            Last_name.Text = userinfo.LastName;
            this.Text = userinfo.FirstName + ' ' + userinfo.LastName + "[id" + Target_id + "]";
            if (userinfo.Blacklisted)
            {
                Actions_button.Enabled = false;
            }
            if (userinfo.HasPhoto ?? true)
            {
                ProfileImage.ImageLocation = userinfo.PhotoMax.ToString();
                ProfileImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                ProfileImage.ImageLocation = "https://vk.com/images/camera_200.png";
                ProfileImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Status.Text = userinfo.Status;
            if(userinfo.Online ?? true)
            {
                online.Text = "Online";
                online.ForeColor = System.Drawing.ColorTranslator.FromHtml("#8AC176");
            }
            if(userinfo.BirthdayVisibility.HasValue)
            {
                Birth_date.Text = userinfo.BirthDate;
            }
            Sex.Text = userinfo.Sex.ToString();
            Verified.Text = userinfo.Verified.ToString();
            if (userinfo.Country != null)
            {
                Country.Text = userinfo.Country.Title;
            }
            Country.AutoSize = true;
            if (userinfo.City != null)
            {
                City.Text = userinfo.City.Title.Replace("City", "");
            }
            City.AutoSize = true;
            Home_Town.Text = userinfo.HomeTown;
            Domain.Text = userinfo.Domain;
            Domain.AutoSize = true;
            string regdateraw = GETDATE(Target_id.ToString());
            JObject regdatejson = JObject.Parse(regdateraw);
            var reg_unix = regdatejson.SelectToken("response.unixtime");
            double unixdouble = Convert.ToDouble(reg_unix);
            Registration_date.Text = UnixTimeStampToDateTime(unixdouble);
            Registration_date.AutoSize = true;
            DaysFromRegistration.Text = (string)regdatejson.SelectToken("response.days");
            DaysFromRegistration.AutoSize = true;
            HasMobile.Text = userinfo.HasMobile.ToString();
            Followers.Text = userinfo.FollowersCount.ToString();
            Common.Text = userinfo.CommonCount.ToString();
            Common.AutoSize = true;
            Blacklisted.Text = userinfo.Blacklisted.ToString();
            BlacklistedByMe.Text = userinfo.BlacklistedByMe.ToString();
            Friends.Text = userinfo.FriendStatus.ToString();
            Friends.AutoSize = true;
            HiddenFromFeed.Text = userinfo.IsHiddenFromFeed.ToString();
            CanWritePM.Text = userinfo.CanWritePrivateMessage.ToString();
            CanSendFriendRequest.Text = userinfo.CanSendFriendRequest.ToString();
            CanSeeAudio.Text = userinfo.CanSeeAudio.ToString();
            CanSeeAllPosts.Text = userinfo.CanSeeAllPosts.ToString();
            CanMakePosts.Text = userinfo.CanPost.ToString();
            PersonalSite.Text = userinfo.Site.ToString();
            if (userinfo.Education != null)
            {
                University.Text = userinfo.Education.UniversityName;
                Faculty.Text = userinfo.Education.FacultyName;
                Graduation.Text = userinfo.Education.Graduation.ToString();
            }
            //Begin postprocessing...
            WebRequest request = WebRequest.Create("https://api.vk.com/method/users.get?access_token=" + api.Token + "&user_id=" + Target_id + "&fields=contacts,schools,relatives,relation,exports&v=5.65");
            WebResponse response = request.GetResponse();
            var encoding = UTF8Encoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string response_text = reader.ReadToEnd();
                JObject response_json = JObject.Parse(response_text);
                contacts.Add("mobile", (string)response_json.SelectToken("response[0].mobile_phone"));
                contacts.Add("home", (string)response_json.SelectToken("response[0].home_phone"));
                if (response_json.SelectToken("response[0].relation") != null)
                {
                    relations.Add("status", relation_statuses[(string)response_json.SelectToken("response[0].relation")]);
                    if (response_json.SelectToken("response[0].relation_partner") != null)
                    {
                        relations.Add("partner", (string)response_json.SelectToken("response[0].relation_partner"));
                    }
                    else
                    {
                        relations.Add("partner", "Not Selected");
                    }
                }
                if(response_json.SelectToken("response[0].schools[0].name") != null)
                {
                    school.Add("name", (string)response_json.SelectToken("response[0].schools[0].name"));
                    if(response_json.SelectToken("response[0].schools[0].year_from") != null)
                    {
                        school.Add("from", (string)response_json.SelectToken("response[0].schools[0].year_from"));
                    }
                    else
                    {
                        school.Add("from", "unknown");
                    }
                    if(response_json.SelectToken("response[0].schoolds[0].year_graduated") != null)
                    {
                        school.Add("to", (string)response_json.SelectToken("response[0].schoolds[0].year_graduated"));
                    }
                    else
                    {
                        school.Add("to", "unknown");
                    }
                }
                else
                {
                    school.Add("name", "unknown");
                }
            }
            MobilePhone.Text = contacts["mobile"];
            HomePhone.Text = contacts["home"];
            MobilePhone.AutoSize = true;
            HomePhone.AutoSize = true;
            if (relations.ContainsKey("status"))
            {
                Relation_status.Text = relations["status"];
                Relation_UserID.Text = relations["partner"];
            }
            var friends = api.Friends.Get(Target_id);
            FriendsCount.Text = friends.Count.ToString();
            FriendsCount.AutoSize = true;
            if (school["name"] != "unknown")
            {
                SchoolName.Text = school["name"];
                SchoolFrom.Text = school["from"];
                SchoolTo.Text = school["to"];
            }
        }

        private void online_Click(object sender, EventArgs e)
        {
            string onlinestatus = "Offline";
            if(userinfo.Online ?? true)
            {
                onlinestatus = "Online";
            }
            MessageBox.Show("Online from mobile: " + userinfo.OnlineMobile + "\nOnline ClientID: " + userinfo.OnlineApp + "\nLast Seen: " + userinfo.LastSeen.Time + "\nFrom: " + platforms[userinfo.LastSeen.Platform], onlinestatus);
        }

        private void Actions_button_Click(object sender, EventArgs e)
        {
            User_Actions useractions = new User_Actions();
            useractions.Target_id = Target_id;
            useractions.Username = First_name.Text + " " + Last_name.Text;
            useractions.CanWritePM = userinfo.CanWritePrivateMessage;
            useractions.CanSendFriendRequest = userinfo.CanSendFriendRequest;
            useractions.FriendStatus = userinfo.FriendStatus.GetHashCode();
            useractions.InBlacklist = userinfo.BlacklistedByMe;
            useractions.Show();
        }
    }
}
