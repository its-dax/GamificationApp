using GamificationApp.Server.Extensions;
using GamificationApp.Server.Repositories;
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
        private readonly IScoreRepository scoreRepository;
        private readonly IUserRepository userRepository;
        private readonly ISubjectRepository subjectRepository;

        public ScoreController(IScoreRepository ScoreRepository, IUserRepository userRepository, ISubjectRepository subjectRepository)
        {
            this.scoreRepository = ScoreRepository;
            this.userRepository = userRepository;
            this.subjectRepository = subjectRepository;
        }

        [HttpGet]
        [Route("GetScores")]
        public async Task<ActionResult<IEnumerable<ScoreDto>>> GetScores()
        {
            try
            {
                var scores = await this.scoreRepository.GetScores();
                if (scores == null)
                {
                    return NoContent();
                }
                var subjects = await this.subjectRepository.GetSubjects();
                var users = await this.userRepository.GetUsers();

                var scoresDto = scores.ConvertToDto(subjects, users);

                return Ok(scoresDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }

        [HttpGet]
        [Route("GetScoresByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<ScoreDto>>> GetScoresByUser(int userId)
        {
            try
            {
                var scores = await this.scoreRepository.GetScoresByStudent(userId);
                if (scores == null)
                {
                    return NoContent();
                }
                var subjects = await this.subjectRepository.GetSubjects();
                var users = await this.userRepository.GetUsers();

                var scoresDto = scores.ConvertToDto(subjects, users);

                return Ok(scoresDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }

        [HttpGet]
        [Route("{subjectId}/GetScoresBySubject")]
        public async Task<ActionResult<IEnumerable<ScoreDto>>> GetScoresBySubject(int subjectId)
        {
            try
            {
                var scores = await this.scoreRepository.GetScoresBySubject(subjectId);
                if (scores == null)
                {
                    return NoContent();
                }
                var subjects = await this.subjectRepository.GetSubjects();
                var users = await this.userRepository.GetUsers();

                var scoresDto = scores.ConvertToDto(subjects, users);

                return Ok(scoresDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<ScoreQtyUpdateDto>> UpdateQty(int id, ScoreQtyUpdateDto scoreQtyUpdateDto)
        {
            try
            {
                var score = await this.scoreRepository.UpdateScore(id, scoreQtyUpdateDto);
                if (score == null)
                {
                    return NotFound();
                }

                var subjects = await this.subjectRepository.GetSubject(score.SubjectId);
                var users = await this.userRepository.GetUser(score.UserId);

                var scoresDto = score.ConvertToDto(subjects, users);

                return Ok(scoresDto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
