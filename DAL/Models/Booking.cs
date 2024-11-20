using System.Runtime.InteropServices.JavaScript;

namespace DAL.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly DepartureDate { get; set; }
        public string Name { get; set; }
        public Room Room { get; set; }
        public int NumberOfOccupants { get; set; }
    }
}
