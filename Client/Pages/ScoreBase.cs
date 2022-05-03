using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace GamificationApp.Client.Pages
{
    public class ScoreBase : ComponentBase
    {
        [Inject]
        public IScoreService ScoreService { get; set; }

        [Parameter]
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<ScoreDto> Scores { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                Scores = await ScoreService.GetScoreByStudent(Id);

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }


        protected async Task UpdateScore(int id, int qty)
        {
            

            try
            {
                if (qty > 0)
                {
                    var updateScoreDto = new ScoreQtyUpdateDto
                    {
                        ScoreId = id,
                        Qty = qty
                    };
                    var returnedUpdateScoreDto = await this.ScoreService.UpdatePoints(updateScoreDto);
                }
                else
                {
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
