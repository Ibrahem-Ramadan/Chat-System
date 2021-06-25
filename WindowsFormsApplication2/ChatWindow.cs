using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.Collections;
using System.Media;

namespace hello
{
    public partial class ChatWindow : Form
    {
        private Message ObjMessage;
        private Emojis Emo1;
        private bool EmotionsPanelShow = false;
        public Contacts Master2;
        public String Admin;
        public String FriendName;
        public string lblName;
        public static Bubble bbl_old = new Bubble();
        public ChatWindow()
        {
            InitializeComponent();
            bbl_old.Top = 0 - bbl_old.Height + 10;
            this.message.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter); // press enter
            Emo1 = new Emojis(this.message);
            ObjMessage = new Message(this.message,this.panel2 , this.bubble1 , this.bottom );
            panel4.Visible = false;
          
        }   
        private void ViewEmotions_Click_1(object sender, EventArgs e)
        {
         
            if (!EmotionsPanelShow)
            {
                panel4.Visible = true;
                EmotionsPanelShow = true;
            }
                
            else if (EmotionsPanelShow)
            {
                panel4.Visible = false;
                EmotionsPanelShow = false;
            }
                
        }
        private void Emoj1_Click(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("1");
        }
        private void bunifuImageButton19_Click(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("2");
        }
        private void bunifuImageButton18_Click(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("3");
        }
        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("4");
        }
        private void bunifuImageButton9_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("5");
        }
        private void bunifuImageButton8_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("6");
        }
        private void bunifuImageButton7_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("7");
        }
        private void bunifuImageButton6_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("8");
        }
        private void bunifuImageButton17_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("9");
        }
        private void bunifuImageButton16_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("10");
        }
        private void bunifuImageButton15_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("11");
        }
        private void bunifuImageButton14_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("12");
        }
        private void bunifuImageButton13_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("13");
        }
        private void bunifuImageButton12_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("14");
        }
        private void bunifuImageButton11_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("15");
        }
        private void bunifuImageButton10_Click_1(object sender, EventArgs e)
        {
            Emo1.PrintEmoji("16");
        }
        private void bunifuImageButton21_Click(object sender, EventArgs e)
        {
            MessageControl.IsSendClick1 = true;
            MessageControl.MessageFromChatWindow = message.Rtf;
            message.Rtf = MessageControl.MessageFromChatWindow;
            ObjMessage.addInMessage(this);
            panel2.VerticalScroll.Value = panel2.VerticalScroll.Maximum; //scroll the chatbox down
            message.Clear();
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MessageControl.IsSendClick1 = true;
                MessageControl.MessageFromChatWindow = message.Rtf;
                message.Rtf = MessageControl.MessageFromChatWindow;
                ObjMessage.addInMessage(this);
                panel2.VerticalScroll.Value = panel2.VerticalScroll.Maximum; //scroll the chatbox down
                message.Clear();
            }
        }
        public void SetMasterForm(Contacts m)
        {
            this.Master2 = m;
           
        }
        public void SetAdminFromForm1 (String AdminName)
        {
            this.Admin = AdminName;
        }
        public void GetFriendName(String Friend)
        {
            this.FriendName = Friend;
        }
        private void ChatWindow_Load(object sender, EventArgs e)
        {
            
            //label1.Text = this.Text;
            User user1 = new User();
           // MessageControl.FriendbblName = label1.Text;
            label4.Text = lblName;
            for (int i = 0; i < Master2.GetListOfContacts().Count; i++)
            {
                
                if (Master2.GetListOfContacts()[i] != FriendName)
                {
                    BunifuFlatButton lb2 = new BunifuFlatButton();
                    lb2.Text = Master2.GetListOfContacts()[i];
                    lb2.Iconimage = Master2.getlistimage()[i];
                    lb2.Height = 50;
                    lb2.IconMarginLeft = 15;
                    lb2.IconZoom = 80;
                    lb2.Activecolor = Color.FromArgb(1, 0, 6);
                    lb2.Normalcolor = Color.FromArgb(53, 96, 66);
                    lb2.OnHovercolor = Color.FromArgb(3, 0, 19);
                    lb2.TextFont = new System.Drawing.Font("Tahoma", 12);
                    Contacts.Controls.Add(lb2);
                    lb2.Click += (f, g) =>
                    {
                       
                        friendchatwindow FriendChatWindow = new friendchatwindow();
                        FriendChatWindow.SetFriendWindowTxt(lb2.Text);
                        FriendChatWindow.Show();
                    };

                  
                }
            }
        }
       
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MessageControl.IsSendClick2)
            {
                MessageControl.IsSendClick2 = false;
               
               
                ObjMessage.SetMessage(MessageControl.MessageFromFriendWindow);
                ObjMessage.addOutMessage(this , this.FriendName);
                SoundPlayer sound = new SoundPlayer("served.wav");
                sound.Play();
                MessageControl.MessageFromFriendWindow = "";
                panel2.VerticalScroll.Value = panel2.VerticalScroll.Maximum; //scroll the chatbox down 
                message.Clear();
            }

            if(Nudge.IsNudge2)
            {
                Nudge n = new Nudge();
                n.NudgeFriendForm(this);
            }
            
        }
        private void NudgeButton_Click_1(object sender, EventArgs e)
        {
            Nudge.IsNudge1 = true;
            SoundPlayer sound = new SoundPlayer("msn_nudge_sound.wav");
            sound.Play();

        }
        private void SendImageBtn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Title = "Select Image";
            FD.Multiselect = false;
            FD.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult DR = FD.ShowDialog();
            if (DR == System.Windows.Forms.DialogResult.OK)
            {
                message.Clear();
                string[] fil = FD.FileNames;
                foreach (string img in fil)
                {
                    MessageControl.pic = new PictureBox();
                    MessageControl.pic.Image = Image.FromFile(img);
                }


            }

            MessageControl.IsImageClick1 = true;
            MessageControl.IsImageClick2 = true;
            MessageControl.IsSendClick1 = true;
            if (DR == System.Windows.Forms.DialogResult.Cancel)
                MessageControl.IsSendClick1 = false;
            else
                ObjMessage.addInMessage(this);

            panel2.VerticalScroll.Value = panel2.VerticalScroll.Maximum; //scroll the chatbox down 
            message.Clear();
        }
        

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


      
    }
}
