using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface IScoreRepository
    {

        Task<IEnumerable<Score>> GetScores();
        Task<Score> GetScore(int id);
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubject(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
