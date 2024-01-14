using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentEaseLibrary.Models;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentPropertiesController : ControllerBase
    {
        IRentPropertRepo RentRepo;

        public RentPropertiesController(IRentPropertRepo rentPropertyRepo)
        {
            RentRepo = rentPropertyRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<RentProperty> rentProperties = await RentRepo.GetAllProperty();
            return Ok(rentProperties);
        }

        [HttpGet("{PropertyId}")]

        public async Task<ActionResult>GetByPropertyId(int propertyId)
        {
            try
            {
                RentProperty rentProperty = await RentRepo.GetPropertyById(propertyId);
                return Ok(rentProperty);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPost]

        public async Task<ActionResult> InsertProperty(RentProperty property)
        {
            await RentRepo.InsertRentProperty(property);
            return Created($"api/property/{property.PropertyId}", property);

        }

        [HttpDelete("{PropertyId}")]

        public async Task<ActionResult>DeleteProperty(int PropertyId)
        {
            await RentRepo.DeleteRentProperty(PropertyId);
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult>UpdateProperty(int PropertyId, RentProperty property)
        {
            await RentRepo.UpdateRentProperty(PropertyId, property);
            return Ok();
        }



    }
}
