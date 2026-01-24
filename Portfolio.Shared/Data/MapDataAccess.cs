using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Portfolio.UI.Configuration;
using Portfolio.UI.Extensions;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;

namespace Portfolio.UI.DataAccess
{
    public class MapDataAccess : IMapDataAccess
    {
        private readonly DataAccessConfiguration _configuration;
        private readonly string _mapDataLocation;

        public MapDataAccess(ILogger<IMapDataAccess> logger, IConfiguration configuration)
        {
            _configuration = new(logger, configuration);
            _mapDataLocation = configuration.GetMapDataLocation();
        }

        public async Task<IEnumerable<MapModel>?> GetMapsAsync()
        {
            List<MapModel>? maps = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(_mapDataLocation))
                {
                    using StreamReader streamReader = new(_mapDataLocation);
                    var text = await streamReader.ReadToEndAsync();
                    maps = JsonConvert.DeserializeObject<List<MapModel>>(text);
                }
            }
            catch (Exception ex)
            {
                _configuration?.Logger.LogError(ex.Message, ex);
            }

            return maps;
        }

        public async Task<MapModel?> GetMapByIdAsync(int id)
        {
            MapModel? map = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(_mapDataLocation))
                {
                    using StreamReader streamReader = new(_mapDataLocation);
                    var text = await streamReader.ReadToEndAsync();
                    map = JsonConvert.DeserializeObject<List<MapModel>>(text)?.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                _configuration?.Logger.LogError(ex.Message, ex);
            }

            return map;
        }
    }
}
