using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.JoinTables
{
    public class UserTeam
    {
        public string TeamId { get; set; }
        public Team Team { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
