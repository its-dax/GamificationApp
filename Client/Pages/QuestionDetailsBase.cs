using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace GamificationApp.Client.Pages
{
    public class QuestionDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IQuestionService QuestionService { get; set; }

        public QuestionDto Question { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Question = await QuestionService.GetQuestion(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
