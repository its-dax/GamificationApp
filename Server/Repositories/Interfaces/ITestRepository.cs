using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetTests();
        Task<Test> GetTest(int id);
        Task<Test> AddTest(Test test);
    }
}
