using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web.Resource;
using Portfolio.API.Controllers;
using Portfolio.API.Extensions;
using Portfolio.API.Interfaces;
using Portfolio.Common.Models.Collectibles;
using System.Data;

namespace Collectible.API.Controllers
{
    [ApiController, Route("mint"), RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class MintController : ControllerBase
    {
        private readonly ILogger<MintController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMintRepository _repository;

        public MintController(ILogger<MintController> logger, IConfiguration configuration, IMintRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _repository.InjectDependencies(logger, configuration);
        }

        [HttpGet, Route("mints")]
        public async Task<IActionResult> GetAllMints()
        {
            return Ok(await _repository.GetAllMints());
        }
    }
}
