using DAL.Models;

namespace DAL.Abstractions;

public interface IRoomsRepository
{
    Task<List<Room>> GetRoomsWithCapacity(int numberOfGuests, int hotelId);
}