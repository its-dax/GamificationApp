using System.Net.Http.Json;
using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;

namespace GamificationApp.Client.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly HttpClient httpClient;

        public QuestionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestions()
        {
            try
            {
                var questions = await this.httpClient.GetFromJsonAsync<IEnumerable<QuestionDto>>("api/Question");
                return questions;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
