using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    public class MethodsForDB
    {
        public static void Create(string connection)
        {
            var connect = Connection;
            string query = connection;
            var command = new SqlCommand(query, connect);
            connect.Open();
            command.ExecuteNonQuery();
        }

        public static void Delete(string connection)
        {
            var connect = Connection;
            string query = connection;
            var command = new SqlCommand(query, connect);
            connect.Open();
            command.ExecuteNonQuery();
        }

        public static SqlConnection Connection
        {
            get
            {
                var myConnection = new SqlConnection("Data Source=DESKTOP-FOP3P08;Initial Catalog=DesignerReporterBD;Integrated Security=True");
                return myConnection;
            }
        }
    }

}
