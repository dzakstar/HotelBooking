using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class HotelBookingContext(DbContextOptions<HotelBookingContext> options) : DbContext(options)
    {
        public required DbSet<Hotel> Hotels { get; set; }
        public required DbSet<Room> Rooms { get; set; }
        public required DbSet<RoomType> RoomTypes { get; set; }
        public required DbSet<Booking> Bookings { get; set; }
    }
}
