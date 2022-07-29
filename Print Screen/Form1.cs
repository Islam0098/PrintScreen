using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Print_Screen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTakeScreenShot_Click(object sender, EventArgs e)
        {
            int left=int.Parse(textBox1.Text);
            int top=int.Parse(textBox2.Text);
            int right=int.Parse(textBox3.Text);
            int bottom=int.Parse(textBox4.Text);

            
            if (picName.Text == "")
            {
                MessageBox.Show("Enter Pic Name");
                picName.Focus();
            }
            else
            {
                int ynow = this.Top;
                this.Top = Screen.PrimaryScreen.Bounds.Height + 1000;
                Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
                Graphics graph = Graphics.FromImage(bmp);
                graph.CopyFromScreen(left, top, right, bottom, bmp.Size);
                bmp.Save(picName.Text+".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                this.Top = ynow;

                System.Diagnostics.Process.Start(picName.Text+".Jpeg");
            }
        }
    }
}
