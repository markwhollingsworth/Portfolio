using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Enums;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Collectibles;

namespace Portfolio.UI.Services
{
    public interface IPortfolioService
    {
        Task<int> AddCollectibleAsync(AddCollectibleRequest request);
        Task<MarkupString> ConvertDocumentToHtmlAsync(string key);
        Task<CollectibleModel?> GetCollectibleByIdAsync(Guid id, CollectibleType collectibleType);
        Task<IEnumerable<DenominationModel>?> GetDenominationsAsync();
        IEnumerable<MapModel>? GetFilteredMaps(IEnumerable<MapModel>? maps, string? searchText);
        Task<IEnumerable<InventoryModel>?> GetInventoryAsync();
        Task<MapModel?> GetMapByIdAsync(Guid id);
        Task<IEnumerable<MapModel>?> GetMapsAsync();
        Task<IEnumerable<MintModel>?> GetMintsAsync();
    }
}
