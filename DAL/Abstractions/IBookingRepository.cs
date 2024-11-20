using DAL.Models;

namespace DAL.Abstractions;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(int bookingId);
    Task<int> CreateAsync(Booking booking);
    Task<List<Booking>> QueryByHotelId(int hotelId);
}