using Portfolio.Shared.Models;

namespace Portfolio.Shared.Interfaces
{
    public interface IDenominationDataAccess
    {
        Task<IEnumerable<DenominationModel>?> GetDenominationsAsync();
    }
}
