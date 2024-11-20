using AutoMapper;
using Core.Abstractions;
using DAL.Abstractions;
using DAL.Models;
using Models;

namespace Core.Services
{
    public class BookingService(IBookingRepository bookingRepository, IMapper mapper) : IBookingService
    {
        public async Task<BookingResponse> MakeBookingAsync(BookingRequest bookingRequest)
        {
            var booking = mapper.Map<Booking>(bookingRequest);
            await bookingRepository.CreateAsync(booking);
            var bookingResponse = mapper.Map<BookingResponse>(booking);
            return bookingResponse;
        }
    }
}
