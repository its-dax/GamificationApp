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
        private readonly ISubjectRepository subjectRepository;

        public TestController(ITestRepository testRepository, ISubjectRepository subjectRepository)
        {
            this.testRepository = testRepository;
            this.subjectRepository = subjectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestDto>>> GetTests()
        {
            try
            {
                var tests = await this.testRepository.GetTests();
                var subjects = await this.subjectRepository.GetSubjects();

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
        [HttpPost]
        public async Task<ActionResult<TestDto>> AddTest([FromBody] TestDto testDto)
        {
            var subjects = await subjectRepository.GetSubjects();

            var test = testDto.ConvertFromDto(subjects);
            if (test is null)
            {
                return BadRequest();
            }
            var result = await this.testRepository.AddTest(test);
            return Ok(result);
        }
    }
}
