using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace bloodbank
{
    public partial class searchdonarwindow : UserControl
    {
        public searchdonarwindow()
        {
            InitializeComponent();
        }

        private DataTable dt = new DataTable();

        private void searchdonarwindow_Load(object sender, EventArgs e)
        {
           // GetRecord();
        }
        

        private void namebox_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=donorAppDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM donorInfo WHERE name = '" + namebox.Text + "'";

            //Command Execute
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);
            //Showing data in the gridview
            donorrecordgridview.DataSource = dt;
            connection.Close();

            
            

        }

        private void searchbyaddress_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=donorAppDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM donorInfo WHERE address = '" + searchbyaddress.Text + "'";

            //Command Execute
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);
            //Showing data in the gridview
            donorrecordgridview.DataSource = dt;
            connection.Close();
        }

        private void searchbyid_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=donorAppDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM donorInfo WHERE donrid = '" + searchbyid.Text + "'";

            //Command Execute
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);
            //Showing data in the gridview
            donorrecordgridview.DataSource = dt;
            connection.Close();
        }

        private void searchbyblood_TextChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=donorAppDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM donorInfo WHERE bloodgroup = '" + searchbyblood.Text + "'";

            //Command Execute
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);
            //Showing data in the gridview
            donorrecordgridview.DataSource = dt;
            connection.Close();
        }
    }
}
