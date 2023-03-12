using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests;

namespace Portfolio.UI.Services
{
    public interface IPortfolioService
    {
        Task AddCoinAsync(AddCoinRequest request);
        Task<MarkupString> ConvertDocumentToHtmlAsync(string key);
        Task<CoinModel?> GetCoinByIdAsync(int id);
        Task<IEnumerable<DenominationModel>?> GetDenominationsAsync();
        IEnumerable<MapModel>? GetFilteredMaps(IEnumerable<MapModel>? maps, string? searchText);
        Task<IEnumerable<InventoryModel>> GetInventoryAsync();
        Task<MapModel?> GetMapAsync(int id);
        Task<IEnumerable<MapModel>> GetMapsAsync();
        Task<IEnumerable<MintModel>?> GetMintsAsync();
        Task UpdateCoinAsync(UpdateCoinRequest request);
    }
}
