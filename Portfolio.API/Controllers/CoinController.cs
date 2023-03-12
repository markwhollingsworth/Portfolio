using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Interfaces;
using Portfolio.Shared.Requests;

namespace Portfolio.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController, Route("v1/coin"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CoinController : ControllerBase
    {
        private readonly ILogger<CoinController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICoinRepository _repository;

        public CoinController(ILogger<CoinController> logger, IConfiguration configuration, ICoinRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(_logger, _configuration);
        }

        /// <summary>
        /// Gets a specific coin based off an id.
        /// </summary>
        /// <param name="id">The id of the coin.</param>
        /// <returns>Returns the details of a coin, if found.</returns>
        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return id <= 0 ? BadRequest(ModelState) : Ok(await _repository.GetById(id));
        }

        /// <summary>
        /// Adds a new coin to the database.
        /// </summary>
        /// <param name="request">The request containing details about the new coin.</param>
        /// <returns>Returns an integer value indicating the number of rows affected."/></returns>

        [HttpPost, Route("add")]
        public async Task<IActionResult> AddCoin(AddCoinRequest request)
        {
            return request == null ? BadRequest(ModelState) : Ok(await _repository.AddCoin(request));
        }

        /// <summary>
        /// Updates an existing coin in the database.
        /// </summary>
        /// <param name="request">The request containing details about the coin to update.</param>
        /// <returns>Returns an integer value indicating the number of rows affected.</returns>
        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateCoin(UpdateCoinRequest request)
        {
            return request == null ? BadRequest(ModelState) : Ok(await _repository.UpdateCoin(request));
        }
    }
}