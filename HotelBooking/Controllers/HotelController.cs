using DAL.Abstractions;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// API endpoint for Hotel information.
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class HotelController(
        IHotelRepository hotelRepository) : ControllerBase
    {
        /// <summary>
        /// Searches for Hotels by name (case-insensitive).
        /// </summary>
        [HttpPost("FindByName")]
        [ProducesResponseType(typeof(List<Hotel>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindByNameAsync(string hotelName)
        {
            List<Hotel> hotels = await hotelRepository.GetByNameAsync(hotelName);

            if (hotels.Count == 0)
            {
                return NotFound();
            }
            return Ok(hotels);
        }
    }
}