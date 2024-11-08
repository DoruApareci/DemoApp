using DemoApp.Data;
using DemoApp.Shared.Models;
using DemoApp.Shared.Services;

namespace DemoApp.Services.Implementations
{
    public class HousingService(ApplicationDbContext _context) : IHousingService
    {
        public async Task<List<HousingRequest>> GetRequestsForUserAsync(Guid userId)
        {
            return _context.HousingRequests
                .Where(r => r.ApplicationUserId == userId).ToList();
        }

        //public async Task<bool> CanPlaceNewRequestAsync(Guid userId)
        //{
        //    var activeRequest = _context.HousingRequests
        //        .Where(r => r.ApplicationUserId == userId)
        //        .OrderByDescending(r => r.HousingStart).FirstOrDefault();

        //    if (activeRequest == null)
        //        return true;

        //    var endDate = activeRequest.HousingStart.AddDays(Math.Round(activeRequest.Duration.TotalDays));
        //    return endDate < DateOnly.FromDateTime(DateTime.Now);
        //}

        //public async Task<bool> PlaceNewRequestAsync(HousingRequest request)
        //{
        //    var canPlace = await CanPlaceNewRequestAsync(request.ApplicationUserId);
        //    if (!canPlace)
        //        return false;

        //    request.Placed = DateTime.Now;
        //    _context.HousingRequests.Add(request);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
    }
}
