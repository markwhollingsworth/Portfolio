using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Interfaces;

namespace Portfolio.API.Controllers
{
    [ApiController, Route("inventory"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IInventoryRepository _repository;

        public InventoryController(ILogger<InventoryController> logger, IConfiguration configuration, IInventoryRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(logger, configuration);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetInventory()
        {
            return Ok(await _repository.GetInventory());
        }
    }
}
