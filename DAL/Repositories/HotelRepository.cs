using DAL.Abstractions;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class HotelRepository(HotelBookingContext hotelBookingContext) : IHotelRepository
    {
        public async Task<List<Hotel>> GetByNameAsync(string hotelName)
        {
            return await hotelBookingContext.Hotels
                .Where(h => h.Name == hotelName)
                .Include(h => h.Rooms)
                .ThenInclude(r => r.RoomType)
                .ToListAsync();
        }
    }
}
