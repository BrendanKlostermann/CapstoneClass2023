/// <DataBaseConnection>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to access the database
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>



using DataAccessLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DBConnection : IDBConnection
    {
        public SqlConnection GetDBConnection()
        {
            SqlConnection _conn = null;

            string connectionString = @"Data Source=localhost;Initial Catalog=ecgo_db;Integrated Security=True";
            _conn = new SqlConnection(connectionString);

            return _conn;
        }
    }
}
