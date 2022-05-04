using GamificationApp.Shared.DTOs;

namespace GamificationApp.Client.Services.Contracts
{
    public interface IScoreService
    {
        //Task<IEnumerable<ScoreDto>> GetScoresBySubject(int subjectId);
        Task<List<ScoreDto>> GetScoresByStudent(int userId);
        //Task<ScoreDto> UpdatePoints(ScoreQtyUpdateDto scoreQtyUpdateDto);
    }
}
