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

        public async Task<Question> GetQuestion(int id)
        {
            var question = await dataContext.Questions.SingleOrDefaultAsync(q => q.Id == id);
            return question;
        }

        public Task<Question> AddQuestion(int id)
        {
            throw new NotImplementedException();
        }


        //public async Task<IEnumerable<Question>> GetQuestionsBySubject(int subjectId)
        //{
        //    var questions = await this.dataContext.Questions.Include(q=> q.
        //}
    }
}
