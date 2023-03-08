/// <summary>
/// Created By: Jacob Lindauer
/// Date: 2023/03/04
/// 
/// Created this class so I can populate the calendar with events object types.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class CalendarEvent
    {
        public string Type { get; set; }
        public int EventID { get; set; }
        public string  Location { get; set; }
        public DateTime Date { get; set; }
    }
}
