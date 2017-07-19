using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structura.GuiTests.Utilities
{
    class DBMethods
    {

        public string VerifyUserInDatabase()
        {
            String user = String.Empty;
            var con = @"Data Source=MAREK\SQLEXPRESS01;Initial Catalog=trening;Integrated Security=True";

            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT Id FROM dbo.sprzedarz WHERE Produktid = 1 AND Ilosc = 4";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                // oCmd.Parameters.AddWithValue("@newusername", usernameToVerify);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        user = oReader["Id"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return user;
        }

    }
}
