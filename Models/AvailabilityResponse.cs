using DAL.Models;

namespace Models
{
    public class AvailabilityResponse
    {
        public required IEnumerable<Room> AvailableRooms { get; set; }
        public bool HasAvailability => AvailableRooms.Any();
    }
}
