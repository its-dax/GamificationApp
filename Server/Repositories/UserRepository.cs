using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
