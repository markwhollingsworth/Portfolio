using Portfolio.Common.Models.Collectibles;
using Portfolio.Common.Requests.Collectibles.Currency;

namespace Portfolio.API.Interfaces
{
    public interface ICurrencyRepository
    {
        void InjectDependencies(ILogger logger, IConfiguration configuration);
        Task<IEnumerable<CurrencyModel>?> GetAllCurrency();
        Task<CurrencyModel?> GetCurrencyById(int id);
        Task<int> AddCurrency(AddCurrencyRequest request);
        Task<int> UpdateCurrency(UpdateCurrencyRequest request);
    }
}
