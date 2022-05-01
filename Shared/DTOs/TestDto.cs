using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.DTOs
{
    public class TestDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int NumberOfQuestions { get; set; }
        public DateTime StartTime { get; set; }
        public int TestTimeInMinutes { get; set; }

    }
}
