using Portfolio.Shared.Models;

namespace Portfolio.Shared.Interfaces
{
    public interface IInventoryDataAccess
    {
        Task<IEnumerable<InventoryModel>?> GetInventoryAsync();
    }
}
