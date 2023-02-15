using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class VenueEquipmentList : VenueEquipmentListVM
    {
        public int EquipmentID { get; set; }
        public int VenueID { get; set; }
        public int Quantity { get; set; }
    }

    public class VenueEquipmentListVM
    {
        public string Description { get; set; }
    }
}
