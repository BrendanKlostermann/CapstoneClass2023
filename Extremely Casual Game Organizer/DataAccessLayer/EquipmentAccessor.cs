/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// </summary>
using DataAccessLayerInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EquipmentAccessor : IEquipmentAccessor
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/04
        /// 
        /// Adding new equipment for a team
        /// </summary>
        public int AddTeamEquipment(Equipment equipmentList)
        {
            // return object
            int rowsAffected = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            string commandText = @"sp_insert_team_equipment";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@description", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@sport_id", SqlDbType.Int);
            cmd.Parameters.Add("@quantity", SqlDbType.Int);
            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@quantity"].Value = equipmentList.Quantity;
            cmd.Parameters["@team_id"].Value = equipmentList.TeamID;
            cmd.Parameters["@sport_id"].Value = equipmentList.SportID;
            cmd.Parameters["@description"].Value = equipmentList.Description;

            try
            {
                // open the connection
                conn.Open();

                // Execute the command and capture the results
                // three basic execution modes:
                // .ExecuteReadet() returns row/column data (normal select statements)
                // .ExecuteNonQuery() returns Int32 rows affected (action statements (update/delete/insert))
                // .ExecuteScalar() returns a System.Object (aggregate queries)
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot add team");
            }
            finally
            {
                conn.Close();
            }

            // return the result
            return rowsAffected;
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Remove the equipment that is no more needed
        /// </summary>
        public int DeleteTeamEquipment(Equipment equipmentList)
        {
            // return object
            int rowsAffected = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            string commandText = @"sp_delete_team_equipment";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@equipment_id", SqlDbType.Int);
            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@equipment_id"].Value = equipmentList.EquipmentID;
            cmd.Parameters["@team_id"].Value = equipmentList.TeamID;

            try
            {
                // 8. open the connection
                conn.Open();

            // 9. Execute the command and capture the results
            // three basic execution modes:
            // .ExecuteReadet() returns row/column data (normal select statements)
            // .ExecuteNonQuery() returns Int32 rows affected (action statements (update/delete/insert))
            // .ExecuteScalar() returns a System.Object (aggregate queries)
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not find data", ex);
            }
            finally
            {
                conn.Close();
            }

            // return the result
            return rowsAffected;
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/04
        /// 
        /// Get all equipments by team_id
        /// </summary>
        public List<Equipment> SelectEquipmentListsByTeamID(int team_id, string name)
        {
            List<Equipment> equipmentLists = new List<Equipment>();

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            var cmdText = "sp_select_team_equipment_by_name_or_sport_name_by_team_id";

            // command
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@name"].Value = name;
            cmd.Parameters["@team_id"].Value = team_id;

            try
            {
                // open the connection
                conn.Open();

                // execute the command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Equipment tournament = new Equipment()
                        {
                            SportID = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            EquipmentID = reader.GetInt32(2),
                            TeamID = reader.GetInt32(3),
                            Quantity = reader.GetInt32(4),
                            SportName = reader.GetString(5)
                        };

                        equipmentLists.Add(tournament);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return equipmentLists;
        }


        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/04
        /// 
        /// Update the name, the quantity and/or sport of the equipment
        /// </summary>
        public int UpdateTeamEquipment(Equipment equipmentList)
        {
            // return object
            int rowsAffected = 0;

            // connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            // command text
            string commandText = @"sp_update_team_equipment";

            // command
            var cmd = new SqlCommand(commandText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@equipment_id", SqlDbType.Int);
            cmd.Parameters.Add("@quantity", SqlDbType.Int);
            cmd.Parameters.Add("@sport_id", SqlDbType.Int);
            cmd.Parameters.Add("@description", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@equipment_id"].Value = equipmentList.EquipmentID;
            cmd.Parameters["@quantity"].Value = equipmentList.Quantity;
            cmd.Parameters["@sport_id"].Value = equipmentList.SportID;
            cmd.Parameters["@description"].Value = equipmentList.Description;
            cmd.Parameters["@team_id"].Value = equipmentList.TeamID;
            

            try
            {
                // 8. open the connection
                conn.Open();

            // 9. Execute the command qnd capture the results
            // three basic execution modes:
            // .ExecuteReadet() returns row/column data (normal select statements)
            // .ExecuteNonQuery() returns Int32 rows affected (action statements (update/delete/insert))
            // .ExecuteScalar() returns a System.Object (aggregate queries)
            rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ApplicationException("Update Failed");
            }
            finally
            {
                conn.Close();
            }

            // return the result
            return rowsAffected;
        }
    }
}
