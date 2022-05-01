using GamificationApp.Shared.DTOs;

namespace GamificationApp.Client.Services.Contracts
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetQuestions();
    }
}
