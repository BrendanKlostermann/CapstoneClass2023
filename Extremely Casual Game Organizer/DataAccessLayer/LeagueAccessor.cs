using System.Collections.Generic;
using System.Linq;
using DataObjects;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;
using System;
using DataAccessLayerInterfaces;

/// <LeagueAccessor>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This class is used to access the League Database tables
/// methods include getting a list of all leagues
/// getting a list of all teams in a specific league
/// revmoing a team from a league
/// 
/// Updater Jacob
/// Updated: 2023/02/21
/// 
/// Updater Elijah
/// Updated: 2023/02/28
/// 
public class LeagueAccessor : ILeagueAccessor
{
    public List<League> leagues = new List<League>();
    public List<LeagueGridVM> leaguesForGrid = null;
    public List<League> _leagues = new List<League>();


    /// <summary>
    /// Alex Korte
    /// Created: 2023/01/24
    /// 
    /// Actual summary of the class if needed.
    /// </summary>
    /// A Method to remove a team from a league (database side)
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd 
    /// example: Fixed a problem when user inputs bad data
    /// </remarks>
    public int RemoveATeamFromALeague(int teamId, int leagueId)
    {
        //connection
        DBConnection connectionFactory = new DBConnection();
        var conn = connectionFactory.GetDBConnection();

        //command text
        var cmdText = "sp_remove_a_player_from_team_by_member_id";

        //create command
        var cmd = new SqlCommand(cmdText, conn);
        
        //command type
        cmd.CommandType = CommandType.StoredProcedure;

        //Add paramaters //values
        cmd.Parameters.Add("@team_id", SqlDbType.Int);
        cmd.Parameters["@team_id"].Value = teamId;
        cmd.Parameters.Add("@league_id", SqlDbType.Int);
        cmd.Parameters["@league_id"].Value = leagueId;

        try
        {
            conn.Open();
            var reader = cmd.ExecuteNonQuery();
            return reader;
        }
        catch (Exception up)
        {
            throw up;
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// Alex Korte & Elijah Morgan
    /// Created: 2023/01/24
    /// 
    /// Actual summary of the class if needed.
    /// </summary>
    /// A method to get a list of leagues(as objects)
    /// 
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd 
    /// example: Fixed a problem when user inputs bad data
    /// </remarks>
    public List<League> SelectAllLeagues()
    {
        List<League> league = new List<League>();
        DBConnection connectionFactory = new DBConnection();
        var conn = connectionFactory.GetDBConnection();

        //command text
        var cmdText = "sp_select_all_leagues";

        //create command
        var cmd = new SqlCommand(cmdText, conn);

        //command type

        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            conn.Open();
            var reader = cmd.ExecuteReader();

            //process the results
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    League temp = new League();
                    temp.LeagueID = reader.GetInt32(0);
                    temp.SportID = reader.GetInt32(1);
                    if (reader.IsDBNull(2) == false)
                    {
                        temp.LeagueDues = reader.GetDecimal(2);
                    }
                    else
                    {
                        temp.LeagueDues = 0;
                    }
                    temp.Active = reader.GetBoolean(3);
                    temp.MemberID = reader.GetInt32(4);
                    temp.Description = reader.GetString(6);
                    temp.Name = reader.GetString(7);

                    if (reader.IsDBNull(5) == false)
                    {
                        temp.Gender = reader.GetBoolean(5);
                    }
                    else { temp.Gender = null; }

                    league.Add(temp);
                }
            }
        }
        catch (Exception up)
        {
            throw up;
        }
        finally
        {
            conn.Close();
        }
        return league;
    }

    /// <summary>
    /// Alex Korte
    /// Created: 2023/01/24
    /// 
    /// Actual summary of the class if needed.
    /// </summary>
    /// A method to get a list of teams (as an object) 
    /// <remarks>
    /// Updater Name
    /// Updated: yyyy/mm/dd 
    /// example: Fixed a problem when user inputs bad data
    /// </remarks>
    public List<Team> SelectATeamByLeagueID(int leagueID)
    {
        List<Team> team = new List<Team>();

        DBConnection connectionFactory = new DBConnection();
        var conn = connectionFactory.GetDBConnection();

        //command text
        var cmdText = "sp_select_teams_by_league_id";

        //create command
        var cmd = new SqlCommand(cmdText, conn);

        //command type
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@league_id", SqlDbType.Int);
        cmd.Parameters["@league_id"].Value = leagueID;

        try
        {
            conn.Open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Team temp = new Team();
                    temp.TeamID = reader.GetInt32(0);
                    temp.TeamName = reader.GetString(1);
                    temp.Gender = reader.GetBoolean(2);
                    temp.SportID = reader.GetInt32(3);
                    team.Add(temp);
                }
            }
        }
        catch (Exception up)
        {
            throw up;
        }
        finally
        {
            conn.Close();
        }
        return team;
    }

    /// <summary>
    /// Brendan Klostermann
    /// Created: 2023/03/05
    /// 
    /// Actual summary of the class if needed.
    /// </summary>
    /// a method that gets a list of LeagueGridVM objects from the database;
    /// 
    public List<LeagueGridVM> SelectLeaguesForGrid()
    {

        leaguesForGrid = new List<LeagueGridVM>();
        MemberAccessor memberAccessor = new MemberAccessor();

        //connection
        DBConnection connectionFactory = new DBConnection();
        var conn = connectionFactory.GetDBConnection();

        //command text
        var cmdText = "sp_select_all_leagues";

        //create command
        var cmd = new SqlCommand(cmdText, conn);

        //command type
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            conn.Open();
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Member member = memberAccessor.SelectAUserByID(reader.GetInt32(4));
                    LeagueGridVM leagueVM = new LeagueGridVM();
                    leagueVM.LeagueID = reader.GetInt32(0);
                    leagueVM.LeagueName = reader.GetString(7);
                    leagueVM.Description = reader.GetString(6);
                    leagueVM.SportName = SelectSportDescriptionByID(reader.GetInt32(1));
                    leagueVM.LeagueCreator = member.FirstName;
                    if (reader.IsDBNull(5))
                    {
                        leagueVM.GenderBool = null;
                    }
                    else
                    {
                        leagueVM.GenderBool = reader.GetBoolean(5);
                    }
                    leagueVM.Gender = "Undefined";

                    leaguesForGrid.Add(leagueVM);

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return leaguesForGrid;
    }
    /// <summary>
    /// Created By: Jacob Lindauer
    /// Date: 2023/28/02
    /// 
    /// Method takes in a team_id and returns all active and inactive leagues for provided team.
    /// </summary>
    /// <param name="team_id"></param>
    /// <returns></returns>
    public List<League> SelectLeaguesByTeamID(int team_id)
    {
        List<League> leagueList = new List<League>();

        DBConnection connectionFactory = new DBConnection();
        var conn = connectionFactory.GetDBConnection();

        var cmdText = "sp_select_league_list_by_team_id";

        var cmd = new SqlCommand(cmdText, conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@team_id", SqlDbType.Int);

        cmd.Parameters["@team_id"].Value = team_id;

        try
        {
            conn.Open();

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                League temp = new League();
                temp.LeagueID = reader.GetInt32(0);
                temp.SportID = reader.GetInt32(1);
                if (reader.IsDBNull(2) == false)
                {
                    temp.LeagueDues = reader.GetDecimal(2);
                }
                temp.Active = reader.GetBoolean(3);
                temp.MemberID = reader.GetInt32(4);
                temp.Description = reader.GetString(6);
                temp.Name = reader.GetString(7);

                if (reader.IsDBNull(5) == false)
                {
                    temp.Gender = reader.GetBoolean(5);
                }
                else { temp.Gender = null; }

                leagueList.Add(temp);
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

        return leagueList;
    }

    /// <summary>
    /// Brendan Klostermann
    /// Created: 2023/03/05
    /// 
    /// Actual summary of the class if needed.
    /// </summary>
    /// A method that selects the descrption(name) of a sport by the id of the sport
    public string SelectSportDescriptionByID(int id)
    {
        string desc = "";

        DBConnection connectionFactory = new DBConnection();
        var conn = connectionFactory.GetDBConnection();

        //command text
        var cmdText = "sp_select_sports_description_by_sportID";

        //create command
        var cmd = new SqlCommand(cmdText, conn);

        //command type
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@sportid", SqlDbType.Int);
        cmd.Parameters["@sportid"].Value = id;

        try
        {
            conn.Open();
            desc = (string)cmd.ExecuteScalar();

        }
        catch (SqlException ex)
        {
            throw ex;
        }

        return desc;
    }



    public List<League> SelectLeagueByActiveStatus(bool active)
    {
        List<League> leagues = new List<League>();

        var conn = new DBConnection().GetDBConnection();
        var cmdText = "sp_select_active_league_by_status";
        var cmd = new SqlCommand(cmdText, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@active", SqlDbType.Bit);
        cmd.Parameters["@active"].Value = active;

        try
        {
            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    leagues.Add(new League()
                    {
                        Active = true
                    });
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return leagues;
    }

    /// <summary>
    /// Elijah
    /// Created: 2023/02/28
    /// 
    /// This method selects a league by a parameter of leagueID and
    /// selects the assigned League.
    /// </summary>
    /// 
    /// <param name="leagueID">The LeagueID that is passed to find a
    /// Lague with the assigned LeagueID</param>
    /// <exception cref="SQLException">Data not found</exception>
    /// <returns>A single league</returns>
    public League SelectLeagueByLeagueID(int leagueID)
    {
        League leagues = new League();

        var conn = new DBConnection().GetDBConnection();
        var cmdText = "sp_select_league_by_league_id";
        var cmd = new SqlCommand(cmdText, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@league_id", SqlDbType.Int);
        cmd.Parameters["@league_id"].Value = leagueID;
        try
        {
            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    leagues.LeagueID = leagueID;
                    leagues.SportID = reader.GetInt32(0);

                    if (!reader.IsDBNull(1))
                    {
                        leagues.LeagueDues = reader.GetDecimal(1);
                    }

                    leagues.Active = reader.GetBoolean(2);
                    leagues.MemberID = reader.GetInt32(3);

                    if (!reader.IsDBNull(4))
                    {
                        leagues.Gender = reader.GetBoolean(4);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        leagues.Description = reader.GetString(5);
                    }

                    leagues.Name = reader.GetString(6);

                    if (!reader.IsDBNull(7))
                    {
                        leagues.MaxNumOfTeams = reader.GetInt32(7);
                    }
                };
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return leagues;
    }


    ///// <summary>
    ///// Elijah
    ///// Created: 2023/02/28
    ///// 
    ///// Selects a League by a LeagueID and updates the current active
    ///// status.
    ///// </summary>
    ///// 
    ///// <param name="oldLeague">A League that is passed to obtain the old data</param>
    ///// <param name="newLeague">A League that is passed input the new data</param>
    ///// <exception cref="SQLException">Data not found</exception>
    ///// <returns>A single league</returns>
    //public int UpdateLeagueRegistrationByLeagueIDByActive(League oldLeague, League newLeague)
    //{
    //    // doesnt need any parameters just leagueID and changing 1 to 0 or vice versa

    //    int rows = 0;

    //    var conn = new DBConnection().GetDBConnection();
    //    var cmdText = "sp_update_league_registration_by_league_id_by_active";
    //    var cmd = new SqlCommand(cmdText, conn);
    //    cmd.CommandType = CommandType.StoredProcedure;

    //    cmd.Parameters.AddWithValue("@league_id", oldLeague.LeagueID);
    //    cmd.Parameters.AddWithValue("@sport_id", oldLeague.SportID);
    //    cmd.Parameters.AddWithValue("@legal_dues", oldLeague.LeagueDues);
    //    cmd.Parameters.AddWithValue("@active", oldLeague.Active);
    //    cmd.Parameters.AddWithValue("@member_id", oldLeague.MemberID);
    //    cmd.Parameters.AddWithValue("@gender", oldLeague.Gender);
    //    cmd.Parameters.AddWithValue("@description", oldLeague.LeagueDescription);
    //    cmd.Parameters.AddWithValue("@name", oldLeague.Name);

    //    cmd.Parameters.Add("@NewActive", SqlDbType.Bit);
    //    cmd.Parameters["@NewActive"].Value = newLeague.Active;

    //    try
    //    {
    //        conn.Open();
    //        rows = cmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return rows;
    //}

    /// <summary>
    /// Elijah
    /// Created: 2023/02/28
    /// 
    /// Updates a leagues with data that is inserted in the pgAddEditLeague page.
    /// </summary>
    /// 
    /// <param name="oldLeague">A League that is passed to obtain the old data</param>
    /// <param name="newLeague">A League that is passed input the new data</param>
    /// <exception cref="SQLException">Data not found</exception>
    /// <returns>A single updated League</returns>
    public int UpdateLeague(League oldLeague, League newLeague)
    {
        int rows = 0;
        var conn = new DBConnection().GetDBConnection();
        var cmdText = "sp_update_league";
        var cmd = new SqlCommand(cmdText, conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@league_id", oldLeague.LeagueID);

        cmd.Parameters.Add("@newLeague_dues", SqlDbType.Money);
        cmd.Parameters["@newLeague_dues"].Value = newLeague.LeagueDues;

        cmd.Parameters.Add("@newActive", SqlDbType.Int);
        cmd.Parameters["@newActive"].Value = newLeague.Active;

        if (newLeague.Gender != null)
        {
            cmd.Parameters.AddWithValue("@newGender", newLeague.Gender);
        }
        else
        {
            cmd.Parameters.Add("@newGender", SqlDbType.Bit);
            cmd.Parameters["@newGender"].Value = DBNull.Value;
        }

        cmd.Parameters.Add("@newDescription", SqlDbType.NVarChar, 1000);
        cmd.Parameters["@newDescription"].Value = newLeague.Description;

        cmd.Parameters.Add("@newName", SqlDbType.NVarChar, 250);
        cmd.Parameters["@newName"].Value = newLeague.Name;

        cmd.Parameters.Add("@newMax_num_of_teams", SqlDbType.Int);
        cmd.Parameters["@newMax_num_of_teams"].Value = newLeague.MaxNumOfTeams;

        try
        {
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }
        catch (Exception ex)
        {
            newLeague = oldLeague;
            throw new ApplicationException("Could not find data", ex);
        }
        finally
        {
            conn.Close();
        }
    }

    //Elijah M. is currently working on this
    ///// <summary>
    ///// Elijah
    ///// Created: 2023/02/28
    ///// 
    ///// Updates a league's active status with the League object that is 
    ///// selected by the datLeague list.
    ///// 
    ///// <param name="active">What the new active status will become</param>
    ///// <exception cref="SQLException">Data not found</exception>
    ///// <returns>A single updated League</returns>
    //public int UpdateLeagueActiveStatus(bool active) // use int LeagueID to call a leagueID

    //// use an int for the row count then return the integer and 
    //// then use the logic layer to determine wether its true of false
    //{
    //    // make stored procedure for this
    //    var conn = new DBConnection().GetDBConnection();
    //    var cmdText = "";
    //    var cmd = new SqlCommand(cmdText, conn);
    //    int count = 0;
    //    cmd.CommandType = CommandType.StoredProcedure;

    //    cmd.Parameters.Add("@active", SqlDbType.Bit);
    //    cmd.Parameters["@active"].Value = active;

    //    try
    //    {
    //        conn.Open();
    //        count = cmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ApplicationException("Could not find data", ex);
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //    return count;
    //}

    /// <summary>
    /// Elijah
    /// Created: 2023/02/28
    /// 
    /// Selects a list of every League object.
    /// 
    /// <exception cref="SQLException">Data not found</exception>
    /// <returns>Every current League in the database</returns>
    public List<League> SelectListOfLeagues()
    {
        List<League> _leagues = new List<League>();//list of leagues i want to return

        League league = null;//initial league
        DBConnection connectionFacorty = new DBConnection();
        var conn = connectionFacorty.GetDBConnection();

        var cmdText = "sp_select_all_leagues";

        var cmd = new SqlCommand(cmdText, conn);

        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            conn.Open();

            // get a data reader
            var reader = cmd.ExecuteReader();

            //process the results
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    league = new League();//new league made by reader

                    league.LeagueID = reader.GetInt32(0);
                    league.SportID = reader.GetInt32(1);
                    league.LeagueDues = reader.GetDecimal(2);
                    league.Active = reader.GetBoolean(3);
                    league.MemberID = reader.GetInt32(4);
                    if (!reader.IsDBNull(5))
                    {
                        league.Gender = reader.GetBoolean(5);
                    }
                    league.Description = reader.GetString(6);
                    league.Name = reader.GetString(7);
                    league.MaxNumOfTeams = reader.GetInt32(8);

                    _leagues.Add(league);//added temp league to league list
                }
            }

        }
        catch (SqlException ex)
        {

            throw ex;
        }
        finally
        {
            conn.Close();
        }
        return _leagues;//return list of leagues
    }

    // Elijah M. is currently working on this
    /// <summary>
    /// Elijah
    /// Created: 2023/02/28
    /// 
    /// Selects all leagues with a specified sportID.
    /// 
    /// <param name="sportID">What SportID we are wanting to seach by</param>
    /// <exception cref="SQLException">Data not found</exception>
    /// <returns>Leagues that all use the same SportID</returns>
    public League SelectLeaguesBySportID(int sportID)
    {
        League leagues = new League();

        var conn = new DBConnection().GetDBConnection();
        var cmdText = "sp_select_leagues_by_sport_id";
        var cmd = new SqlCommand(cmdText, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@sport_id", SqlDbType.Int);
        cmd.Parameters["@sport_id"].Value = sportID;
        try
        {
            conn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    leagues = new League()
                    {
                        LeagueID = reader.GetInt32(0),
                        SportID = reader.GetInt32(1),
                        LeagueDues = reader.GetDecimal(2),
                        Active = reader.GetBoolean(3),
                        MemberID = reader.GetInt32(4),
                        Gender = reader.GetBoolean(5),
                        Description = reader.GetString(6),
                        Name = reader.GetString(7),
                        MaxNumOfTeams = reader.GetInt32(8)
                    };
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return leagues;
    }

public int AddALeague(League league)
{
    int leagueID = 0;

    // connection
    DBConnection connectionFactory = new DBConnection();
    var conn = connectionFactory.GetDBConnection();

    // cmdText
    var cmdText = "sp_create_league";

    // command
    var cmd = new SqlCommand(cmdText, conn);

    // type
    cmd.CommandType = CommandType.StoredProcedure;

    // parameters
    cmd.Parameters.AddWithValue("@SportID", league.SportID);
    cmd.Parameters.AddWithValue("@Dues", league.LeagueDues);
    cmd.Parameters.AddWithValue("@Active", league.Active);
    cmd.Parameters.AddWithValue("@MemberID", league.MemberID);
    if (league.Gender == null)
    {
        cmd.Parameters.AddWithValue("@Gender", DBNull.Value);
    }
    else
    {
        cmd.Parameters.AddWithValue("@Gender", league.Gender);
    }
    cmd.Parameters.AddWithValue("@Description", league.Description);
    cmd.Parameters.AddWithValue("@Name", league.Name);
    cmd.Parameters.AddWithValue("@Max_Num_Teams", league.MaxNumOfTeams);
    try
    {
        conn.Open();

        leagueID = Convert.ToInt32(cmd.ExecuteScalar());
    }
    catch (Exception ex)
    {
        throw ex;
    }
    finally
    {
        conn.Close();
    }
    return leagueID;
}


public int ChangeLeagueRegistration(int LeagueID, bool OpenOrClose)
{
    //connection
    DBConnection connectionFactory = new DBConnection();
    var conn = connectionFactory.GetDBConnection();

    //command text
    var cmdText = "sp_update_registration_by_league_id";

    //create command
    var cmd = new SqlCommand(cmdText, conn);

    //command type
    cmd.CommandType = CommandType.StoredProcedure;

    //Add paramaters //values
    cmd.Parameters.Add("@Active", SqlDbType.Int);
    cmd.Parameters["@Active"].Value = OpenOrClose;
    cmd.Parameters.Add("@league_id", SqlDbType.Int);
    cmd.Parameters["@league_id"].Value = LeagueID;

    try
    {
        conn.Open();
        var reader = cmd.ExecuteNonQuery();
        return reader;
    }
    catch (Exception up)
    {
        throw up;
    }
    finally
    {
        conn.Close();
    }
}

/// <summary>
/// Rith
/// Data access method to delete a league
/// </summary>
public int RemoveALeague(int LeagueID)
{
    int rowcount = 0;
    //connection
    DBConnection connectionFactory = new DBConnection();
    var conn = connectionFactory.GetDBConnection();

    //command text
    var cmdText = "sp_delete_league";

    //create command
    var cmd = new SqlCommand(cmdText, conn);

    //command type
    cmd.CommandType = CommandType.StoredProcedure;

    //Add paramaters //values
    cmd.Parameters.Add("@LeagueID", SqlDbType.Int);
    cmd.Parameters["@LeagueID"].Value = LeagueID;

    try
    {
        conn.Open();
        rowcount = cmd.ExecuteNonQuery();
    }
    catch (Exception up)
    {
        throw up;
    }
    finally
    {
        conn.Close();
    }
    return rowcount;
}

/// <summary>
/// Rith
/// Data access method to get the leagues that a specific member created
/// </summary>
public List<League> SelectLeaguesByMemberID(int MemberID)
{

    List<League> leagues = new List<League>();

    DBConnection connectionFactory = new DBConnection();
    var conn = connectionFactory.GetDBConnection();

    //command text
    var cmdText = "sp_select_leagues_by_member_id";

    //create command
    var cmd = new SqlCommand(cmdText, conn);

    //command type
    cmd.CommandType = CommandType.StoredProcedure;

    cmd.Parameters.Add("@member_id", SqlDbType.Int);
    cmd.Parameters["@member_id"].Value = MemberID;

    try
    {
        conn.Open();
        var reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                League temp = new League();
                temp.LeagueID = reader.GetInt32(0);
                temp.SportID = reader.GetInt32(1);
                if (reader.IsDBNull(2) == false)
                {
                    temp.LeagueDues = reader.GetDecimal(2);
                }
                temp.Active = reader.GetBoolean(3);
                temp.MemberID = reader.GetInt32(4);
                temp.Description = reader.GetString(6);
                temp.Name = reader.GetString(7);

                if (reader.IsDBNull(5) == false)
                {
                    temp.Gender = reader.GetBoolean(5);
                }
                else { temp.Gender = null; }

                leagues.Add(temp);
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
    return leagues;
}

/// <summary>
/// Rith
/// Data access method to update the fields in a league
/// </summary>
public int UpdateALeague(League league)
{
    //connection
    DBConnection connectionFactory = new DBConnection();
    var conn = connectionFactory.GetDBConnection();

    //command text
    var cmdText = "sp_update_league";

    //create command
    var cmd = new SqlCommand(cmdText, conn);

    //command type
    cmd.CommandType = CommandType.StoredProcedure;

    //Add parameters //values
    cmd.Parameters.Add("@league_id", SqlDbType.Int);
    cmd.Parameters["@league_id"].Value = league.LeagueID;
    cmd.Parameters.Add("@newLeague_dues", SqlDbType.Money);
    cmd.Parameters["@newLeague_dues"].Value = league.LeagueDues;
    cmd.Parameters.Add("@newActive", SqlDbType.Bit);
    cmd.Parameters["@newActive"].Value = league.Active;
    if (league.Gender == null)
    {
        cmd.Parameters.AddWithValue("@newGender", DBNull.Value);
    }
    else
    {
        cmd.Parameters.AddWithValue("@newGender", league.Gender);
    }
    cmd.Parameters.Add("@newDescription", SqlDbType.VarChar);
    cmd.Parameters["@newDescription"].Value = league.Description;
    cmd.Parameters.Add("@newName", SqlDbType.VarChar);
    cmd.Parameters["@newName"].Value = league.Name;
    cmd.Parameters.Add("@newMax_num_of_teams", SqlDbType.Int);
    cmd.Parameters["@newMax_num_of_teams"].Value = league.MaxNumOfTeams;

    try
    {
        conn.Open();
        var reader = cmd.ExecuteNonQuery();
        return reader;
    }
    catch (Exception up)
    {
        throw up;
    }
    finally
    {
        conn.Close();
    }
}

    public List<LeagueRequest> SelectRequestsByLeagueID(int LeagueID)
    {
        throw new NotImplementedException();
    }
}
