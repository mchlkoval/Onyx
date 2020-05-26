using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Athlete
{
    public class ListAthleteViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime? DateArchived { get; set; }
    }
}
