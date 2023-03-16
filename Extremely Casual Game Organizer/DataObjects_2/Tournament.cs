/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Tournament
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Property for Tournament
        /// </summary>
        public int TournamentID { get; set; }
        public int SportID { get; set; }
        public bool Gender { get; set; }
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
