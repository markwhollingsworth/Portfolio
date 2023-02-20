using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Newtonsoft.Json;
using Portfolio.API.Extensions;
using Portfolio.Common.Models.OldArizonaRoads;

namespace Portfolio.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController, Route("map")]
    public class MapController : ControllerBase
    {
        readonly ILogger<MapController> _logger;
        readonly string? _mapDataLocation;

        public MapController(ILogger<MapController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _mapDataLocation = configuration.GetMapDataLocation();
        }

        [HttpGet, Route("all")]
        public async Task<IActionResult> GetMaps()
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
                _logger.LogError(ex.Message);
            }

            return Ok(maps);
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetMap(int id)
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
                _logger.LogError(ex.Message);
            }

            return Ok(map);
        }
    }
}
