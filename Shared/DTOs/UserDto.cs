﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamificationApp.Shared.Models;

namespace GamificationApp.Shared.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public User.Roles Role { get; set; }

    }
}
