using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TournamentGenerateGames
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/03/20
        /// 
        /// Property for Tournament Game
        /// </summary>
        /// 
        /// Table TournamentGame
        public int TournamentID { get; set; }

        /// Table GameRoster
        public int TeamID_1 { get; set; }
        public int TeamID_2 { get; set; }
        public int MemberID { get; set; }

        /// <summary>
        /// GamePost
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// To make sure all the game send are part of one tournament and not a new game generated
        /// </summary>
        public bool IsAGroup { get; set; }

    }
}
