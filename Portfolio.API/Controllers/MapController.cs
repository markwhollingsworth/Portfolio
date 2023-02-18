using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Newtonsoft.Json;
using Portfolio.Common.Models.OldArizonaRoads;
using System.Data;

namespace Portfolio.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController, Route("map")]
    public class MapController : ControllerBase
    {
        readonly ILogger<MapController> _logger;
        readonly string? _connectionString;
        readonly CommandType _commandType;
        readonly int _commandTimeout;
        readonly IConfiguration _configuration;

        public MapController(ILogger<MapController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetValue<int>("CommandTimeout");
            _configuration = configuration;
        }

        [HttpGet, Route("all")]
        public async Task<IActionResult> GetMaps()
        {
            List<MapModel>? maps = null;
            var location = _configuration?.GetValue<string>("MapsDataLocation");

            if (!string.IsNullOrWhiteSpace(location))
            {
                using (var streamReader = new StreamReader(location))
                {
                    var text = await streamReader.ReadToEndAsync();
                    maps = JsonConvert.DeserializeObject<List<MapModel>>(text);
                }
            }

            return Ok(maps);
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetMap(int id)
        {
            MapModel? map = null;
            var location = _configuration?.GetValue<string>("MapsDataLocation");

            if (!string.IsNullOrWhiteSpace(location))
            {
                using var streamReader = new StreamReader(location);
                var text = await streamReader.ReadToEndAsync();
                map = JsonConvert.DeserializeObject<List<MapModel>>(text)?.FirstOrDefault(x => x.Id == id);
            }

            return Ok(map);
        }
    }
}
