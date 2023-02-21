///<summary>
/// Jacob Lindauer
/// Created: 2023/01/31
/// 
/// Interface for DBConnection Class
/// </summary>
///
/// <remarks>
/// Updater Name:
/// Updated: 
/// 
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayerInterfaces
{
    public interface IDBConnection
    {
        SqlConnection GetDBConnection();
    }
}
