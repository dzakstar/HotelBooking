namespace Models
{
    public class BookingResponse
    {
        public int BookingReference { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly DepartureDate { get; set; }
        public required string Name { get; set; }
        public int NumberOfGuests { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
    }
}
