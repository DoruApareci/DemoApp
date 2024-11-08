using DemoApp.Shared.Models;

namespace DemoApp.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(Guid id);
        Task<IEnumerable<Room>> GetRoomsByDormAsync(Guid dormId);
        Task<IEnumerable<Room>> GetRoomsByFloorAsync(int floor);
        Task<Room> CreateRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(Guid id);
    }
}
