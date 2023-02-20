using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Extensions;
using Portfolio.Common.Models.Collectibles;
using System.Data;

namespace Collectible.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController, Route("inventory")]
    public class InventoryController : ControllerBase
    {
        readonly ILogger<InventoryController> _logger;
        readonly string? _connectionString;
        readonly CommandType _commandType;
        readonly int _commandTimeout;

        public InventoryController(ILogger<InventoryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetDefaultConnectionString();
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetCommandTimeout();
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetInventory()
        {
            IEnumerable<InventoryModel>? result = null;
            try
            {
                using var connection = new SqlConnection(_connectionString);
                result = await connection.QueryAsync<InventoryModel>("dbo.GetInventory", null, null, _commandTimeout, _commandType);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Ok(result);
        }
    }
}
