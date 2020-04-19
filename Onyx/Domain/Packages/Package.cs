using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Packages
{
    public class Package
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
