using Core.Abstractions;
using DAL.Abstractions;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Web.Controllers
{
    /// <summary>
    /// API endpoint for Booking operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class BookingController(IRoomService roomService,
        IBookingService bookingService) : ControllerBase
    {
        /// <summary>
        /// Retrieves a Booking by ID.
        /// </summary>
        [HttpGet("/{bookingId}")]
        [ProducesResponseType(typeof(BookingResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAsync(int bookingId)
        {
            BookingResponse? bookingResponse = await bookingService.GetBookingById(bookingId);
            if (bookingResponse is null)
            {
                return NotFound();
            }
            return Ok(bookingResponse);
        }

        /// <summary>
        /// Create a booking.
        /// </summary>
        [HttpPost("/Create")]
        [ProducesResponseType(typeof(BookingResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BookingResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBookingAsync(BookingRequest bookingRequest)
        {
            var roomId = bookingRequest.RoomId.Value;
            var numberOfGuests = bookingRequest.NumberOfGuests.Value;

            bool isRoomCapacityExceeded = await roomService.IsRoomCapacityExceeded(roomId, numberOfGuests);
            if (isRoomCapacityExceeded)
            {
                return BadRequest();
            }
            
            BookingResponse bookingResponse = await bookingService.MakeBookingAsync(bookingRequest);
            return Ok(bookingResponse);
        }

        /// <summary>
        /// Checks room availability by hotel, dates and number of guests
        /// </summary>
        [HttpPost("Availability")]
        [ProducesResponseType(typeof(AvailabilityResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> QueryAvailabilityAsync(AvailabilityRequest availabilityRequest)
        {
            AvailabilityResponse availabilityResponse = await bookingService.CheckAvailabilityAsync(availabilityRequest);
            return Ok(availabilityResponse);
        }
    }
}