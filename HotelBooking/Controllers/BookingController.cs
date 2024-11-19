using DAL.Abstractions;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// API endpoint for Booking operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class BookingController(
        IBookingRepository bookingRepository) : ControllerBase
    {
        /// <summary>
        /// Retrieves a Booking by ID.
        /// </summary>
        [HttpGet("/{bookingId}")]
        [ProducesResponseType(typeof(Booking),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindByNameAsync(int bookingId)
        {
            Booking? booking = await bookingRepository.GetByIdAsync(bookingId);

            if (booking is null)
            {
                return NotFound();
            }
            return Ok(booking);
        }
    }
}