using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamificationApp.Shared.DTOs
{
    public class ApproveQuestionDto
    {
        public int QuestionId { get; set; }
        public bool IsApproved { get; set; }
    }
}
