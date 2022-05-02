using GamificationApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.DTOs
{
    public class LoginDto
    {
        public string Code { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public User.Roles Role { get; set; }
    }
}
