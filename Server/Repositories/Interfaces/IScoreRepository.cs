using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface IScoreRepository
    {

        Task<IEnumerable<Score>> GetScores();
        Task<IEnumerable<Score>> GetScore(int id);
        Task<IEnumerable<Subject>> GetSubjects();
        Task<IEnumerable<Subject>> GetSubject(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUser(int id);
    }
}
