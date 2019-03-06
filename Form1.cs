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
    }
}
