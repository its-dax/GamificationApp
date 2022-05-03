using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace GamificationApp.Client.Services
{
    public class ScoreService : IScoreService
    {
        private readonly HttpClient _httpClient;

        public ScoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<List<ScoreDto>> GetScoreByStudent(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScoreDto>> GetScoreBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<ScoreDto> UpdatePoints(ScoreQtyUpdateDto scoreQtyUpdateDto)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(scoreQtyUpdateDto);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await _httpClient.PatchAsync($"api/Score/{scoreQtyUpdateDto.ScoreId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ScoreDto>();
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
