using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bloodbank
{
    public partial class updatedonarpro : UserControl
    {
        public updatedonarpro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string u_name = donor_name.Text;
            string u_mobile = mobile_input.Text;
            string u_email = email_input.Text;
            string u_address = address_input.Text;


            string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            //string query = "UPDATE INTO d SET('" + u_name + "', '" + u_mobile + "', '"+ u_email + "', '"+ u_address + "')" WHERE donorid = 5;

        }

        private void updatedonarpro_Load(object sender, EventArgs e)
        {
            GetRecord();
        }

        private void GetRecord()
        {
            string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM h";

            //Command Execute
            SqlCommand command = new SqlCommand(query, connection);

            DataTable dt = new DataTable();

            connection.Open();

            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);
            connection.Close();
            
            //Showing data in the gridview
            donorrecordgridview.DataSource = dt;
        }

        private void donorrecordgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetRecord();
        }
    }
}
