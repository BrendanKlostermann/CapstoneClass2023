/// <summary>
/// Heritier Otiom
/// Created: 2023/01/31
/// 
/// TeamSport DataObject
/// </summary>
///
/// <remarks>
/// Updater Name: Heritier Otiom
/// Updated: 2023/02/21
/// 
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TeamSport
    {
        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Property for Team and Sport
        /// </summary>
        public int TeamID { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public int SportID { get; set; }
        public string Description { get; set; }
    }
}
