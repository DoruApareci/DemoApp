using DemoApp.Shared.Models;

namespace DemoApp.Services.Interfaces
{
    public interface IDormService
    {
        Task<IEnumerable<Dorm>> GetAllDormsAsync();
        Task<Dorm> GetDormByIdAsync(Guid id);
        Task<IEnumerable<Dorm>> GetDormsByAddressAsync(string address);
        Task<Dorm> CreateDormAsync(Dorm dorm);
        Task UpdateDormAsync(Dorm dorm);
        Task DeleteDormAsync(Guid id);
        Task<IEnumerable<Room>> GetRoomsInDormAsync(Guid dormId);
        Task<int> GetTotalRoomsCountInDormAsync(Guid dormId);
    }
}
