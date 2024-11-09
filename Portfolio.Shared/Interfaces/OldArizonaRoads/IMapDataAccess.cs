using Portfolio.Shared.Models;

namespace Portfolio.Shared.Interfaces
{
    public interface IMapDataAccess
    {
        Task<IEnumerable<MapModel>?> GetMapsAsync();
        Task<MapModel?> GetMapByIdAsync(Guid id);
    }
}
