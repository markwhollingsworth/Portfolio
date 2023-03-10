using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Interfaces;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController, Route("denomination"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class DenominationController : ControllerBase
    {
        private readonly ILogger<DenominationController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IDenominationRepository _repository;

        public DenominationController(ILogger<DenominationController> logger, IConfiguration configuration, IDenominationRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(_logger, _configuration);
        }

        [HttpGet, Route(""), Route("all")]
        public async Task<IActionResult> GetDenominations()
        {
            return Ok(await _repository.GetDenominations());
        }
    }
}
