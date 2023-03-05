using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Interfaces;

namespace Portfolio.API.Controllers
{
    [ApiController, Route("map"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class MapController : ControllerBase
    {
        private readonly ILogger<MapController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapRepository _repository;

        public MapController(ILogger<MapController> logger, IConfiguration configuration, IMapRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(_logger, _configuration);
        }

        [HttpGet, Route("all")]
        public async Task<IActionResult> GetAllMaps()
        {
            return Ok(await _repository.GetAllMaps());
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetMapById(int id)
        {
            return id <= 0 ? BadRequest(ModelState) : Ok(await _repository.GetMapById(id));
        }
    }
}
