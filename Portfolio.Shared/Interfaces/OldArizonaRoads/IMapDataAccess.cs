using Portfolio.UI.Models;

namespace Portfolio.UI.Interfaces
{
    public interface IMapDataAccess
    {
        Task<IEnumerable<MapModel>?> GetMapsAsync();
        Task<MapModel?> GetMapByIdAsync(int id);
    }
}
