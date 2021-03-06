using GamificationApp.Server.Data;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Extensions
{
    public static class DtoConversions
    {
        
        //Question DTO conversions

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
                        SubjectName = subject.Name,
                        SubjectTeacher = subject.UserId
                    }).ToList();
        }
        public static QuestionDto ConvertToDto(this Question question,
            Subject subject)
        {
            return new QuestionDto
            {
                Id=question.Id,
                SubjectId=question.SubjectId,
                Title=question.Title,
                A=question.A,
                B=question.B,
                C=question.C,
                D=question.D,
                GoodAnswer=question.GoodAnswer,
                IsApproved=question.IsApproved,
                SubjectName=subject.Name
            };
        }

        // Score DTO conversions

        public static IEnumerable<ScoreDto> ConvertToDto(this IEnumerable<Score> scores, 
                                                                IEnumerable<Subject> subjects, 
                                                                IEnumerable<User> users)
        {
            return (from subject in subjects
                    join score in scores
                        on subject.Id equals score.SubjectId
                    join user in users
                        on score.UserId equals user.Id
                    select new ScoreDto()
                    {
                        Id = score.Id,
                        UserId = score.UserId,
                        UserName = user.Code,
                        SubjectId = score.SubjectId,
                        SubjectName = subject.Name,
                        Points = score.Points,
                        SubjectsTeacherId = subject.UserId
                    }).ToList();
        }

        public static ScoreDto ConvertToDto(this Score score,
                                                Subject subject,
                                                User user)
        {
            return new ScoreDto
            {
                Id=score.Id,
                SubjectId=score.SubjectId,
                UserId=score.UserId,
                SubjectName=subject.Name,
                UserName = user.Code
            };
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
        public static Question ConvertFromDto(this QuestionDto dto, IEnumerable<Subject> subjects)
        {
            return new Question
            {
                Title = dto.Title,
                A = dto.A,
                B = dto.B,
                C = dto.C,
                D = dto.D,
                GoodAnswer = dto.GoodAnswer,
                IsApproved = false,
                UserId = dto.UserId,
                SubjectId = (from subject in subjects
                             where subject.Name == dto.SubjectName
                             select subject.Id).SingleOrDefault()
            };
        }
        public static Test ConvertFromDto(this TestDto dto, IEnumerable<Subject> subjects)
        {
            return new Test
            {
                StartTime = dto.StartTime,
                TestTimeInMinutes= dto.TestTimeInMinutes,
                NumberOfQuestions = dto.NumberOfQuestions,
                SubjectId = (from subject in subjects
                             where subject.Name == dto.SubjectName
                             select subject.Id).SingleOrDefault()
            };
        }
    }

    
}
