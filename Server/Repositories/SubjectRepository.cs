using GamificationApp.Server.Data;
using GamificationApp.Server.Repositories.Interfaces;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationApp.Server.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DataContext dataContext;

        public SubjectRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var subjects = await this.dataContext.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<Subject> GetSubject(int id)
        {
            var subject = await dataContext.Subjects.SingleOrDefaultAsync(s => s.Id == id);
            return subject;
        }

    }
}
