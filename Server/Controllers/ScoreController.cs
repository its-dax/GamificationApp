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
        private readonly IScoreRepository _scoreRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;

        public ScoreController(IScoreRepository ScoreRepository, IUserRepository userRepository, ISubjectRepository subjectRepository)
        {
            _scoreRepository = ScoreRepository;
            _userRepository = userRepository;
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        [Route("{userId}/GetScoresByUser")]
        public async Task<ActionResult<IEnumerable<ScoreDto>>> GetScoresByUser(int userId)
        {
            try
            {
                var scores = await _scoreRepository.GetScoresByStudent(userId);
                if (scores == null)
                {
                    return NoContent();
                }
                var subjects = await _subjectRepository.GetSubjects();
                var users = await _userRepository.GetUsers();

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
                var scores = await _scoreRepository.GetScoresBySubject(subjectId);
                if (scores == null)
                {
                    return NoContent();
                }
                var subjects = await _subjectRepository.GetSubjects();
                var users = await _userRepository.GetUsers();

                var scoresDto = scores.ConvertToDto(subjects, users);

                return Ok(scoresDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }

        public async Task<ActionResult<ScoreQtyUpdateDto>> UpdateQty(int id, ScoreQtyUpdateDto scoreQtyUpdateDto)
        {
            try
            {
                var score = await _scoreRepository.UpdateScore(id, scoreQtyUpdateDto);
                if (score == null)
                {
                    return NotFound();
                }

                var subjects = await _subjectRepository.GetSubject(score.SubjectId);
                var users = await _userRepository.GetUser(score.UserId);

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
