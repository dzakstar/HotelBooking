using AutoMapper;
using Core.Abstractions;
using DAL.Abstractions;
using DAL.Models;
using Models;

namespace Core.Services
{
    public class BookingService(IBookingRepository bookingRepository
        , IMapper mapper
        , IRoomsRepository roomsRepository) : IBookingService
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
            int hotelId = availabilityRequest.HotelId ??
                          throw new ArgumentException("A hotel Id must be provided in the request.");
            DateOnly arrivalDate = availabilityRequest.ArrivalDate ??
                                   throw new ArgumentException("An arrival date must be provided in the request.");
            DateOnly departureDate = availabilityRequest.DepartureDate ??
                                     throw new ArgumentException("A departure date must be provided in the request.");
            int numberOfGuests = availabilityRequest.NumberOfGuests ??
                                 throw new ArgumentException("The number of guests must be provided in the request.");

            var bookings = await bookingRepository.QueryByHotelId(hotelId);

            IEnumerable<int> bookedRoomIds = bookings
                .Where(b => QueryRangeClashesWithBooking(availabilityRequest, b))
                .Where(b => b.Room.RoomType.Capacity >= numberOfGuests)
                .ToList().Select(b => b.RoomId);

            List<Room> roomsWithCapacity = await roomsRepository
                .GetRoomsWithCapacity(numberOfGuests, hotelId);

            IEnumerable<Room> availableRooms = roomsWithCapacity.Where(r => !bookedRoomIds.Contains(r.Id));

            return new AvailabilityResponse
            {
                AvailableRooms = availableRooms
            };
        }

        private bool QueryRangeClashesWithBooking(AvailabilityRequest availabilityRequest, Booking booking)
        {
            return QueryRangeSpansOrEqualsBooking(availabilityRequest, booking) ||
                   QueryRangeStartsInsideBooking(availabilityRequest, booking) ||
                   QueryRangeEndsInsideBooking(availabilityRequest, booking);
        }
    

    private bool QueryRangeSpansOrEqualsBooking(AvailabilityRequest availabilityRequest, Booking booking)
        {
            return availabilityRequest.ArrivalDate <= booking.ArrivalDate &&
                   availabilityRequest.DepartureDate >= booking.DepartureDate;
        }

        private bool QueryRangeStartsInsideBooking(AvailabilityRequest availabilityRequest, Booking booking)
        {
            return availabilityRequest.ArrivalDate >= booking.ArrivalDate &&
                   availabilityRequest.ArrivalDate < booking.DepartureDate;
        }

        private bool QueryRangeEndsInsideBooking(AvailabilityRequest availabilityRequest, Booking booking)
        {
            return availabilityRequest.DepartureDate <= booking.DepartureDate &&
                   availabilityRequest.DepartureDate > booking.ArrivalDate;
        }
    }
}
