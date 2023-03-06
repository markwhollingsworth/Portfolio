using Portfolio.Shared.Models.Collectibles;
using Portfolio.Shared.Requests.Collectibles.Coin;

namespace Portfolio.API.Interfaces
{
    public interface ICoinRepository
    {
        void InjectDependencies(ILogger logger, IConfiguration configuration);
        Task<CoinModel> GetById(int id);
        Task<int> AddCoin(AddCoinRequest request);
        Task<int> UpdateCoin(UpdateCoinRequest request);
    }
}
