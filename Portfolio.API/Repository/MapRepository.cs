using Newtonsoft.Json;
using Portfolio.API.Extensions;
using Portfolio.API.Interfaces;
using Portfolio.Common.Models.OldArizonaRoads;

namespace Portfolio.API.Repository
{
    public class MapRepository : IMapRepository
    {
        private RepositoryConfiguration? _configuration;
        private string? _mapDataLocation;

        public async Task<IEnumerable<MapModel>?> GetAllMaps()
        {
            List<MapModel>? maps = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(_mapDataLocation))
                {
                    using var streamReader = new StreamReader(_mapDataLocation);
                    var text = await streamReader.ReadToEndAsync();
                    maps = JsonConvert.DeserializeObject<List<MapModel>>(text);
                }
            }
            catch (Exception ex)
            {
                _configuration?.Logger.LogError(ex.Message);
            }

            return maps;
        }

        public async Task<MapModel?> GetMapById(int id)
        {
            MapModel? map = null;

            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"{nameof(id)} is invalid");
                }

                if (!string.IsNullOrWhiteSpace(_mapDataLocation))
                {
                    using var streamReader = new StreamReader(_mapDataLocation);
                    var text = await streamReader.ReadToEndAsync();
                    map = JsonConvert.DeserializeObject<List<MapModel>>(text)?.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                _configuration?.Logger.LogError(ex.Message);
            }

            return map;
        }

        public void InjectDependencies(ILogger logger, IConfiguration configuration)
        {
            _configuration = new RepositoryConfiguration(logger, configuration);
            _mapDataLocation = configuration.GetMapDataLocation();
        }
    }
}
