using System.Net.Http.Json;
using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;

namespace GamificationApp.Client.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly HttpClient _httpClient;

        public QuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestions()
        {
            try
            {
                var questions = await _httpClient.GetFromJsonAsync<IEnumerable<QuestionDto>>("api/Questions");
                return questions;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
