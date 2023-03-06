using Portfolio.Shared.Models.OldArizonaRoads;

namespace Portfolio.API.Interfaces
{
    public interface IMapRepository
    {
        Task<IEnumerable<MapModel>?> GetAllMaps();
        Task<MapModel?> GetMapById(int id);
        void InjectDependencies(ILogger logger, IConfiguration configuration);

    }
}
