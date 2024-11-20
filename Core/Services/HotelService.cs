using Core.Abstractions;
using DAL.Abstractions;
using DAL.Models;
namespace Core.Services
{
    public class HotelService(IHotelRepository hotelRepository) : IHotelService
    {
        public async Task<List<Hotel>> GetByNameAsync(string hotelName)
        {
            return await hotelRepository.GetByNameAsync(hotelName);
        }
    }
}
