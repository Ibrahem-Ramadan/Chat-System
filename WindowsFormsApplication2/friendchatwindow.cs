using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Media;
namespace hello
{
    public partial class friendchatwindow : Form
    {
        private Emojis Emo2;
        private bool EmotionsPanelShow = false;
        public static Bubble bbl_old = new Bubble();
        private Message ObjMessage;
        private String AdminName;
        public String SetFriendlblTxt( String AdminName)
        {
            this.AdminName = AdminName;
            return this.AdminName;
        }
        public void SetFriendWindowTxt(String FriendName)
        {
            label1.Text = FriendName;
        }
        public friendchatwindow()
        {
            InitializeComponent();
            bbl_old.Top = 0 - bbl_old.Height + 10;
            this.message.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter); // press enter
            ObjMessage = new Message(this.message, this.panel2, this.bubble1, this.bottom);
            Emo2 = new Emojis(message);
            panel4.Visible = false; 
        }
        private void ViewEmotions_Click(object sender, EventArgs e)
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
        private void bunifuImageButton20_Click_1(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("1");
        }
        private void bunifuImageButton19_Click_1(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("2");
        }
        private void bunifuImageButton18_Click_1(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("3");
        }
        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("4");
        }
        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("5");
        }
        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("6");
        }
        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("7");
        }
        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("8");
        }
        private void bunifuImageButton17_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("9");
        }
        private void bunifuImageButton16_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("10");
        }
        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("11");
        }
        private void bunifuImageButton14_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("12");
        }
        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("13");
        }
        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("14");
        }
        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("15");
        }
        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            Emo2.PrintEmoji("16");
        }
        private void bunifuImageButton21_Click_1(object sender, EventArgs e)
        {
             MessageControl.IsSendClick2 = true;
             MessageControl.MessageFromFriendWindow = message.Rtf;
             ObjMessage.addInMessage(this);
             panel2.VerticalScroll.Value = panel2.VerticalScroll.Maximum; //scroll the chatbox down 
             message.Clear();
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
               
                MessageControl.IsSendClick2 = true;
                MessageControl.MessageFromFriendWindow = message.Rtf;
                ObjMessage.addInMessage(this);
                panel2.VerticalScroll.Value = panel2.VerticalScroll.Maximum; //scroll the chatbox down 
                message.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MessageControl.IsSendClick1)
            {
                MessageControl.IsSendClick1 = false;
                ObjMessage.SetMessage(MessageControl.MessageFromChatWindow);
                ObjMessage.addOutMessage(this , MessageControl.FriendbblName );
                SoundPlayer sound = new SoundPlayer("served.wav");
                sound.Play();
                MessageControl.MessageFromChatWindow = "";
                panel2.VerticalScroll.Value = panel2.VerticalScroll.Maximum; //scroll the chatbox down 
                message.Clear();
            }

            if (Nudge.IsNudge1)
            {
                Nudge n = new Nudge();
                n.NudgeFriendForm(this);
            }

        }
        private void NudgeButton_Click_1(object sender, EventArgs e)
        {
            Nudge.IsNudge2 = true;
            SoundPlayer sound = new SoundPlayer("msn_nudge_sound.wav");
            sound.Play();
        }
       
        private void SendImageBtn2_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Title = "Select Image";
            FD.Multiselect = false;
            FD.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult DR = FD.ShowDialog();
            if (DR == System.Windows.Forms.DialogResult.OK)
            {
                string[] fil = FD.FileNames;
                foreach (string img in fil)
                {
                    MessageControl.pic = new PictureBox();
                    MessageControl.pic.Image = Image.FromFile(img);
                }
            }
            MessageControl.IsImageClick1 = true;
            MessageControl.IsImageClick2 = true;
            MessageControl.IsSendClick2 = true;
            if (DR == System.Windows.Forms.DialogResult.Cancel)
               MessageControl.IsSendClick2 = false;
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
