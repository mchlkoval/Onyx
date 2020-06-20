using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.JoinTables
{
    public class CoachAthlete
    {
        public string AthleteId { get; set; }
        public AppUser Athlete { get; set; }

        public string CoachId { get; set; }
        public AppUser Coach { get; set; }
    }
}
