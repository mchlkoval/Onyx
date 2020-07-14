using Domain.Identity;
using Domain.JoinTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ArchiveDate {get; set; }
        public List<UserTeam> TeamMembers { get; set; }
        public string OrganizationId { get; set; }
    }
}
