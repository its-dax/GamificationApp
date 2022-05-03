using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question> GetQuestion(int id);
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubject(int id);
    }
}
