using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Portfolio.Common.Extensions.Colectibles;
using Portfolio.Common.Models.Collectibles;
using Portfolio.Common.Requests.Collectibles.Coin;
using System.Data;

namespace Collectible.API.Controllers
{
    [ApiController, Route("api/coin")]
    public class CoinController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        public CoinController(ILogger<InventoryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetValue<int>("CommandTimeout");
            var test = "";
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IEnumerable<CoinModel>> GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new { Id = id };
            return await connection.QueryAsync<CoinModel>("dbo.GetCoinById", parameters, null, _commandTimeout, _commandType);
        }

        [HttpPost, Route("add")]
        public async Task<int> AddCoin(AddCoinRequest request)
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

            return await connection.ExecuteAsync("dbo.AddCoin", parameters, null, _commandTimeout, _commandType);
        }

        [HttpPatch, Route("update")]
        public async Task<IActionResult> UpdateCoin(UpdateCoinRequest request)
        {
            throw new NotImplementedException();
            //using var connection = new SqlConnection(_connectionString);
            //var parameters = new
            //{
            //    Year = Convert.ToInt32(request.Year),
            //    MintId = Convert.ToInt32(request.MintId),
            //    DenominationId = Convert.ToInt32(request.DenominationId),
            //    ListPrice = 1.99,
            //    Quantity = Convert.ToInt32(request.Quantity)
            //};

            //return await connection.ExecuteAsync("dbo.UpdateCoin", parameters, null, _commandTimeout, _commandType);
        }
    }
}
