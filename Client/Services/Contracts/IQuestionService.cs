using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;

namespace GamificationApp.Client.Services.Contracts
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetQuestions();
        Task<QuestionDto> GetQuestion(int id);
        Task<Question> AddQuestion(QuestionDto questionDto);
        Task<IEnumerable<Subject>> GetSubjects();
        Task<QuestionDto> ApproveQuestion(ApproveQuestionDto dto);
        Task<QuestionDto> DeleteQuestion(ApproveQuestionDto delete);
    }
}
