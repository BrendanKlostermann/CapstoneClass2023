


using System;
using System.Data.SqlClient;
/// <IDataBaseConnection>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This is the interface for getting a data base connection
///
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
/// 
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
namespace DataAccessLayerInterfaces
{
    public interface IDBConnection
    {
        SqlConnection GetDBConnection();
    }
}
