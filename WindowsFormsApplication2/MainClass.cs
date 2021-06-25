using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Bunifu.Framework.UI;
using System.Collections;
namespace hello
{  
    public class MessageControl
    {
        public static string MessageFromChatWindow;
        public static string MessageFromFriendWindow;

        public static PictureBox pic;

        public static bool IsImageClick1;
        public static bool IsImageClick2;

        public static bool IsSendClick1;
        public static bool IsSendClick2;

        public static String FriendbblName;
    }
    public class User
    {
        private String UserName;
        private String Admin;
        public User() { }
        public void setUser(String userName)
        {
            this.UserName = userName;
        }
        public String getUser()
        {
            return UserName;
        }
        public void setAdmin(String AdminName)
        {
            this.Admin = AdminName;
        }
        public String getAdmin()
        {
            return Admin; 
        }
    }
    public class Contacts
    {

        private List<String> listOfContacts;
        private List<Image> imageofcontact;
        public Contacts()
        {
            listOfContacts = new List<String>();
            imageofcontact = new List<Image>();
        }
        public List<String> GetListOfContacts()
        {
            return listOfContacts;
        }
        public List<Image> getlistimage()
        {
            return imageofcontact ;
        }
        public void AddContact(String name)
        {
            listOfContacts.Add(name);
        }
        public void DeleteContact(String name)
        {
            listOfContacts.Remove(name);
        }
        public void addimage(PictureBox pic)
        {
            imageofcontact.Add(pic.Image);

        }

        public void Deleteimage(PictureBox PIC)
        {
            imageofcontact.Remove(PIC.Image);
        }
    }
    public class Message
    {
        private String getMessage;
        private Panel getPanel;
        private Bubble getBubble;
        private PictureBox getBottom;

        protected RichTextBox getRichBox;
        protected Message() { }
        public Message(RichTextBox Obj, Panel panel2, Bubble bubble1  ,PictureBox bottom )
        {
            this.getRichBox = Obj;
            this.getPanel = panel2;
            this.getBubble = bubble1;
            this.getBottom = bottom;
        }
        public void SetMessage(String  message)
        {
            this.getMessage = message;
        }
        public void addInMessage (Form Type)
        {
            
            if (Type.Name == "ChatWindow")
            {
                Bubble bbl = new hello.Bubble(getRichBox);
                bbl.Location = getBubble.Location; bbl.Left += 50; //add intent
                bbl.Top = ChatWindow.bbl_old.Bottom + 10;
                getPanel.Controls.Add(bbl);
                getBottom.Top = bbl.Bottom + 50;
                ChatWindow.bbl_old = bbl;  //save the last added object
            }
            else
            {
                Bubble bbl = new hello.Bubble(getRichBox);
                bbl.Location = getBubble.Location; bbl.Left += 50; //add intent
                bbl.Top = friendchatwindow.bbl_old.Bottom + 10;
                getPanel.Controls.Add(bbl);
                getBottom.Top = bbl.Bottom + 50;
                friendchatwindow.bbl_old = bbl;  //save the last added object

            }

        }
        public void addOutMessage(Form Type , String Friend_Name)
        {
            if (Type.Name == "ChatWindow")
            {
                Bubble bbl = new hello.Bubble(getMessage , Friend_Name);
                bbl.Location = getBubble.Location;
                bbl.Top = ChatWindow.bbl_old.Bottom + 10;
                getPanel.Controls.Add(bbl);
                getPanel.VerticalScroll.Value = getPanel.VerticalScroll.Maximum;
                ChatWindow.bbl_old = bbl; //save the last added object
            }
            else
            {
                Bubble bbl = new hello.Bubble(getMessage , Friend_Name );
                bbl.Location = getBubble.Location;
                bbl.Top = friendchatwindow.bbl_old.Bottom + 10;
                getPanel.Controls.Add(bbl);
                getPanel.VerticalScroll.Value = getPanel.VerticalScroll.Maximum;
                friendchatwindow.bbl_old = bbl; //save the last added object
            }
        }

    }
    public class Emojis : Message 
    {
        private Hashtable Emoji;
        public Emojis(RichTextBox Obj)
        {
            getRichBox = Obj;
            Emoji = new Hashtable(16);
            Emoji.Add("1", hello.Properties.Resources._1);
            Emoji.Add("2", hello.Properties.Resources._2);
            Emoji.Add("3", hello.Properties.Resources._3);
            Emoji.Add("4", hello.Properties.Resources._4);
            Emoji.Add("5", hello.Properties.Resources._5);
            Emoji.Add("6", hello.Properties.Resources._6);
            Emoji.Add("7", hello.Properties.Resources._7);
            Emoji.Add("8", hello.Properties.Resources._8);
            Emoji.Add("9", hello.Properties.Resources._9);
            Emoji.Add("10", hello.Properties.Resources._10);
            Emoji.Add("11", hello.Properties.Resources._11);
            Emoji.Add("12", hello.Properties.Resources._12);
            Emoji.Add("13", hello.Properties.Resources._13);
            Emoji.Add("14", hello.Properties.Resources._14);
            Emoji.Add("15", hello.Properties.Resources._15);
            Emoji.Add("16", hello.Properties.Resources._16);
        }
        public void PrintEmoji(String Key)
        {
            Clipboard.SetImage((Image)Emoji[Key]);
            this.getRichBox.Paste();
        }
    }
    public class Nudge : Message
    {
        public static bool IsNudge1;
        public static bool IsNudge2;
        public Nudge()
        {
            IsNudge1 = false;
            IsNudge2 = false;
        }
        public void NudgeFriendForm(Form obj)
        {

            // An integer for storing the random number each time
            int rnd = 0;
            int xAxis = obj.Left;
            int yAxis = obj.Top;
            // Instantiate the random generation mechanism
            Random Vibration = new Random();

            for (int i = 0; i <= 500; i++)
            {
                rnd = Vibration.Next(xAxis + 1, xAxis + 20); // return an integer value within given range
                obj.Left = rnd;
                rnd = Vibration.Next(yAxis + 1, yAxis + 10);
                obj.Top = rnd;
            }

            // Restore the original location of the form
            obj.Left = xAxis;
            obj.Top = yAxis;
        }

    }
}
