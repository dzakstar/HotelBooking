using Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// API endpoints for database operations
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class DataController(IDataService dataService) : ControllerBase
    {
        /// <summary>
        /// Add Seed values to data store. Bookings will NOT be added. Calling this endpoint
        /// more than once will result in duplicate data.
        /// </summary>
        [HttpGet("Seed")]
        public async Task SeedAsync()
        {
            await dataService.SeedAsync();
        }

        /// <summary>
        /// Clears ALL data fom the data store.
        /// </summary>
        [HttpGet("Clear")]
        public async Task ClearAsync()
        {
            await dataService.ClearAsync();
        }
    }
}
