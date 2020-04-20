using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.User
{
    //Used When Returning data back, namely when logging in
    public class UserViewModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }

    }
}
