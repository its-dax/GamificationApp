using GamificationApp.Server.Extensions;
using GamificationApp.Server.Repositories.Interfaces;
using GamificationApp.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamificationApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository testRepository;

        public TestController(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestDto>>> GetTests()
        {
            try
            {
                var tests = await this.testRepository.GetTests();
                var subjects = await this.testRepository.GetSubjects();

                if (tests is null || subjects is null)
                {
                    return NotFound();
                }
                else
                {
                    var testDtos = tests.ConvertToDto(subjects);
                    return Ok(testDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }
    }
}
