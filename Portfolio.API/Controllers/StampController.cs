using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Extensions;
using Portfolio.Common.Requests.Collectibles.Stamp;
using System.Data;

namespace Collectible.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController, Route("stamp")]
    public class StampController : ControllerBase
    {
        private readonly ILogger<StampController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        public StampController(ILogger<StampController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetDefaultConnectionString();
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetCommandTimeout();
        }

        [HttpPost, Route("add")]
        public async Task<int> AddStamp(AddStampRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateStamp(UpdateStampRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
