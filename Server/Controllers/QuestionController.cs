using GamificationApp.Server.Extensions;
using GamificationApp.Server.Repositories.Interfaces;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GamificationApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository questionRepository;
        private readonly ISubjectRepository subjectRepository;

        public QuestionController(IQuestionRepository questionRepository, ISubjectRepository subjectRepository)
        {
            this.questionRepository = questionRepository;
            this.subjectRepository = subjectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            try
            {
                var questions = await this.questionRepository.GetQuestions();
                var subjects = await this.subjectRepository.GetSubjects();

                if (questions is null || subjects is null)
                {
                    return NotFound();
                }
                else
                {
                    var questionDtos = questions.ConvertToDto(subjects);
                    return Ok(questionDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
        {
            try
            {
                var question = await this.questionRepository.GetQuestion(id);

                if (question is null)
                {
                    return BadRequest();
                }
                else
                {
                    var subject = await this.subjectRepository.GetSubject(question.SubjectId);
                    var questionDto = question.ConvertToDto(subject);
                    return Ok(questionDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion([FromBody] QuestionDto questionDto)
        {
            var subjects = await this.subjectRepository.GetSubjects();

            var question = questionDto.ConvertFromDto(subjects);
            if (question is null)
            {
                return BadRequest();
            }

            var result = await this.questionRepository.AddQuestion(question);

            return Ok(result);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Question>> PatchQuestion(int id)
        {
            try
            {
                var question = await this.questionRepository.ApproveQuestion(id);
                if (question == null)
                {
                    return NotFound();
                }

                return Ok(question);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Question>> DeleteQuestion(int id)
        {
            try
            {
                var deleteItem = await this.questionRepository.DeleteQuestion(id);

                if (deleteItem is null)
                {
                    return NotFound();
                }
                return Ok(deleteItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
