namespace DAL.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public required RoomType RoomType { get; set; }
    }
}
