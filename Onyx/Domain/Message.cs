using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Message
    {
        public string Id { get; set; }
        //User uses default value for id, which is a string. 
        //public AppUser User { get; set; }
        //public string UserId { get; set; }
        public string Content { get; set; }
        public string From { get; set; }
        public DateTime DateOfMessage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
