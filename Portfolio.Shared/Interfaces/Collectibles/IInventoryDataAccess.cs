using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;

namespace Portfolio.Shared.Interfaces
{
    public interface IInventoryDataAccess
    {
        Task<PaginatedResult<InventoryModel>> GetInventoryAsync(GetInventoryQuery query);
    }
}
