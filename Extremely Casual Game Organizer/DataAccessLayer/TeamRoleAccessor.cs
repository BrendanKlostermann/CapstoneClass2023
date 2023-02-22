using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using DataAccessInterfaces;

namespace DataAccessLayer
{
    public class TeamRoleAccessor : ITeamRoleAccessor
    {
        public List<TeamRoles> SelectTeamRolesByMemberID()
        {
            List<TeamRoles> teamRoles = new List<TeamRoles>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_team_role_by_member_id";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var role = new TeamRoles();
                        role.memberID = reader.GetInt32(0);
                        role.teamID = reader.GetInt32(1);
                        role.teamRoleTypeID = reader.GetString(2);
                        teamRoles.Add(role);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return teamRoles;
        }

        
    }
}
