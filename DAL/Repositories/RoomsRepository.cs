using DAL.Models;
using System;
using System.Collections.Generic;
using DAL.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RoomsRepository(HotelBookingContext hotelBookingContext) : IRoomsRepository
    {
        public async Task<List<Room>> GetRoomsWithCapacity(int numberOfGuests, int hotelId)
        {
            return await hotelBookingContext.Rooms.Include(r => r.RoomType)
                .Where(r => r.RoomType.Capacity >= numberOfGuests && r.HotelId == hotelId)
                .ToListAsync();
        }
    }
}
