/// <summary>
/// Garion Opiola
/// Created: 2023/01/31
/// 
/// Data Access for getTeamRoles
/// 
/// </summary>using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using DataAccessInterfaces;
using System;

namespace DataAccessLayer
{
    /// <summary>
    /// Garion Opiola
    /// Created: 2023/01/31
    /// 
    /// Loagic for getTeamRoles
    /// 
    /// </summary>
    public class TeamRoleAccessor : ITeamRoleAccessor
    {
        public List<TeamRoles> SelectTeamRolesByMemberID()
        {
            /// <summary>
            /// Garion Opiola
            /// Created: 2023/01/31
            /// 
            /// 
            /// </summary>
            List<TeamRoles> teamRoles = new List<TeamRoles>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_role_by_team_id_by_member_id";

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
                        role.MemberID = reader.GetInt32(0);
                        role.TeamID = reader.GetInt32(1);
                        role.TeamRoleTypeID = reader.GetString(2);
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
