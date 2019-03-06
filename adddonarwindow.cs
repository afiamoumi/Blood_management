using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bloodbank
{
    public partial class adddonarwindow : UserControl
    {
        // Db Connection
        private void DBConnection()
        {
            string ConnectString = "datasource = localhost; username = root; password = ; database = blood_bank";
            MySqlConnection DBConnect = new MySqlConnection(ConnectString);
            try
            {
                DBConnect.Open();
                MessageBox.Show("Ok You are Connected");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public adddonarwindow()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            DBConnection();
        }
        

    }
}
