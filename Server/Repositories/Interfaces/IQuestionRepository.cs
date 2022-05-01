using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestions();
        Task<IEnumerable<Question>> GetQuestion(int id);
        Task<IEnumerable<Subject>> GetSubjects();
        Task<IEnumerable<Subject>> GetSubject(int id);
    }
}
