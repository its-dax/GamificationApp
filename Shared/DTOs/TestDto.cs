using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.DTOs
{
    public class TestDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string SubjectName { get; set; }
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public int NumberOfQuestions { get; set; }
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public int TestTimeInMinutes { get; set; }

    }
}
