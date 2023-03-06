using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Interfaces;
using Portfolio.Shared.Requests.Collectibles.Currency;

namespace Collectible.API.Controllers
{
    [ApiController, Route("currency"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICurrencyRepository _repository;

        public CurrencyController(ILogger<CurrencyController> logger, IConfiguration configuration, ICurrencyRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(_logger, _configuration);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetAllCurrency()
        {
            return Ok(await _repository.GetAllCurrency());
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            return id <= 0 ? BadRequest(ModelState) : Ok(await _repository.GetCurrencyById(id));
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> AddCurrency(AddCurrencyRequest request)
        {
            return request == null ? BadRequest(ModelState) : Ok(await _repository.AddCurrency(request));
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateCurrency(UpdateCurrencyRequest request)
        {
            return request == null ? BadRequest(ModelState) : Ok(await _repository.UpdateCurrency(request));
        }
    }
}