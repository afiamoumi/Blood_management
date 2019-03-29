using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bloodbank
{
    class dbconnect
    {
        public static SqlConnection conn = null;

        public void db_connection()
        {
            conn = new SqlConnection("Data Source=DESKTOP-SL46HBO\\SQLEXPRESS;Initial Catalog=donorAppDb;Integrated Security=True");
            conn.Open();
        }
    }
}
