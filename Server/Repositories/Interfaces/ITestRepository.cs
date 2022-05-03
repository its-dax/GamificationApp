using GamificationApp.Shared.Models;

namespace GamificationApp.Server.Repositories.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetTests();
        Task<IEnumerable<Test>> GetTest(int id);
        Task<IEnumerable<Subject>> GetSubjects();
        Task<IEnumerable<Subject>> GetSubject(int id);
    }
}
