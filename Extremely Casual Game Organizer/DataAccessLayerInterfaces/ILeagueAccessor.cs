/// <ILeagueAccessor>
/// Alex Korte
/// Created: 2023/01/24
/// 
/// </summary>
/// This is the interface for league accessor, getting the links and manipulating them
/// 
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface ILeagueAccessor
    {
        List<League> SelectAllLeagues();

        List<Team> SelectATeamByLeagueID(int leagueId);

        int RemoveATeamFromALeague(int teamId, int leagueId);
    }
}
