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
    public partial class adddonarwindow : UserControl
    {

        public adddonarwindow()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            //Pickup The Data Form Forum
            string donorId = donor_id.Text;
            string donorName = donor_name.Text;
            string donorAge = donor_age.Text;
            string donorMobile = mobile_input.Text;
            string email = email_input.Text;
            string address = address_input.Text;
            string lastdonation = last_donation.Value.ToString();

            string connectionString = "Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            // Gender Checked
            string gender = "";
            if(male_radiobtn.Checked)
            {
                gender = male_radiobtn.Text;
            }
            if(female_radiobtn.Checked)
            {
                gender = female_radiobtn.Text;
            }
            
            

            string query = "INSERT INTO a VALUES('" + donorId + "', '" + donorName + "', '" + gender + "', '" + donorAge + "', '" + donorMobile + "', '" + email + "',  '" + lastdonation + "', '" + address + "')";

            //Command Execute
            SqlCommand command = new SqlCommand(query, connection);

            //Connection Open
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            if(rowAffected > 0)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        // Profile Image Upload
        private void upload_img_btn_Click(object sender, EventArgs e)
        {
            string imgLocation = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imag Files (*.jpg;*.jpeg;.*.gif;)|*.jpg";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }
    }
}
