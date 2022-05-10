using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GamificationApp.Client.Pages
{
    public class QuestionsBase : ComponentBase
    {
        [Inject]
        public IQuestionService QuestionService { get; set; }
        public int UsersId { get; set; }
        public string? ErrorMessage { get; set; } = null;


        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        public IEnumerable<QuestionDto> Questions { get; set; }
        public IEnumerable<QuestionDto> MyQuestions { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        QuestionDto addQuestion = new QuestionDto();
        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;

            try
            {
                UsersId = Int32.Parse(authState.User.Claims.First().Value);
                QuestionDto addQuestion = new QuestionDto()
                {
                    UserId = Int32.Parse(authState.User.Claims.First().Value)
                };

                addQuestion.UserId = UsersId;
                Questions = await QuestionService.GetQuestions();
                Subjects = await QuestionService.GetSubjects();
                MyQuestions = Questions.Where(q => q.SubjectTeacher == UsersId);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
