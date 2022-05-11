using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using System.Net.Http.Json;

namespace GamificationApp.Client.Services
{
    public class TestService : ITestService
    {
        private readonly HttpClient httpClient;

        public TestService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Test> AddTest(TestDto testDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/test", testDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Test);
                    }

                    return await response.Content.ReadFromJsonAsync<Test>();
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
