using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBConnection
    {
        public SqlConnection GetDBConnection()
        {
            SqlConnection conn = null;
            string connectionString = @"Data Source=localhost;Initial Catalog=ecgo_db;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
