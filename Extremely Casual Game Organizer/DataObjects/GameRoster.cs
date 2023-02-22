using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class GameRoster : GameRosterVM
    {
        public int GameRosterID { get; set; }
        public int GameID { get; set; }
        public int MemberID { get; set; }
        public string Description { get; set; }
        public int TeamID { get; set; }
    }
    public class GameRosterVM
    {
        public string TeamName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
