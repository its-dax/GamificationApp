using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public int NumberOfQuestions { get; set; }
        public DateTime StartTime { get; set; }
        public int TestTimeInMinutes { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
    }
}
