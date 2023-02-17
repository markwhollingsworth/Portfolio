using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web.Resource;
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
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetValue<int>("CommandTimeout");
        }

        [HttpGet, Route(""), Route("all")]
        public async Task<IEnumerable<MintModel>> GetMints()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<MintModel>("dbo.GetMintMarks", null, null, _commandTimeout, _commandType);
        }
    }
}
