/// <Sport>
/// Alex Korte & Elijah Morgan
/// Created: 2023/01/24, 2023/02/28
/// 
/// </summary>
/// This class is used to create the Sport Object
/// 
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Description { get; set; }

        public Sport()
        {

        }
        public Sport(int sportID, string description)
        {
            this.SportId = sportID;
            this.Description = description;
        }
    }
}
