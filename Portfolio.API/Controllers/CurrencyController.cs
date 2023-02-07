using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Portfolio.Common.Requests.Collectibles.Currency;
using System.Data;

namespace Collectible.API.Controllers
{
    [ApiController, Route("api/currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        public CurrencyController(ILogger<CurrencyController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetValue<int>("CommandTimeout");
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetCurrency()
        {
            return null;
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            return null;
        }

        [HttpPost, Route("add")]
        public async Task<int> AddCurrency(AddCurrencyRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            object parameters = null;

            return await connection.ExecuteAsync("dbo.AddCurrency", parameters, null, _commandTimeout, _commandType);
        }

        [HttpPatch, Route("update")]
        public async Task<IActionResult> UpdateCurrency(UpdateCurrencyRequest request)
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

            //return await connection.ExecuteAsync("dbo.UpdateCurrency", parameters, null, _commandTimeout, _commandType);
        }
    }
}
