using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Game : GameVM
    {
        public int GameID { get; set; }
        public int VenueID { get; set; }
        public DateTime DateAndTime { get; set; }
        public int SportID { get; set; }
    }

    public class GameVM
    {
        public string SportDescription { get; set; }
        public string VenueName { get; set; }
    }
}
