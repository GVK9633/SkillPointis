﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DataTransferObject.User
{
    public class UserDetailsDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool ActiveUser { get; set; }
        public string ConfirmationToken { get; set; }
    }
}
