using GamificationApp.Server.Extensions;
using GamificationApp.Server.Repositories.Interfaces;
using GamificationApp.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamificationApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreController(IScoreRepository ScoreRepository)
        {
            _scoreRepository = ScoreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreDto>>> GetScores()
        {
            try
            {
                var scores = await _scoreRepository.GetScores();
                var subjects = await _scoreRepository.GetSubjects();
                var users = await _scoreRepository.GetUsers();

                if (scores is null || users is null || subjects is null)
                {
                    return NotFound();
                }
                else
                {
                    var scoresDto = scores.ConvertToDto(subjects, users);
                    return Ok(scoresDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }
    }
}
