using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web.Resource;
using Portfolio.Common.Models.Collectibles;
using System.Data;

namespace Collectible.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController, Route("denomination")]
    public class DenominationController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        public DenominationController(ILogger<InventoryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetValue<int>("CommandTimeout");
        }

        [HttpGet, Route(""), Route("all")]
        public async Task<IEnumerable<DenominationModel>> GetDenominations()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<DenominationModel>("dbo.GetDenominations", null, null, _commandTimeout, _commandType);
        }
    }
}
