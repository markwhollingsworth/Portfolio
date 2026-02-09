using Dapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web.Resource;
using Portfolio.Common.Models.Collectibles;
using Portfolio.Common.Models.Pagination;
using Portfolio.Shared.Repository;
using Portfolio.Shared.Requests.Queries;
using System.Data;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// The Inventory controller provides endpoints for interacting with maps.
    /// </summary>
    [ApiController, 
     Route($"{Strings.V1Lowercase}/{Strings.InventoryLowercase}"), 
     RequiredScope(RequiredScopesConfigurationKey = Strings.AzureAdScopes)]
    public class InventoryController : ControllerBase
    {
        /// <summary>
        /// Field for storing the injected mediator dependency.
        /// </summary>
        private readonly ISender _mediator;
        private readonly ILogger<InventoryController> _logger;
        private readonly string? _connectionString;
        private readonly CommandType _commandType;
        private readonly int _commandTimeout;

        /// <summary>
        /// Constructor used to inject our mediator dependency.
        /// </summary>
        /// <param name="mediator">The required mediator dependency used for the mediator behavioral design pattern.</param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public InventoryController(ISender mediator, ILogger<InventoryController> logger, IConfiguration configuration)
        {
            _mediator = mediator;
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _commandType = CommandType.StoredProcedure;
            _commandTimeout = configuration.GetValue<int>("CommandTimeout");
        }

        ///// <summary>
        ///// Gets all coin inventory.
        ///// </summary>
        ///// <returns>Returns a collection of coin inventory.</returns>
        //[HttpGet, Route(Strings.EmptyString)]
        //public async Task<IActionResult> GetInventoryAsync()
        //{
        //    return Ok(await _mediator.Send(new GetInventoryQuery()));
        //}

        [HttpGet, Route("")]
        public async Task<ActionResult<PaginatedResult<InventoryModel>>> GetInventory(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 9)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                
                var parameters = new
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                using var multi = await connection.QueryMultipleAsync(
                    "dbo.GetInventory", 
                    parameters, 
                    commandTimeout: _commandTimeout, 
                    commandType: _commandType);

                var totalRecords = await multi.ReadSingleAsync<int>();
                var items = await multi.ReadAsync<InventoryModel>();

                var result = new PaginatedResult<InventoryModel>
                {
                    Data = items,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalRecords
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving paginated inventory");
                return StatusCode(500, "An error occurred while retrieving inventory");
            }
        }
    }
}