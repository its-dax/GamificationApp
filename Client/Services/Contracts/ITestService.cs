using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;

namespace GamificationApp.Client.Services.Contracts
{
    public interface ITestService
    {
        Task<Test> AddTest(TestDto testDto);
    }
}
