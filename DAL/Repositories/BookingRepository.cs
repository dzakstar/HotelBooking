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

        public async Task<int> CreateAsync(Booking booking)
        {
            hotelBookingContext.Add(booking);
            int createdRecords = await hotelBookingContext.SaveChangesAsync();

            return createdRecords;
        }

        public async Task<List<Booking>> QueryByHotelId(int hotelId)
        {
            return await hotelBookingContext.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r.RoomType)
                .Where(b => b.Room.HotelId == hotelId)
                .ToListAsync();
        }
    }
}
