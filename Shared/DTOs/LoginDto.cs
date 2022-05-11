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
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string Password { get; set; } = string.Empty;
        public User.Roles Role { get; set; }
    }
}
