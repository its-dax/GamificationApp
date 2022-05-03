﻿using GamificationApp.Server.Extensions;
using GamificationApp.Server.Repositories.Interfaces;
using GamificationApp.Shared.DTOs;
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

        public QuestionController(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            try
            {
                var questions = await this.questionRepository.GetQuestions();
                var subjects = await this.questionRepository.GetSubjects();

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

                if (question is null )
                {
                    return BadRequest();
                }
                else
                {
                    var subject = await this.questionRepository.GetSubject(question.SubjectId);
                    var questionDto = question.ConvertToDto(subject);
                    return Ok(questionDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba az adatok kinyerésében.");
            }
        }
    }
}
