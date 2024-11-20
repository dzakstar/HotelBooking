using DAL.Models;

namespace Core.Abstractions;

public interface IHotelService
{
    Task<List<Hotel>> GetByNameAsync(string hotelName);
}