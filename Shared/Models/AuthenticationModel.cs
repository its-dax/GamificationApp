using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.Models
{
    public class AuthenticationModel
    {
        [Required(ErrorMessage = "A kód megadása szükséges")]
        public string Code { get; set; }
        [Required(ErrorMessage = "A jelszó megadása szükséges")]
        public string Password { get; set; }

    }
}
