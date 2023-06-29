using Portfolio.Shared.Models;

namespace Portfolio.Shared.Interfaces
{
    public interface IMintDataAccess
    {
        Task<IEnumerable<MintModel>?> GetMintsAsync();
    }
}
