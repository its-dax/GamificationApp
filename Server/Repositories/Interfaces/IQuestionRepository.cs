using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question> GetQuestion(int id);
        Task<Question> AddQuestion(Question question);
        Task<Question> ApproveQuestion(int  id);
        Task<Question> DeleteQuestion(int id);
    }
}
