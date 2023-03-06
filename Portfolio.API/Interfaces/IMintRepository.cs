using Portfolio.Shared.Models.Collectibles;

namespace Portfolio.API.Interfaces
{
    public interface IMintRepository
    {
        Task<IEnumerable<MintModel>?> GetAllMints();
        void InjectDependencies(ILogger logger, IConfiguration configuration);
    }
}
