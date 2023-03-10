using Portfolio.Shared.Models;

namespace Portfolio.API.Interfaces
{
    public interface IDenominationRepository
    {
        Task<IEnumerable<DenominationModel>?> GetDenominations();
        void InjectDependencies(ILogger logger, IConfiguration configuration);
    }
}
