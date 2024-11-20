using System.ComponentModel;
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

        public async Task<AvailabilityResponse> CheckAvailabilityAsync(AvailabilityRequest availabilityRequest)
        {
            int hotelId = availabilityRequest.HotelId ?? throw new InvalidEnumArgumentException("A hotel Id must be provided");
            DateOnly arrivalDate = availabilityRequest.ArrivalDate ?? throw new InvalidEnumArgumentException("An arrival date must be provided");
            DateOnly departureDate = availabilityRequest.DepartureDate ?? throw new InvalidEnumArgumentException("A departure date must be provided");
            int numberOfGuests = availabilityRequest.NumberOfGuests ?? throw new InvalidEnumArgumentException("The number of guests must be provided");

            var bookings = await bookingRepository.QueryByHotelId(hotelId);
            return new AvailabilityResponse();
        }
    }
}
