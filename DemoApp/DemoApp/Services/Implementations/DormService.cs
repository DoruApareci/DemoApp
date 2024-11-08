using DemoApp.Data;
using DemoApp.Services.Interfaces;
using DemoApp.Shared.Models;

namespace DemoApp.Services.Implementations
{
    public class DormService(ApplicationDbContext _dbContext) : IDormService
    {

        public async Task<Dorm> CreateDormAsync(Dorm dorm)
        {
            _dbContext.Dorms.Add(dorm);
            await _dbContext.SaveChangesAsync();
            return dorm;
        }

        public Task DeleteDormAsync(Guid id)
        {
            var dorm = _dbContext.Dorms.Find(id);
            if (dorm == null)
            {
                throw new Exception("Dorm not found");
            }
            _dbContext.Dorms.Remove(dorm);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Dorm>> GetAllDormsAsync()
        {
            return Task.FromResult(_dbContext.Dorms.AsEnumerable());
        }

        public Task<Dorm> GetDormByIdAsync(Guid id)
        {
            return Task.FromResult(_dbContext.Dorms.Find(id));
        }

        public Task<IEnumerable<Dorm>> GetDormsByAddressAsync(string address)
        {
            return Task.FromResult(_dbContext.Dorms.Where(d => d.Address.Contains(address)).AsEnumerable());
        }

        public Task<IEnumerable<Room>> GetRoomsInDormAsync(Guid dormId)
        {
            return Task.FromResult(_dbContext.Rooms.Where(r => r.DormId == dormId).AsEnumerable());
        }

        public Task<int> GetTotalRoomsCountInDormAsync(Guid dormId)
        {
            return Task.FromResult(_dbContext.Rooms.Count(r => r.DormId == dormId));
        }

        public Task UpdateDormAsync(Dorm dorm)
        {
            _dbContext.Dorms.Update(dorm);
            return Task.CompletedTask;
        }
    }
}
