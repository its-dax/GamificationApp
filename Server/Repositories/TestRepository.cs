using GamificationApp.Server.Data;
using GamificationApp.Server.Repositories.Interfaces;
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

        public async Task<Subject> GetSubject(int id)
        {
            var subject = await dataContext.Subjects.SingleOrDefaultAsync(s => s.Id == id);
            return subject;
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var subjects = await this.dataContext.Subjects.ToListAsync();
            return subjects;
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
