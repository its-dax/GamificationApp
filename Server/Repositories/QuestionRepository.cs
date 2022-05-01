using GamificationApp.Server.Data;
using GamificationApp.Server.Repositories.Interfaces;
using GamificationApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GamificationApp.Server.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext dataContext;

        public QuestionRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            var questions = await this.dataContext.Questions.ToListAsync();
            return questions;
        }

        public async Task<IEnumerable<Question>> GetQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            var subjects = await this.dataContext.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<IEnumerable<Subject>> GetSubject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
