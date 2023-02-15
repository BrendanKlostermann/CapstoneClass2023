using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class TeamAccessor : ITeamAccessor
    {
        public Team SelectTeamByTeamID(int team_id)
        {
            Team team = null;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_team_by_team_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@team_id", SqlDbType.Int);

            cmd.Parameters["@team_id"].Value = team_id;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                team = new Team();

                if (reader.HasRows)
                {
                    reader.Read();

                    team.TeamID = reader.GetInt32(0);
                    team.TeamName = reader.GetString(1);
                    if (reader.IsDBNull(2))
                    {
                        team.Gender = null;
                    }
                    else
                    {
                        team.Gender = reader.GetBoolean(2);
                    }
                    team.SportID = reader.GetInt32(3);
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

            return team;
        }
    }
}
