using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface IScoreRepository
    {

        Task<IEnumerable<Score>> GetScores();
        Task<Score> UpdateScore(int id, ScoreQtyUpdateDto scoreQtyUpdateDto);
    }
}
