using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hello
{
    public partial class Bubble : UserControl
    {
           public Bubble()
           {
              InitializeComponent();
              DateTime now = DateTime.Now;
              lbltime.Text = now.DayOfWeek.ToString() + "   " + now.ToShortTimeString();

           }
           public Bubble(RichTextBox message )
           {

               DateTime now = DateTime.Now ;
               InitializeComponent();
               lblmessgae.Rtf = message.Rtf;
               
               lbltime.Text = now.DayOfWeek.ToString() + "   " + now.ToShortTimeString();

               //incoming message
               if (MessageControl.IsImageClick1 == true)
               {
                   panel4.Visible = true;
                   panel4.Height = 300;
                   panel4.Width = 300;
                   panel4.BackgroundImage = MessageControl.pic.Image;
                   MessageControl.IsImageClick1 = false;
               }
               this.BackColor = Color.FromArgb(3, 0, 17);
               lblmessgae.BackColor = Color.FromArgb(3, 0, 17);
               T1.LineColor = Color.FromArgb(38, 169, 224);
               T2.LineColor = Color.FromArgb(38, 169, 224);
               L1.BackColor = Color.FromArgb(38, 169, 224);
               R1.BackColor = Color.FromArgb(38, 169, 224);
               B1.BackColor = Color.FromArgb(38, 169, 224);
               Setheight();

           }
           public Bubble(string message , String FriendName)
           {
               DateTime now = DateTime.Now;
               InitializeComponent();
               
               lblmessgae.Rtf = message;
               lbltime.Text = now.DayOfWeek.ToString() + "   " + now.ToShortTimeString();

               //Outgoing Message
               if (MessageControl.IsImageClick2 == true)
               {
                   panel4.Visible = true;
                   panel4.Height = 300;
                   panel4.Width = 300;
                   panel4.BackgroundImage = MessageControl.pic.Image;
                   MessageControl.IsImageClick2 = false;
               }

               this.BackColor = Color.FromArgb(3, 0, 17);
               lblmessgae.BackColor = Color.FromArgb(3, 0, 17);
               T1.LineColor = Color.FromArgb(240, 90, 40);
               T2.LineColor = Color.FromArgb(240, 90, 40);
               L1.BackColor = Color.FromArgb(240, 90, 40);
               R1.BackColor = Color.FromArgb(240, 90, 40);
               B1.BackColor = Color.FromArgb(240, 90, 40);
               Setheight();
           }    
          //lets add the function which adjusts the bubble height
           void Setheight()
             {
                 Size maxSize = new Size(495, int.MaxValue);
                 Graphics g = CreateGraphics();
                 SizeF size = g.MeasureString(lblmessgae.Text, lblmessgae.Font, 528);
                 lblmessgae.Height = int.Parse(Math.Round(size.Height + 40 , 0).ToString());
            }
           private void bubble_Resize(object sender, EventArgs e)
           {
                 Setheight();
           }

          
      }     
}
