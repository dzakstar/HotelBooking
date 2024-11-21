namespace Core.Abstractions;

public interface IRoomService
{
    Task<bool> IsRoomCapacityExceeded(int roomId, int numberOfGuests);
}