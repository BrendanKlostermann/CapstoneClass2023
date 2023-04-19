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
    public class PracticeAccessor : IPracticeAccessor
    {
        public int CreatePracticeByTeamID(Practice practice)
        {
            int rowsAffected = 0;
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();
            var cmdText = "sp_create_practice";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //practice_id is an identity
            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters.Add("@location", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@date_time", SqlDbType.DateTime);
            cmd.Parameters.Add("@description", SqlDbType.NVarChar, 1000);
            cmd.Parameters.Add("@zipcode", SqlDbType.Int);

            cmd.Parameters["@team_id"].Value = practice.TeamID;
            cmd.Parameters["@location"].Value = practice.Location;
            cmd.Parameters["@date_time"].Value = practice.DateAndTime;
            cmd.Parameters["@description"].Value = practice.Description;
            cmd.Parameters["@zipcode"].Value = practice.ZIP;

            try
            {
                // open the connection
                conn.Open();

                // execute the command
                rowsAffected = cmd.ExecuteNonQuery();
                // process the results
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // close the connection
                conn.Close();
            }
            //will always return 1 or 0
            return rowsAffected;
        }

        public int deletePracticeByID(Practice practiceID)
        {
            int rowsAffected = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            string commandText = "sp_delete_practice";

            var cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@practice_id", SqlDbType.Int);

            // parameter values
            cmd.Parameters["@practice_id"].Value = practiceID.PracticeID;

            try
            {
                conn.Open();
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
        /// Nick Vroom
        /// Created: 2023/04/11
        /// 
        /// Selects a list of all practices by team ID
        /// </summary>
        /// A method to select all teams

        public List<Practice> SelectAllPractices(int teamID)
        {

            List<Practice> practices = new List<Practice>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_practices";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@team_id", SqlDbType.Int);
            cmd.Parameters["@team_id"].Value = teamID;


            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Practice practice = new Practice();
                        practice.PracticeID = reader.GetInt32(0);
                        practice.Location = reader.GetString(1);
                        practice.TeamID = reader.GetInt32(2);
                        practice.DateAndTime = reader.GetDateTime(3);
                        practice.Description = reader.GetString(4);
                        practice.ZIP = reader.GetInt32(5);
                        practices.Add(practice);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return practices;
        }
    }
}
