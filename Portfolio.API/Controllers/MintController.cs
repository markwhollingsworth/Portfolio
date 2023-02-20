using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Extensions;
using Portfolio.Common.Models.Collectibles;
using System.Data;

namespace Collectible.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController, Route("mint")]
    public class MintController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        public MintController(ILogger<InventoryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetDefaultConnectionString();
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetCommandTimeout();
        }

        [HttpGet, Route("mints")]
        public async Task<IActionResult> GetMints()
        {
            IEnumerable<MintModel>? mints = null;

            try
            {
                using var connection = new SqlConnection(_connectionString);
                mints = await connection.QueryAsync<MintModel>("dbo.GetMintMarks", null, null, _commandTimeout, _commandType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok(mints);
        }
    }
}
