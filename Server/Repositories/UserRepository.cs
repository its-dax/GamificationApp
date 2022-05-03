using GamificationApp.Server.Data;
using GamificationApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationApp.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}
