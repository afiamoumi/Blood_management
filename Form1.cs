using bloodbank.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bloodbank
{
    public partial class Form1 : Form
    {
        int TogMove;
        int MValX;
        int MValY;

        public Form1()
        {
            InitializeComponent();
            sideActivePanel.Height = homebtn.Height;
            homewindow1.BringToFront();
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            sideActivePanel.Height = homebtn.Height;
            sideActivePanel.Top = homebtn.Top;
            homewindow1.BringToFront();
        }
        private void addDonarbtn_Click(object sender, EventArgs e)
        {
            sideActivePanel.Height = addDonarbtn.Height;
            sideActivePanel.Top = addDonarbtn.Top;
            adddonarwindow1.BringToFront();
        }
        private void donorListbtn_Click(object sender, EventArgs e)
        {
            sideActivePanel.Height = donorListbtn.Height;
            sideActivePanel.Top = donorListbtn.Top;
            donarlistwindow1.BringToFront();
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
    }
}
