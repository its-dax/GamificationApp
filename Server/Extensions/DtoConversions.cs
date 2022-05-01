using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<QuestionDto> ConvertToDto(this IEnumerable<Question> questions,
            IEnumerable<Subject> subjects)
        {
            return (from question in questions
                join subject in subjects
                    on question.SubjectId equals subject.Id
                select new QuestionDto()
                {
                    Id = question.Id,
                    SubjectId = question.SubjectId,
                    Title = question.Title,
                    A = question.A,
                    B = question.B,
                    C = question.C,
                    D = question.D,
                    GoodAnswer = question.GoodAnswer,
                    IsApproved = question.IsApproved,
                    SubjectName = subject.Name
                }).ToList();
        }
    }
}
