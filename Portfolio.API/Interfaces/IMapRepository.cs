using Portfolio.Shared.Models;

namespace Portfolio.API.Interfaces
{
    public interface IMapRepository
    {
        Task<IEnumerable<MapModel>?> GetAllMapsAsync();
        Task<MapModel?> GetMapById(int id);
        void InjectDependencies(ILogger logger, IConfiguration configuration);

    }
}
