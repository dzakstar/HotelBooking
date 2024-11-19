using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// API endpoints for database operations
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class DataController(
        IDatabaseService databaseService) : ControllerBase
    {
        /// <summary>
        /// Add Seed values to database. Bookings will NOT be added. Calling this endpoint
        /// more than once will result in duplicate data.
        /// </summary>
        [HttpGet("Seed")]
        public async Task SeedAsync()
        {
            await databaseService.SeedAsync();
        }

        /// <summary>
        /// Clears ALL data fom the database.
        /// </summary>
        [HttpGet("Clear")]
        public async Task ClearAsync()
        {
            await databaseService.ClearAsync();
        }
    }
}
