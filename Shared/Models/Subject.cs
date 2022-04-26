using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User? RelatedTeacher { get; set; }
        public int TestID { get; set; }
        [ForeignKey("TestID")]
        public virtual List<Test>? RelatedTests { get; set; }


    }
}
