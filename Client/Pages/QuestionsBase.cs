using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
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

        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;

            try
            {
                UsersId = Int32.Parse(authState.User.Claims.First().Value);

                Questions = await QuestionService.GetQuestions();
                MyQuestions = Questions.Where(q => q.SubjectTeacher == UsersId);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
