using GamificationApp.Shared.DTOs;

namespace GamificationApp.Client.Services.Contracts
{
    public interface IScoreService
    {
        Task<IEnumerable<ScoreDto>> GetScores();
        //Task<ScoreDto> UpdatePoints(ScoreQtyUpdateDto scoreQtyUpdateDto);
    }
}
