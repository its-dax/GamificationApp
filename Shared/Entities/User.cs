using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Roles Role { get; set; }

        public enum Roles
        {
            Student,
            Teacher
        }
    }
}
