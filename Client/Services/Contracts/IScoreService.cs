using GamificationApp.Shared.DTOs;

namespace GamificationApp.Client.Services.Contracts
{
    public interface IScoreService
    {
        Task<List<ScoreDto>> GetScoreBySubject(int subjectId);
        Task<List<ScoreDto>> GetScoreByStudent(int userId);
        Task<ScoreDto> UpdatePoints(ScoreQtyUpdateDto scoreQtyUpdateDto);
    }
}
