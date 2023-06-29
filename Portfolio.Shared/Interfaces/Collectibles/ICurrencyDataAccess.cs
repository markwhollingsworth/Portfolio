using Portfolio.Shared.Models;
using Portfolio.Shared.Requests;

namespace Portfolio.Shared.Interfaces
{
    public interface ICurrencyDataAccess
    {
        Task<IEnumerable<CurrencyModel>?> GetAllCurrencyAsync();
        Task<CurrencyModel?> GetCurrencyByIdAsync(long id);
        Task<int> AddCurrencyAsync(AddCurrencyRequest request);
        Task<int> UpdateCurrencyAsync(UpdateCurrencyRequest request);
    }
}
