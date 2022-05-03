using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);

    }
}
