using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Coach
{
    public class ListCoachViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime? DateArchived { get; set; }
        public bool IsActive { get; set; }
    }
}
