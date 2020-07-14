using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Teams
{
    public class TeamsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ArchiveDate {get; set; }
        public IEnumerable<TeamMembersViewModel> Athletes { get; set; }
        public IEnumerable<TeamMembersViewModel> Coaches { get; set; }
    }

    public class TeamMembersViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
    }
}
