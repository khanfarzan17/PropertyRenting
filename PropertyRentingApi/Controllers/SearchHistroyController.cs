using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentEaseLibrary.Models;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHistroyController : ControllerBase
    {

        ISearchHistoryRepo SearchHistoryRepo;
        public SearchHistroyController(ISearchHistoryRepo serachRepo)
        {
            SearchHistoryRepo = serachRepo;
        }
        [HttpGet("api/SearchQuery/user")]

        public async Task<ActionResult> GetSearchQuery(string UserName)
        {

            List<string> SearchQuery = await SearchHistoryRepo.OldSearch(UserName);

            return Ok(SearchQuery);


        }

        [HttpGet("api/SearchQuery/SearchHistory")]

        public async Task<ActionResult> GetPropertyBySearchQuery(string SearchQuery)
        {
            try
            {
                List<RentProperty> searchProperty = await SearchHistoryRepo.SearchRentProperty(SearchQuery);

                return Ok(searchProperty);

            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }
        [HttpPost]

        public async Task<ActionResult> Insert(SearchHistory item)
        {
            await SearchHistoryRepo.InsertSearchHistory(item);
            return Created($"api/item/{item.SearchID}", item);

        }



    }
}
