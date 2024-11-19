using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAL
{
    public interface IDatabaseService
    {
        void Initialize();
        Task SeedAsync();
        Task ClearAsync();
    }

    public class DatabaseService(HotelBookingContext hotelBookingContext) : IDatabaseService
    {
        public void Initialize()
        {
            hotelBookingContext.Database.EnsureCreated();
        }

        public async Task SeedAsync()
        {
            RoomType singleRoom = new RoomType { Capacity = 1, Name = "Single" };
            RoomType doubleRoom = new RoomType { Capacity = 2, Name = "Double" };
            RoomType deluxeRoom = new RoomType { Capacity = 2, Name = "Deluxe" };

            hotelBookingContext.Hotels.Add(
                new Hotel
                {
                    Name = "Sunny Mansion",
                    Rooms = new List<Room>(6)
                    {
                        new() { RoomType = singleRoom }, new() { RoomType = singleRoom},
                        new() { RoomType = doubleRoom }, new() { RoomType = doubleRoom},
                        new() { RoomType = deluxeRoom }, new() { RoomType = deluxeRoom},
                    }
                });

            hotelBookingContext.Hotels.Add(
                new Hotel
                {
                    Name = "Radisson Purple",
                    Rooms = new List<Room>(6)
                    {
                        new() { RoomType = singleRoom }, new() { RoomType = singleRoom},  new() { RoomType = singleRoom},
                        new() { RoomType = doubleRoom }, new() { RoomType = doubleRoom},
                        new() { RoomType = deluxeRoom }
                    }
                });

            await hotelBookingContext.SaveChangesAsync();
        }

        public async Task ClearAsync()
        {
            await hotelBookingContext.Database.ExecuteSqlRawAsync($"DELETE FROM Bookings;");
            await hotelBookingContext.Database.ExecuteSqlRawAsync($"DELETE FROM Rooms;");
            await hotelBookingContext.Database.ExecuteSqlRawAsync($"DELETE FROM Hotels;");
            await hotelBookingContext.Database.ExecuteSqlRawAsync($"DELETE FROM RoomTypes;");
        }
    }

}
