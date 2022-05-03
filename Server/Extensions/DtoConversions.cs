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

        public static IEnumerable<ScoreDto> ConvertToDto(this IEnumerable<Score> scores, 
                                                                IEnumerable<Subject> subjects, 
                                                                IEnumerable<User> users)
        {
            return (from score in scores
                    join subject in subjects
                        on score.SubjectId equals subject.Id
                    join user in users
                        on score.UserId equals user.Id
                    select new ScoreDto()
                    {
                        Id = score.Id,
                        UserId = score.UserId,
                        SubjectId = score.SubjectId,
                        UserName = user.Name,
                        SubjectName = subject.Name,
                        Points = score.Points
                    }).ToList();
        }

        public static IEnumerable<TestDto> ConvertToDto(this IEnumerable<Test> tests, 
                                                            IEnumerable<Subject> subjects)
        {
            return (from test in tests
                    join subject in subjects
                    on test.SubjectId equals subject.Id
                    select new TestDto()
                    {
                        Id = test.Id,
                        SubjectId = test.SubjectId,
                        SubjectName = subject.Name,
                        NumberOfQuestions = test.NumberOfQuestions,
                        StartTime = test.StartTime,
                        TestTimeInMinutes = test.TestTimeInMinutes
                    }).ToList();
        }
    }
}
