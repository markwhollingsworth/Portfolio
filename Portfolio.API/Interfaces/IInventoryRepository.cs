using Portfolio.Shared.Models.Collectibles;

namespace Portfolio.API.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryModel>?> GetInventory();
        void InjectDependencies(ILogger logger, IConfiguration configuration);
    }
}
