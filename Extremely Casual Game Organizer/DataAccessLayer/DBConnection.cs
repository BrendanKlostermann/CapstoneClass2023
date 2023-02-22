
﻿/// <DataBaseConnection>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to access the database
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayerInterfaces;

namespace DataAccessLayer
{
    public class DBConnection : IDBConnection
    {
        public SqlConnection GetDBConnection()
        {
            SqlConnection conn = null;

            string connectionString = @"Data Source=Localhost;Initial Catalog=ecgo_db;Integrated Security=True";

            conn = new SqlConnection(connectionString);

            return conn;
        }
    }
}
