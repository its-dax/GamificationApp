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
        public Task<Score> GetScore(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Score>> GetScores()
        //{
        //    var scores = await _dataContext.Scores.ToListAsync();
        //    return scores;
        //}

        public async Task<IEnumerable<Score>> GetScoresByStudent(int userId)
        {
            var scores = await (from score in _dataContext.Scores
                                join user in _dataContext.Users
                                  on score.UserId equals user.Id
                                join subject in _dataContext.Subjects
                                on score.SubjectId equals subject.Id
                                where score.UserId == userId
                                select new Score
                                {
                                    Id = score.Id,
                                    UserId = score.UserId,
                                    Points = score.Points,
                                    SubjectId = score.SubjectId
                                }).ToListAsync();
            return scores;
        }

        public async Task<IEnumerable<Score>> GetScoresBySubject(int subjectId)
        {
            return await(from score in _dataContext.Scores
                         //join user in _dataContext.Users
                         //  on score.UserId equals user.Id
                         //join subject in _dataContext.Subjects
                         //on score.SubjectId equals subject.Id
                         where score.SubjectId == subjectId
                         select new Score
                         {
                             Id = score.Id,
                             UserId = score.UserId,
                             Points = score.Points,
                             SubjectId = score.SubjectId
                         }).ToListAsync();
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
