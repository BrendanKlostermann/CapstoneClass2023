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
using System;
using System.Data.SqlClient;
namespace DataAccessLayerInterfaces
{
    public interface IDBConnection
    {
        SqlConnection GetDBConnection();
    }
}
