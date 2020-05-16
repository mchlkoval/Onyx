using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Organization
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<AppUser> Members { get; set; }
    }
}
