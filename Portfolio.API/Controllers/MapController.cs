using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Interfaces;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController, Route("v1/map"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class MapController : ControllerBase
    {
        private readonly ILogger<MapController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="repository"></param>
        public MapController(ILogger<MapController> logger, IConfiguration configuration, IMapRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(_logger, _configuration);
        }

        /// <summary>
        /// Gets all maps.
        /// </summary>
        /// <returns>Returns a collection of maps.</returns>
        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAllMapsAsync()
        {
            return Ok(await _repository.GetAllMapsAsync());
        }

        /// <summary>
        /// Gets a map by id.
        /// </summary>
        /// <param name="id">The id of the map.</param>
        /// <returns>If found, returns a map; else, returns nothing.</returns>
        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetMapByIdAsync(int id)
        {
            return id <= 0 ? BadRequest(ModelState) : Ok(await _repository.GetMapById(id));
        }
    }
}
