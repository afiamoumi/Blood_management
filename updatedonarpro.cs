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

        // Id for donor
        public int donorId;


        private void button1_Click(object sender, EventArgs e)
        {
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

        private void donorrecordgridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donorId = Convert.ToInt32(donorrecordgridview.SelectedRows[0].Cells[0].Value);
            donor_name.Text = donorrecordgridview.SelectedRows[0].Cells[2].Value.ToString();
            mobile_input.Text = donorrecordgridview.SelectedRows[0].Cells[6].Value.ToString();
            email_input.Text = donorrecordgridview.SelectedRows[0].Cells[7].Value.ToString();
            address_input.Text = donorrecordgridview.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if(donorId > 0)
            {
                
                

                string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionString);

                string query = "UPDATE h SET name = @name, mobile = @mobile, email = @email, address = @address WHERE id = @ID";

                //Command Execute
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", donor_name.Text);
                command.Parameters.AddWithValue("@mobile", mobile_input.Text);
                command.Parameters.AddWithValue("@email", email_input.Text);
                command.Parameters.AddWithValue("@address", address_input.Text);
                command.Parameters.AddWithValue("@ID", this.donorId);

                //Connection Open
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
                
                MessageBox.Show("Donor Information Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetRecord();
                
            }
            else
            {
                MessageBox.Show("Please Select One From the Gridview", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleted_btn(object sender, EventArgs e)
        {
            if ( donorId > 0)
            {
                string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionString);

                string query = "DELETE FROM h WHERE id = @ID";

                //Command Execute
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", this.donorId);

                //Connection Open
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Deleted");
                GetRecord();

            }
            else
            {
                MessageBox.Show("Select Which Info you wnat to delete?", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            donorId = 0;
            donor_name.Clear();
            mobile_input.Clear();
            email_input.Clear();
            address_input.Clear();
            donor_name.Focus();
        }
    }
}
