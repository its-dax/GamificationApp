using GamificationApp.Server.Data;
using GamificationApp.Server.Repositories.Interfaces;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationApp.Server.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext dataContext;

        public TestRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Test> AddTest(TestDto testDto)
        {
            //    var test = await ()
            //var result = await this.dataContext.Tests.AddAsync(Test);
            //    await this.dataContext.SaveChangesAsync();
            //    return result.Entity;
            return null;
        }

        public async Task<Test> GetTest(int id)
        {
            var test = await dataContext.Tests.SingleOrDefaultAsync(t => t.Id == id);
            return test;
        }

        public async Task<IEnumerable<Test>> GetTests()
        {
            var tests = await this.dataContext.Tests.ToListAsync();
            return tests;
        }
    }
}
