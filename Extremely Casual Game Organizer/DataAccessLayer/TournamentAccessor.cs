/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is the TournamentAccessor class, used to move data to and from the database.
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayer
{

    
    public class TournamentAccessor : ITournamentAccessor
    {
        List<Tournament> _tournaments;
        List<TournamentVM> _tournamentVMs;

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This Method interacts with the database to return rows from the tournament table
        /// to be converted into Tournament DataObjects
        public List<Tournament> SelectAllTournaments()
        {
            _tournaments = new List<Tournament>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_tournaments";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Tournament tournament = new Tournament();
                        tournament.TournamentID = reader.GetInt32(0);
                        tournament.SportID = reader.GetInt32(1);
                        if (!reader.IsDBNull(2))
                        {
                            tournament.Gender = reader.GetBoolean(2);
                        }
                        tournament.MemberID = reader.GetInt32(3);
                        tournament.Name = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                        {
                            tournament.Description = reader.GetString(5);
                        }
                        tournament.Active = reader.GetBoolean(6);

                        _tournaments.Add(tournament);
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

            return _tournaments;
        }

        /// <summary>
        /// Brendan Klostermann
        /// Created: 2023/03/05
        /// 
        /// </summary>
        /// This Method interacts with the database to return rows from the tournament table
        /// to be converted into TournamentVM DataObjects usefull for the presentation layer.
        public List<TournamentVM> SelectAllTournamentVMs()
        {
            MemberAccessor memberAccessor = new MemberAccessor();
            LeagueAccessor leagueAccessor = new LeagueAccessor();

            _tournamentVMs = new List<TournamentVM>();

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_tournaments";

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
                        TournamentVM tournament = new TournamentVM();
                        tournament.TournamentID = reader.GetInt32(0);
                        tournament.SportName = leagueAccessor.SelectSportDescriptionByID(reader.GetInt32(1));
                        if (!reader.IsDBNull(2))
                        {
                            tournament.GenderBool = reader.GetBoolean(2);
                        }
                        tournament.Gender = "Undefined";
                        tournament.CreatorName = memberAccessor.SelectAUserByID(reader.GetInt32(3)).FirstName;
                        tournament.Name = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                        {
                            tournament.Description = reader.GetString(5);
                        }

                        _tournamentVMs.Add(tournament);
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

            return _tournamentVMs;
        }
    }
}
