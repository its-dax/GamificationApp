using GamificationApp.Server.Data;
using GamificationApp.Server.Repositories.Interfaces;
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
    }
}
