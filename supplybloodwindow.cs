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
    public partial class supplybloodwindow : UserControl
    {
        public supplybloodwindow()
        {
            InitializeComponent();
        }

        private void supplybloodwindow_Load(object sender, EventArgs e)
        {
            GetRecord();
        }
        private void GetRecord()
        {
            string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=donorAppDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM bloodSupply";

            //Command Execute
            SqlCommand command = new SqlCommand(query, connection);

            DataTable dt = new DataTable();

            connection.Open();

            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);
            connection.Close();

            //Showing data in the gridview
            supplybloodgridview.DataSource = dt;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {

            if (IsValid())
            {
                //Pickup The Data Form Forum
                string Name = donor_name.Text;
                string donorMobile = mobile_input.Text;
                string email = email_input.Text;
                string address = address_input.Text;
                string lastdonation = last_donation.Value.ToString();


                string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=donorAppDb;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionString);



                // Blood Selected
                string blood = "";
                if (blood_combobox.Text == "A+")
                {
                    blood = "A+";
                }

                if (blood_combobox.Text == "O+")
                {
                    blood = "O+";
                }

                if (blood_combobox.Text == "B+")
                {
                    blood = "B+";
                }
                if (blood_combobox.Text == "AB+")
                {
                    blood = "AB+";
                }
                if (blood_combobox.Text == "A-")
                {
                    blood = "A-";
                }

                if (blood_combobox.Text == "O-")
                {
                    blood = "O-";
                }

                if (blood_combobox.Text == "B-")
                {
                    blood = "B-";
                }
                if (blood_combobox.Text == "AB-")
                {
                    blood = "AB-";
                }

                // City Selected
                string citySelected = "";
                if (city_combobox.Text == "Dhaka")
                {
                    citySelected = "Dhaka";
                }
                if (city_combobox.Text == "Khulna")
                {
                    citySelected = "Khulna";
                }

                string query = "INSERT INTO bloodSupply VALUES('" + Name + "', '" + blood + "', '" + donorMobile + "', '" + email + "', '" + citySelected + "',  '" + address + "', '" + lastdonation + "')";

                //Command Execute
                SqlCommand command = new SqlCommand(query, connection);

                //Connection Open
                connection.Open();

                int rowAffected = command.ExecuteNonQuery();

                connection.Close();

                if (rowAffected > 0)
                {
                    MessageBox.Show("Data Successfully Saved", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetRecord();

                }
                else
                {
                    MessageBox.Show("Failed");
                }

            }
            
            
        }

        private bool IsValid()
        {
            if(donor_name.Text == string.Empty)
            {
                MessageBox.Show("Name Is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
