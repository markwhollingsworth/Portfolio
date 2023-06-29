using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Configuration;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Collectibles.Coin;

namespace Portfolio.Shared.DataAccess
{
    /// <summary>
    /// Provides methods for interacting with coin data.
    /// </summary>
    public class CoinDataAccess : ICoinDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        private DataAccessConfiguration _configuration;

        /// <summary>
        /// Constructor used for injecting dependencies.
        /// </summary>
        /// <param name="logger">The logger dependency.</param>
        /// <param name="configuration">The configuration dependency.</param>
        public CoinDataAccess(ILogger<CoinDataAccess> logger, IConfiguration configuration)
        {
            _configuration = new(logger, configuration);
        }

        /// <summary>
        /// Gets a coin by id.
        /// </summary>
        /// <param name="id">The id, of type int, of the coin.</param>
        /// <returns>Returns details about the coin.</returns>
        /// <exception cref="ArgumentException">An invalid ID was passed in.</exception>
        public async Task<CoinModel?> GetByIdAsync(long id)
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetByIdAsync)} with id of {id}");
            CoinModel? coin = null;

            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"{nameof(id)} is invalid.");
                }

                using SqlConnection connection = new(_configuration.ConnectionString);
                var parameters = new { Id = id };
                coin = (await connection.QueryAsync<CoinModel>("dbo.GetCoinById", parameters, null, _configuration.CommandTimeout, _configuration.CommandType)).First();
            }
            catch (ArgumentException ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return coin;
        }

        /// <summary>
        /// Adds a coin to the database.
        /// </summary>
        /// <param name="request">The request containing details about the new coin to add.</param>
        /// <returns>Returns the number of rows affected.</returns>
        public async Task<int> AddCoinAsync(AddCoinRequest request)
        {
            var rowsAffected = 0;

            if (request == null)
            {
                throw new ArgumentNullException("Request can not be null.");
            }
            else
            {
                try
                {
                    using SqlConnection connection = new(_configuration.ConnectionString);
                    var parameters = new
                    {
                        request.Year,
                        request.MintId,
                        request.DenominationId,
                        request.ListPrice,
                        request.Quantity
                    };

                    rowsAffected = await connection.ExecuteAsync("dbo.AddCoin", parameters, null, _configuration.CommandTimeout, _configuration.CommandType);
                }
                catch (Exception ex)
                {
                    _configuration.Logger.LogError(ex.Message);
                }
            }

            return rowsAffected;
        }

        public async Task<int> UpdateCoinAsync(UpdateCoinRequest request)
        {
            var rowsAffected = 0;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                //var parameters = new
                //{
                //    Year = request.Year.ToInt32(),
                //    MintId = request.MintId.ToInt32(),
                //    DenominationId = request.DenominationId.ToInt32(),
                //    ListPrice = 1.99,
                //    Quantity = request.Quantity.ToInt32()
                //};

                rowsAffected = await connection.ExecuteAsync("dbo.UpdateCoin", null, null, _configuration.CommandTimeout, _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return rowsAffected;
        }
    }
}
