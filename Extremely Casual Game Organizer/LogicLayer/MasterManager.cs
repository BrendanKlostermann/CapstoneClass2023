using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class MasterManager
    {
        public IGameManager GameManager { get; set; }
        public IGameRosterManager GameRosterManager { get; set; }
        public ILeagueManager LeagueManager { get; set; }
        public IMemberManager MemberManager { get; set; }
        public ITeamManager TeamManager { get; set; }
        public ITeamMemberManager TeamMemberManager { get; set; }
        public ISportManager SportManager { get; set; }
        public IVenueManager VenueManager { get; set; }

        public MasterManager()
        {
            GameManager = new GameManager();
            GameRosterManager = new GameRosterManager();
            LeagueManager = new LeagueManager();
            MemberManager = new MemberManager();
            TeamManager = new TeamManager();
            TeamMemberManager = new TeamMemberManager();
            SportManager = new SportManager();
            VenueManager = new VenueManager();
        }
    }
}
