using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Models.Collectibles;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Collectibles;

namespace Portfolio.UI.Services
{
    public interface IPortfolioService
    {
        Task<MarkupString> ConvertDocumentToHtmlAsync(string key);
        Task<CoinModel?> GetCoinByIdAsync(int id);
        Task<IEnumerable<InventoryModel>?> GetCoinsAsync();
        Task<IEnumerable<DenominationModel>?> GetDenominationsAsync();
        IEnumerable<MapModel>? GetFilteredMaps(IEnumerable<MapModel>? maps, string? searchText);
        Task<IEnumerable<GradingCompanyModel>?> GetGradingCompaniesAsync();
        Task<MapModel?> GetMapByIdAsync(int id);
        Task<IEnumerable<MapModel>?> GetMapsAsync();
        Task<MintModel?> GetMintByIdAsync(int id);
        Task<IEnumerable<MintModel>?> GetMintsAsync();
        Task<PurchaseDetailModel?> GetPurchaseDetailByIdAsync(int id);
        Task<int> SaveCoinAsync(SaveCoinRequest request);
    }
}
