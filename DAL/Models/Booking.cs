namespace DAL.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTimeOffset ArrivalDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
        public string CustomerName { get; set; }
        public Room Room { get; set; }
    }
}
