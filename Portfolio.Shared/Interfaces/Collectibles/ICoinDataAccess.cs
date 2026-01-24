using Portfolio.Shared.Models.Collectibles;
using Portfolio.UI.Models;
using Portfolio.UI.Requests.Collectibles;

namespace Portfolio.UI.Interfaces
{
    public interface ICoinDataAccess
    {
        Task<CoinModel?> GetCoinByIdAsync(int id);
        Task<IEnumerable<InventoryModel>?> GetCoinsAsync();
        Task<IEnumerable<DenominationModel>?> GetDenominationsAsync();
        Task<IEnumerable<GradingCompanyModel>?> GetGradingCompaniesAsync();
        Task<MintModel?> GetMintByIdAsync(int id);
        Task<IEnumerable<MintModel>?> GetMintsAsync();
        Task<PurchaseDetailModel?> GetPurchaseDetailByIdAsync(int id);
        Task<int> SaveCoinAsync(SaveCoinRequest request);
    }
}
