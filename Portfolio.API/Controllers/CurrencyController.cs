using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Extensions;
using Portfolio.Common.Requests.Collectibles.Currency;
using System.Data;

namespace Collectible.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController, Route("currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        public CurrencyController(ILogger<CurrencyController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetDefaultConnectionString();
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetCommandTimeout();
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetCurrency()
        {
            throw new NotImplementedException();
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("add")]
        public async Task<int> AddCurrency(AddCurrencyRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateCurrency(UpdateCurrencyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
