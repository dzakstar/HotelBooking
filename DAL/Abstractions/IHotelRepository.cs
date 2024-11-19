using DAL.Models;

namespace DAL.Abstractions;

public interface IHotelRepository
{
    Task<List<Hotel>> GetByNameAsync(string hotelName);
}