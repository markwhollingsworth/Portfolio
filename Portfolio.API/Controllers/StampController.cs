using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web.Resource;
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
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetValue<int>("CommandTimeout");
        }

        [HttpPost, Route("add")]
        public async Task<int> AddStamp(AddStampRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            object parameters = null;

            return await connection.ExecuteAsync("dbo.AddStamp", parameters, null, _commandTimeout, _commandType);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateStamp(UpdateStampRequest request)
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
