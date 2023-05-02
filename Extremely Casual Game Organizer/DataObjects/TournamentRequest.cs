using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataObjects
{
    public class TournamentRequest
    {
        public int TournamentRequestID { get; set; }
        [Required]
        public int TournamentID { get; set; }
        [Required]
        public int TeamID { get; set; }
        public string Status { get; set; }
    }
}
