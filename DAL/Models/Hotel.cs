namespace DAL.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required ICollection<Room> Rooms { get; set; }
    }
}
