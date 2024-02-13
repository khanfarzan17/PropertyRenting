﻿using Microsoft.AspNetCore.Http;
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
        [HttpGet("ByUserName/{UserName}")]

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

        [HttpGet("ById/{booking}")]

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

        [HttpPost]

        public async Task<ActionResult>InsertBooking(Booking booking)
        {
            await BookingRepo.InsertBooking(booking);
            return Created($"api/booking/{booking.BookingID}", booking);

        }

        [HttpDelete("{BookingID}")]

        public async Task<ActionResult> DeleteBooking(int BookingID)
        {
            await BookingRepo.DeleteBooking(BookingID);
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult>UpdateBooking(int BookingID, Booking booking)
        {
            await BookingRepo.UpdateBooking(BookingID, booking);
            return Ok();    
        }


    }
}