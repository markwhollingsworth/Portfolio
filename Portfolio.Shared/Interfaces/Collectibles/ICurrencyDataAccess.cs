using Portfolio.Shared.Models;

namespace Portfolio.Shared.Interfaces
{
    public interface ICurrencyDataAccess
    {
        Task<IEnumerable<CurrencyModel>?> GetAllCurrencyAsync();
        Task<CurrencyModel?> GetCurrencyByIdAsync(long id);
    }
}
