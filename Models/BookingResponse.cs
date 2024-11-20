namespace Models
{
    public class BookingResponse
    {
        public required string BookingReference { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly DepartureDate { get; set; }
        public required string Name { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
