﻿using bloodbank.Properties;
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

        // For Dropdown Menu.
        private bool isCollapsed;

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

        private void supply_blood_btn_Click(object sender, EventArgs e)
        {
            sideActivePanel.Height = supply_blood_btn.Height;
            sideActivePanel.Top = supply_blood_btn.Top;
            supplybloodwindow1.BringToFront();
        }

        private void blooddonatebtn_Click(object sender, EventArgs e)
        {
            sideActivePanel.Height = blooddonatebtn.Height;
            sideActivePanel.Top = blooddonatebtn.Top;
            blooddonate1.BringToFront();
        }

        private void updatedonarpro_Click(object sender, EventArgs e)
        {
            sideActivePanel.Height = updatedonarpro.Height;
            sideActivePanel.Top = updatedonarpro.Top;
            updatedonarpro1.BringToFront();
        }
        
        private void searchdonarmenu_Click(object sender, EventArgs e)
        {
            sideActivePanel.Height = searchdonarmenu.Height;
            sideActivePanel.Top = searchdonarmenu.Top;
            searchdonarwindow1.BringToFront();
        }

        private void closethis(object sender, EventArgs e)
        {
            this.Close();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                dropdownbtn.Image = Resources.icons8_expand_arrow_30___up;
                paneldropdown.Height += 10;
                if (paneldropdown.Size == paneldropdown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                dropdownbtn.Image = Resources.icons8_expand_arrow_30;
                paneldropdown.Height -= 10;
                if (paneldropdown.Size == paneldropdown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void dropdownbtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        
    }
}
