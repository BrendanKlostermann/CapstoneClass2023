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
    }
    public class EquipmentVM
    {
        public string SportDescription { get; set; }
    }
}
