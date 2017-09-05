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
    public partial class User_Actions : Form
    {
        public long Target_id;
        VkApi api = GlobalVars.api;
        public string Username;
        public bool CanWritePM;
        public bool CanSendFriendRequest;
        public int FriendStatus;
        public bool InBlacklist;
        public User_Actions()
        {
            InitializeComponent();
        }

        private void User_Actions_Load(object sender, EventArgs e)
        {
            Usernameplace.Text = Username;
            Usernameplace.AutoSize = true;
            UserID.Text = Target_id.ToString();
            UserID.AutoSize = true;
            CanPM.Text = CanWritePM.ToString();
            Perm_SendFriendReq.Text = CanSendFriendRequest.ToString();
            FirendStatus.Text = FriendStatus.ToString();
            Blacklisted.Text = InBlacklist.ToString();
            this.Text = Username + "[id" + Target_id + "]";
            if (!CanWritePM)
            {
                Message_button.Enabled = false;
            }
            if(FriendStatus == 0)
            {
                Friend_Button.Text = "Send Friend Request";
                if (!CanSendFriendRequest)
                {
                    Friend_Button.Enabled = false;
                }
            }
            if(FriendStatus == 1)
            {
                Friend_Button.Text = "Delete outgoing request";
            }
            if(FriendStatus == 2)
            {
                Friend_Button.Text = "Accept/Ignore Incomming Request";
            }
            if(FriendStatus == 3)
            {
                Friend_Button.Text = "Remove From Friends";
            }
            if (InBlacklist)
            {
                Block_Button.Text = "Remove From Blacklist";
            }
            else
            {
                Block_Button.Text = "Ban user";
            }
        }

        private void Friend_Button_Click(object sender, EventArgs e)
        {
            if(FriendStatus == 0)
            {
                DialogResult dialog = MessageBox.Show("Do you wanna create friend request?", "Add to friends", MessageBoxButtons.YesNo);
                if(dialog == DialogResult.Yes)
                {
                    api.Friends.Add(Target_id);
                    MessageBox.Show("Request send.");
                }
            }
            else if(FriendStatus == 1)
            {
                DialogResult dialog = MessageBox.Show("Do you wanna to delete outcome request?", "Confirm action", MessageBoxButtons.YesNo);
                if(dialog == DialogResult.Yes)
                {
                    api.Friends.Delete(Target_id);
                    MessageBox.Show("Done");
                }
            }
            else if(FriendStatus == 2)
            {
                DialogResult dialog = MessageBox.Show("Do you wanna accept user request?\nNo will add user to followers, cancel do nothing.", "Accept Friend Request?", MessageBoxButtons.YesNoCancel);
                if(dialog == DialogResult.Yes)
                {
                    api.Friends.Add(Target_id);
                    MessageBox.Show(Username + " is now your friend!");
                }
                else if(dialog == DialogResult.No)
                {
                    api.Friends.Delete(Target_id);
                    MessageBox.Show(Username + " is now your follower!");
                }
            }
            else if(FriendStatus == 3)
            {
                DialogResult dialog = MessageBox.Show("Do you wanna remove " + Username + " from friends?", "Confirm action", MessageBoxButtons.YesNo);
                if(dialog == DialogResult.Yes)
                {
                    api.Friends.Delete(Target_id);
                    MessageBox.Show(Username + " is now your follower!", "Friend deleted");
                }
            }
        }

        private void Block_Button_Click(object sender, EventArgs e)
        {
            if (InBlacklist)
            {
                DialogResult dialog = MessageBox.Show("Remove user from blacklist?", "Confirm action", MessageBoxButtons.YesNo);
                if(dialog == DialogResult.Yes)
                {
                    api.Account.UnbanUser(Target_id);
                    MessageBox.Show(Username + " removed from blacklist");
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Ban user?", "Confirm action", MessageBoxButtons.YesNo);
                if(dialog == DialogResult.Yes)
                {
                    api.Account.BanUser(Target_id);
                    MessageBox.Show("User banned!");
                }
            }
        }
    }
}
