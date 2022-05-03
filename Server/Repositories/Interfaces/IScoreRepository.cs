using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface IScoreRepository
    {

        Task<IEnumerable<Score>> GetScoresBySubject(int id);
        Task<IEnumerable<Score>> GetScoresByStudent(int id);
        Task<Score> GetScore(int id);
        //Task<IEnumerable<Subject>> GetSubjects();
        //Task<Subject> GetSubject(int id);
        //Task<IEnumerable<User>> GetUsers();
        //Task<User> GetUser(int id);
        Task<Score> UpdateScore(int id, ScoreQtyUpdateDto scoreQtyUpdateDto);
    }
}
