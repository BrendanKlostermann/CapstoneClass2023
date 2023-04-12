using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TournamentTeamGame
    {

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/20
        /// 
        /// Property for Tournament Team Game
        /// </summary>
        public int TournamentID { get; set; }
        public int TeamID { get; set; }
        public int GameID { get; set; }
    }
}
