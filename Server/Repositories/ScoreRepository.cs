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
        public Task<IEnumerable<Score>> GetScore(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Score>> GetScores()
        {
            var scores = await _dataContext.Scores.ToListAsync();
            return scores;
        }

        public Task<IEnumerable<Subject>> GetSubject(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var subjects = await _dataContext.Subjects.ToListAsync();
            return subjects;
        }

        public Task<IEnumerable<User>> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }
    }
}
