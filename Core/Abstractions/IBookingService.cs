using Models;

namespace Core.Abstractions;

public interface IBookingService
{
    Task<BookingResponse> MakeBookingAsync(BookingRequest bookingRequest);
}