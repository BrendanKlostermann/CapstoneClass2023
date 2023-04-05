/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// TeamSport DataObject
/// </summary>
///
/// <remarks>
/// Updater Name: Garion Opiola
/// Updated: 2023/03/28
/// Added Active bit
/// 
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TeamMemberAndSport
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Updated By: Garion Opiola
        /// Date: 2023/03/28
        /// Added Active bit
        /// 
        /// Property for Team Member and Sport
        /// </summary>
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public bool Starter { get; set; }
        public string Description { get; set; }
        public int MemberID { get; set; }
        public string SportName { get; set; }
        public bool? Gender { get; set; }
        public bool Active { get; set; }
    }
}
