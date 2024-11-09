using Portfolio.Shared.Enums;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Collectibles;

namespace Portfolio.Shared.Interfaces
{
    public interface ICollectibleDataAccess
    {
        Task<CollectibleModel?> GetByIdAsync(Guid id, CollectibleType collectibleType);
        Task<int> SaveCollectibleAsync(AddCollectibleRequest request);
    }
}
