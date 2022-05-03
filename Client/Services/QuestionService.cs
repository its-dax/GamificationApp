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

        public async Task<QuestionDto> GetQuestion(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"Api/Question/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(QuestionDto);
                    }

                    return await response.Content.ReadFromJsonAsync<QuestionDto>();
                }
                else
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception(msg);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestions()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Question");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<QuestionDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<QuestionDto>>();
                }
                else
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception(msg);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
