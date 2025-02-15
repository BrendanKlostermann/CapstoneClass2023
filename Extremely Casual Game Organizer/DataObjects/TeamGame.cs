﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TeamGame : TeamGameVM
    {
        public int TeamID { get; set; }
        public bool Win { get; set; }
        public int GameID { get; set; }
        public int GameRosterID { get; set; }
    }
    public class TeamGameVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class TeamsInGame
    {
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }

        public int Team1ID { get; set; }
        public int Team2ID { get; set; }
    }
}
