using Portfolio.Shared.Models.Collectibles;
using Portfolio.Shared.Requests.Collectibles.Coin;

namespace Portfolio.UI.Services
{
    public interface IPortfolioService
    {
        Task AddCoin(AddCoinRequest request);
        Task<CoinModel?> GetById(int id);
        Task<IEnumerable<DenominationModel>?> GetDenominationsAsync();
        Task<IEnumerable<InventoryModel>?> GetInventoryAsync();
        Task<IEnumerable<MintModel>?> GetMintsAsync();
        Task UpdateCoin(UpdateCoinRequest request);
    }
}
