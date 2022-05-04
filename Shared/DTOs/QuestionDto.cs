using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectTeacher { get; set; }
        public string Title { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string GoodAnswer { get; set; }
        public bool IsApproved { get; set; }
    }
}
