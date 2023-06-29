using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Collectibles.Coin;

namespace Portfolio.Shared.Interfaces
{
    public interface ICoinDataAccess
    {
        Task<CoinModel?> GetByIdAsync(long id);
        Task<int> AddCoinAsync(AddCoinRequest request);
        Task<int> UpdateCoinAsync(UpdateCoinRequest request);
    }
}
