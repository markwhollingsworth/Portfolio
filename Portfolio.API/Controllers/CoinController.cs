using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Interfaces;
using Portfolio.Common.Requests.Collectibles.Coin;

namespace Collectible.API.Controllers
{
    [ApiController, Route("coin"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CoinController : ControllerBase
    {
        private readonly ILogger<CoinController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICoinRepository _repository;

        public CoinController(ILogger<CoinController> logger, IConfiguration configuration, ICoinRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(_logger, _configuration);
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return id <= 0 ? BadRequest(ModelState) : Ok(await _repository.GetById(id));
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> AddCoin(AddCoinRequest request)
        {
            return request == null ? BadRequest(ModelState) : Ok(await _repository.AddCoin(request));
        }

        [HttpPut, Route("update")] // TODO: Not fully implemented or tested.
        public async Task<IActionResult> UpdateCoin(UpdateCoinRequest request)
        {
            return request == null ? BadRequest(ModelState) : Ok(await _repository.UpdateCoin(request));
        }
    }
}