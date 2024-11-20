using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Abstractions;

namespace Web.Controllers
{
    /// <summary>
    /// API endpoint for Hotel information.
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class HotelController(IHotelService hotelService) : ControllerBase
    {
        /// <summary>
        /// Searches for Hotels by name (case-insensitive).
        /// </summary>
        [HttpPost("FindByName")]
        [ProducesResponseType(typeof(List<Hotel>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindByNameAsync(string hotelName)
        {
            List<Hotel> hotels = await hotelService.GetByNameAsync(hotelName);

            if (hotels.Count == 0)
            {
                return NotFound();
            }
            return Ok(hotels);
        }
    }
}