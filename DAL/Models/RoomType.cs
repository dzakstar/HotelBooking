namespace DAL.Models;

public class RoomType
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public required string Name { get; set; }

}