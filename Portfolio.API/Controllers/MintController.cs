using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Interfaces;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController, Route("v1/mint"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class MintController : ControllerBase
    {
        private readonly ILogger<MintController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMintRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="repository"></param>
        public MintController(ILogger<MintController> logger, IConfiguration configuration, IMintRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(logger, configuration);
        }

        /// <summary>
        /// Gets all mints.
        /// </summary>
        /// <returns>Returns a collection of mints.</returns>
        [HttpGet, Route("mints")]
        public async Task<IActionResult> GetAllMints()
        {
            return Ok(await _repository.GetAllMints());
        }
    }
}
