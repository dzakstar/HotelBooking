using DAL.Models;

namespace DAL.Abstractions;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(int bookingId);
}