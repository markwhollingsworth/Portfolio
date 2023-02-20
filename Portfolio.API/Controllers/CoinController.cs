using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Extensions;
using Portfolio.Common.Extensions.Colectibles;
using Portfolio.Common.Models.Collectibles;
using Portfolio.Common.Requests.Collectibles.Coin;
using System.Data;

namespace Collectible.API.Controllers
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes"), ApiController, Route("coin")]
    public class CoinController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        public CoinController(ILogger<InventoryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetDefaultConnectionString();
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetCommandTimeout();
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            CoinModel? coin = null;

            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"{nameof(id)} is invalid.");
                }

                using var connection = new SqlConnection(_connectionString);
                var parameters = new { Id = id };
                coin = (await connection.QueryAsync<CoinModel>("dbo.GetCoinById", parameters, null, _commandTimeout, _commandType)).First();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok(coin);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> AddCoin(AddCoinRequest request)
        {
            var rowsAffected = 0;

            try
            {
                using var connection = new SqlConnection(_connectionString);
                var parameters = new
                {
                    Year = request.Year.ToInt32(),
                    MintId = request.MintId.ToInt32(),
                    DenominationId = request.DenominationId.ToInt32(),
                    ListPrice = 1.99,
                    Quantity = request.Quantity.ToInt32()
                };

                rowsAffected = await connection.ExecuteAsync("dbo.AddCoin", parameters, null, _commandTimeout, _commandType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok(rowsAffected);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateCoin(UpdateCoinRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
