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
    public class Equipment : EquipmentVM
    {
        public int EquipmentID { get; set; }
        public int SportID { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Heritier Otiom
        /// Created: 2023/01/31
        /// 
        /// Property for Equipment
        /// </summary>
        public string SportName { get; set; }
        public int TeamID { get; set; }
        public int Quantity { get; set; }

    }
    public class EquipmentVM
    {
        public string SportDescription { get; set; }
    }
}
