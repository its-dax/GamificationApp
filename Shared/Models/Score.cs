using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public int Points { get; set; }

        public int SubjectID { get; set; }
        [ForeignKey("SubjectID")]
        public virtual Subject? Subject { get; set; }


    }
}
