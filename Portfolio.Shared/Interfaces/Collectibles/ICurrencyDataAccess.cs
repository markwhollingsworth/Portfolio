using Portfolio.UI.Models;

namespace Portfolio.UI.Interfaces
{
    public interface ICurrencyDataAccess
    {
        Task<IEnumerable<CurrencyModel>?> GetAllCurrencyAsync();
        Task<CurrencyModel?> GetCurrencyByIdAsync(long id);
    }
}
