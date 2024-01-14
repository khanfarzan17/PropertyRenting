using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentEaseLibrary.Models;

namespace PropertyRentingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingRepo BookingRepo;
        public BookingController(IBookingRepo bookingRepo)
        {
            BookingRepo = bookingRepo;

        }
        [HttpGet]
        public async Task<ActionResult> GetAllBookings()
        {
            List<Booking>bookings=await BookingRepo.GetAllBooking();
            return Ok(bookings);
        }
        [HttpGet("{api/Booking/UserName}")]

        public async Task<ActionResult> GetBookingByUserName(string username)
        {
            try
            {
                Booking booking = await BookingRepo.GetBookingByUserName(username);
                return Ok(booking);
            }
            catch (Exception )
            {
                throw new Exception("No such Booking is Being Found to that Username");
            }
        }

        [HttpGet("{api/booking}")]

        public async Task<ActionResult>GetById(int BookingId)
        {
            try
            {
                Booking booking = await BookingRepo.GetBookingById(BookingId);
                return Ok(booking);
            }
            catch (Exception )
            {
                throw new Exception("No such Booking Id is Found");
            }
        }



    }
}
