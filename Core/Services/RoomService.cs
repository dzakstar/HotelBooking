using Core.Abstractions;
using DAL.Abstractions;
using DAL.Models;

namespace Core.Services
{
    public class RoomService(IRoomsRepository roomsRepository) : IRoomService
    {
        public async Task<bool> IsRoomCapacityExceeded(int roomId, int numberOfGuests)
        {
            Room room = await roomsRepository.GetById(roomId);
            return room.RoomType.Capacity < numberOfGuests;
        }
    }
}
