
﻿/// <Sport>
/// Alex Korte
/// Created: 2023/01/24
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
		public string SportDescription { get; set; }//will need to come back to this

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
