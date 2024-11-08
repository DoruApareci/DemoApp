using DemoApp.Data;
using DemoApp.Services.Interfaces;
using DemoApp.Shared.Models;

namespace DemoApp.Services.Implementations
{
    public class RoomService(ApplicationDbContext _dbContext) : IRoomService
    {
        public async Task<Room> CreateRoomAsync(Room room)
        {
            _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public Task DeleteRoomAsync(Guid id)
        {
            var room = _dbContext.Rooms.Find(id);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            _dbContext.Rooms.Remove(room);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return Task.FromResult(_dbContext.Rooms.AsEnumerable());
        }

        public Task<Room> GetRoomByIdAsync(Guid id)
        {
            return Task.FromResult(_dbContext.Rooms.Find(id));
        }

        public Task<IEnumerable<Room>> GetRoomsByDormAsync(Guid dormId)
        {
            return Task.FromResult(_dbContext.Rooms.Where(r => r.DormId == dormId).AsEnumerable());
        }

        public Task<IEnumerable<Room>> GetRoomsByFloorAsync(int floor)
        {
            return Task.FromResult(_dbContext.Rooms.Where(r => r.Floor == floor).AsEnumerable());
        }

        public Task UpdateRoomAsync(Room room)
        {
            _dbContext.Rooms.Update(room);
            return Task.CompletedTask;
        }
    }
}
