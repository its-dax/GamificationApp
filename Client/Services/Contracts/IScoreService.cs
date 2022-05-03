using GamificationApp.Shared.DTOs;

namespace GamificationApp.Client.Services.Contracts
{
    public interface IScoreService
    {
        Task<IEnumerable<ScoreDto>> GetScoreBySubject(int subjectId);
        Task<IEnumerable<ScoreDto>> GetScoreByStudent(int userId);
        Task<ScoreDto> UpdatePoints(ScoreQtyUpdateDto scoreQtyUpdateDto);
    }
}
