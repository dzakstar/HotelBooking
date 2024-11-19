using DAL.Abstractions;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BookingRepository(HotelBookingContext hotelBookingContext) : IBookingRepository
    {
        public async Task<Booking?> GetByIdAsync(int bookingId)
        {
            return await hotelBookingContext.Bookings
                .Where(b => b.Id == bookingId)
                .Include(b => b.Room)
                .SingleOrDefaultAsync();
        }
    }
}
