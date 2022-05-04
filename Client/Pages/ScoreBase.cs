using GamificationApp.Client.Services.Contracts;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GamificationApp.Client.Pages
{
    public class ScoreBase : ComponentBase
    {
        [Inject]
        public IScoreService ScoreService { get; set; }

        [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

        public string? ErrorMessage { get; set; } = null;
        public IEnumerable<ScoreDto> Scores { get; set; }
        public IEnumerable<ScoreDto> MyScores { get; set; }
        public string? TempError { get; set; } = null;
        public int StudentId { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var authState = await authenticationStateTask;

            try
            {
                StudentId = Int32.Parse(authState.User.Claims.First().Value);
                TempError = StudentId.ToString();

                Scores = await ScoreService.GetScores();
                MyScores = Scores.Where(x=>x.UserId == StudentId).ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        //protected async Task UpdateScore(int id, int qty)
        //{
            

        //    try
        //    {
        //        if (qty > 0)
        //        {
        //            var updateScoreDto = new ScoreQtyUpdateDto
        //            {
        //                ScoreId = id,
        //                Qty = qty
        //            };
        //            var returnedUpdateScoreDto = await this.ScoreService.UpdatePoints(updateScoreDto);
        //        }
        //        else
        //        {
                    
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
