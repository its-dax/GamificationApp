using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace GamificationApp.Client.Pages
{
    public class ScoreBase
    {
        [Inject]
        public IScoreService ScoreService { get; set; }
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
