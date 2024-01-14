using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentEaseLibrary.Models;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {

        IFavoriteRepo FavoriteRepo;

        public FavoriteController(IFavoriteRepo favoriteRepo)
        {
            
            FavoriteRepo = favoriteRepo;

        }

        [HttpGet("{UserName}")]

        public async Task<ActionResult> GetFavorite(string userName)
        {
            List<RentProperty> favourite = await FavoriteRepo.GetAllFavoriteByUserName(userName);
            return Ok(favourite);
        }
        [HttpPost]
        public async Task<ActionResult>InsertFavorite(Favorite favorite)
        {

            await FavoriteRepo.InsertFavorites(favorite);
            return Ok();
        }

        [HttpDelete("{UserName}")]

        public async Task<ActionResult>DeleteFavorite(Favorite favorite)
        {
            await FavoriteRepo.DeleteFavorites(favorite);
            return Ok();
        }



    }
}
