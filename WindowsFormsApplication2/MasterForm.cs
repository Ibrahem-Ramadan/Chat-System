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


namespace hello
{
    public partial class MasterForm : Form
    {
        private Contacts Master = new Contacts();
        private User user = new User();
        public MasterForm()
        {
            Thread t = new Thread(new ThreadStart(sp));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            Application.Exit();
            this.bunifuMaterialTextbox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);
         }
        public void sp()
        {
            Application.Run(new Form2());
        }
        public void AddControls()
        {
           
 /////////////////////////////////////////////////creat dynamic image for user/////////////////////////////////////////  
            PictureBox PIC = new PictureBox();         
            Panel Obj = new Panel();
            OpenFileDialog a = new OpenFileDialog();
            a.Title = "select image";
            a.Multiselect = false;
            a.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult dr = a.ShowDialog();
            Obj.Width = 50;
            Obj.Height = 50;
            flowLayoutPanel1.Controls.Add(Obj);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string[] fil = a.FileNames;
                //l for dii 3shan y2dar y select aktr mn sora 3adi
                foreach (string img in fil)
                {
                    PIC = new PictureBox();
                    PIC.Image = Image.FromFile(img);
                    PIC.Dock = DockStyle.Fill;
                    PIC.SizeMode = PictureBoxSizeMode.Zoom;
                    Obj.Controls.Add(PIC);
                }
            }
////////////////////////////////creat dynamic user name for user /////////////////////////////////
            Label lb = new Label();
            lb.Text = bunifuMaterialTextbox1.Text;
            lb.Font = new System.Drawing.Font("Tahoma", 12);
            lb.ForeColor = System.Drawing.Color.White;
            lb.Font = new Font(lb.Font, FontStyle.Bold);
            lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lb.Height = 50;
            lb.Width = 150;
            flowLayoutPanel1.Controls.Add(lb);
////////////////////////////////creat dynamic launch button for user //////////////////////////////
            BunifuThinButton2 Launch = new BunifuThinButton2();
            Launch.Text = "Launch";
            Launch.Width = 120;
            Launch.Height = 50;
            Launch.ButtonText = "launch";
            Launch.BackColor = System.Drawing.Color.Transparent;
            Launch.ForeColor = System.Drawing.Color.White;
            Launch.Font = new System.Drawing.Font("Tahoma", 10);
            flowLayoutPanel1.Controls.Add(Launch);
///////////////////////////////creat dynamic delete button for user////////////////////////////////
            BunifuThinButton2 Delete = new BunifuThinButton2();
            Delete.Text = "Delete";
            Delete.Width = 120;
            Delete.Height = 50;
            Delete.ButtonText = "Delete";
            Delete.BackColor = System.Drawing.Color.Transparent;
            Delete.ForeColor = System.Drawing.Color.White;
            Delete.Font = new System.Drawing.Font("Tahoma", 10);
            flowLayoutPanel1.Controls.Add(Delete);
            Master.AddContact(lb.Text);             // add to Master List
            Master.addimage(PIC);
          
///////////////////////////////////////////dynamic launch click event /////////////////////////////////////////////////////////

            Launch.Click += (f, g) =>
            {

               ChatWindow AdminWindow = new ChatWindow();
               
               AdminWindow.Text = user.getAdmin();
               AdminWindow.lblName = lb.Text;
               AdminWindow.SetMasterForm(Master);
               AdminWindow.SetAdminFromForm1(user.getAdmin());
               AdminWindow.GetFriendName(lb.Text);
               AdminWindow.Show();
               
            };

            

/////////////////////////////dynamic delete click event///////////////////////////////////////////////////////////////////////////
            Delete.Click += (s , e) =>
            {
                DialogResult result = MessageBox.Show("Are You sure You Want To Delete This User ?!", "Deleting User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    flowLayoutPanel1.Controls.Remove(lb);
                    flowLayoutPanel1.Controls.Remove(Launch);
                    flowLayoutPanel1.Controls.Remove(Delete);
                    flowLayoutPanel1.Controls.Remove(PIC);
                    flowLayoutPanel1.Controls.Remove(Obj);
                    Master.DeleteContact(lb.Text);  // Delete From MAster List
                }
                
            };
            
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            if (bunifuMaterialTextbox1.Text != "")
            {
             
                AddControls();
                bunifuMaterialTextbox1.ForeColor = Color.White;
                bunifuMaterialTextbox1.Text = "";

            }
            else
                MessageBox.Show("Please Enter User Name !", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (bunifuMaterialTextbox1.Text != "")
                {
                    AddControls();
                    bunifuMaterialTextbox1.Text = "";
                }
                else
                    MessageBox.Show("Please Enter User Name !", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
