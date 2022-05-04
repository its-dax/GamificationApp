using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace GamificationApp.Client.Services
{
    public class ScoreService : IScoreService
    {
        private readonly HttpClient httpClient;

        public ScoreService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<ScoreDto>> GetScores()
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Score/GetScores");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ScoreDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ScoreDto>>();
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
       
        //public async Task<ScoreDto> UpdatePoints(ScoreQtyUpdateDto scoreQtyUpdateDto)
        //{
        //    try
        //    {
        //        var jsonRequest = JsonConvert.SerializeObject(scoreQtyUpdateDto);
        //        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

        //        var response = await this.httpClient.PatchAsync($"api/Score/{scoreQtyUpdateDto.ScoreId}", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadFromJsonAsync<ScoreDto>();
        //        }

        //        return null;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
