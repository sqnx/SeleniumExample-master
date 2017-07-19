using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Selenium.core
{
    public partial class DBConnection
    {
        public void connectDB()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MAREK\SQLEXPRESS01;Initial Catalog=trening;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.sprzedarz");
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{1}, {0}", reader.GetString(0), reader.GetString(1));
            }
            reader.Dispose();
            con.Close();
        }
    }


}
