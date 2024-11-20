namespace Models
{
    public class BookingResponse
    {
        public string BookingReference { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly DepartureDate { get; set; }
        public string Name { get; set; }
        public int NumberOfOccupants { get; set; }
    }
}
