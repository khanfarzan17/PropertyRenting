using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public class EFBookingRepo:IBookingRepo
    {

        PropertyRentingDbContext ctx= new PropertyRentingDbContext();

        public async Task DeleteBooking(int BookingID)
        {
            Booking booking = await GetBookingById(BookingID);
            ctx.Bookings.Remove(booking);
            await ctx.SaveChangesAsync();

        }

        public async Task<List<Booking>> GetAllBooking()
        {
            List<Booking> bookings = await ctx.Bookings.ToListAsync();
            return bookings;
        }

        public async Task<Booking> GetBookingById(int BookingID)
        {
            try
            {
                Booking booking = await (from b in ctx.Bookings where b.BookingID == BookingID select b).FirstAsync();

                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception("No Such Booking Id is found");
            }
        }

        public async Task<Booking> GetBookingByUserName(string userName)
        {
            try
            {
             
                Booking booking =await (from b in ctx.Bookings where b.UserName == userName select b).FirstAsync();
                return booking;
            }
            catch(Exception ex) 
            {
                throw new Exception("No such Username is found");
            }
        }

        public async Task InsertBooking(Booking booking)
        {
            await ctx.Bookings.AddAsync(booking);
            await ctx.SaveChangesAsync();


        }

        public async Task UpdateBooking(int BookingID, Booking booking)
        {
          Booking booking2update=await GetBookingById(BookingID);

            booking2update.PropertyId=booking.PropertyId;
            booking2update.BookingStatus = booking.BookingStatus;
            booking2update.CheackedOutDate = booking.CheackedOutDate;
            booking2update.CheackedInDate= booking.CheackedInDate;
            await ctx.SaveChangesAsync();



        }
    }
}
