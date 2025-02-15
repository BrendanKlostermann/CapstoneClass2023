/// Brendan Klostermann
/// Created: 2023/02/20
/// 
/// This class is for the Tournament data object.
/// 
/// </summary>

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
        public int TournamentID { get; set; }
        public int SportID { get; set; }
        public bool? Gender { get; set; }
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public Tournament()
        {
        }

    }



    public class TournamentVM
    {
        public int TournamentID { get; set; }
        public string SportName { get; set; }
        public string Gender { get; set; }
        public bool? GenderBool { get; set; }
        public string CreatorName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TournamentVM()
        {
        }
    }
}
