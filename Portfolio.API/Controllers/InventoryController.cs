using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Portfolio.Common.Models.Collectibles;
using System.Data;

namespace Collectible.API.Controllers
{
    [ApiController, Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        public InventoryController(ILogger<InventoryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetValue<int>("CommandTimeout");
        }

        [HttpGet, Route("")]
        public async Task<IEnumerable<InventoryModel>> GetInventory()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<InventoryModel>("dbo.GetInventory", null, null, _commandTimeout, _commandType);
        }
    }
}
