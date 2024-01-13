using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentEaseLibrary.Models
{
    public interface IBookingRepo
    {

        Task<List<Booking>> GetAllBooking();
        Task<Booking> GetBookingById(int BookingID);

        Task<Booking>GetBookingByUserName(string userName);

        Task InsertBooking(Booking booking);

        Task DeleteBooking(int  BookingID);
        Task UpdateBooking(int BookingID,Booking booking);
    }
}
