using System.Net.Http.Json;
using System.Text;
using GamificationApp.Client.Pages;
using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Newtonsoft.Json;

namespace GamificationApp.Client.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly HttpClient httpClient;

        public QuestionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<GamificationApp.Shared.Models.Question> AddQuestion(QuestionDto questionDto)
        {
            var response = await httpClient.PostAsJsonAsync<QuestionDto>("api/question", questionDto);
            return null;
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

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Subject");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Subject>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<Subject>>();
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

        public async Task<QuestionDto> ApproveQuestion(ApproveQuestionDto qst)
        {
            var jsonRequest = JsonConvert.SerializeObject(qst);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

            var response = await httpClient.PatchAsync($"Api/Question/{qst.QuestionId}", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<QuestionDto>();
            }
            return null;
        }

        public async Task<QuestionDto> DeleteQuestion(ApproveQuestionDto delete)
        {
            var response = await httpClient.DeleteAsync($"Api/Question/{delete.QuestionId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<QuestionDto>();
            }
            return null;
        }
    }
}
