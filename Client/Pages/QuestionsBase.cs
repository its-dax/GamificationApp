using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace GamificationApp.Client.Pages
{
    public class QuestionsBase : ComponentBase
    {
        [Inject]
        public IQuestionService QuestionService { get; set; }

        public IEnumerable<QuestionDto> Questions { get; set; }

        protected override async Task OnInitializedAsync()
        {
           Questions = await QuestionService.GetQuestions();
        }
    }
}
