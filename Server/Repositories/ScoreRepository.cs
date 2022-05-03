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

        public async Task<IEnumerable<Score>> GetScores()
        {
            var scores = await _dataContext.Scores.ToListAsync();
            return scores;
        }

        public async Task<IEnumerable<Score>> GetScoresByStudent(int userId)
        {
            return await (from score in _dataContext.Scores
                          join user in _dataContext.Users
                            on score.UserId equals user.Id
                            join subject in _dataContext.Subjects
                            on score.SubjectId equals subject.Id
                          where user.Id == userId
                          select new Score
                          {
                              Id = score.Id,
                              UserId = user.Id,
                              Points = score.Points,
                              SubjectId = subject.Id
                          }).ToListAsync();
        }

        public async Task<IEnumerable<Score>> GetScoresBySubject(int subjectId)
        {
            return await(from score in _dataContext.Scores
                         join user in _dataContext.Users
                           on score.UserId equals user.Id
                         join subject in _dataContext.Subjects
                         on score.SubjectId equals subject.Id
                         where subject.Id == subjectId
                         select new Score
                         {
                             Id = score.Id,
                             UserId = user.Id,
                             Points = score.Points,
                             SubjectId = subject.Id
                         }).ToListAsync();
        }

        public async Task<Subject> GetSubject(int id)
        {
            var subject = await _dataContext.Subjects.SingleOrDefaultAsync(s => s.Id == id);
            return subject;
        }

            public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var subjects = await _dataContext.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }

        public Task<Score> UpdateScore(int id, ScoreQtyUpdateDto scoreQtyUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
