using GamificationApp.Server.Data;
using GamificationApp.Server.Repositories.Interfaces;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationApp.Server.Repositories
{
    public class ScoreRepository : IScoreRepository

    {
        private readonly DataContext _dataContext;

        public ScoreRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Score>> GetScores()
        {
            var scores = await _dataContext.Scores.ToListAsync();
            return scores;
        }

        public async Task<Score> UpdateScore(int id, ScoreQtyUpdateDto scoreQtyUpdateDto)
        {
            var score = await _dataContext.Scores.FindAsync(id);
            if (score is not null)
            {
                score.Points += scoreQtyUpdateDto.Qty;
                await _dataContext.SaveChangesAsync();
                return score;
            }
            return null;
        }
    }
}
