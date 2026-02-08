using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Configuration;
using Portfolio.Shared.Enums;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Collectibles;

namespace Portfolio.Shared.DataAccess
{
    /// <summary>
    /// Provides methods for interacting with collectibles
    /// </summary>
    public class CollectibleDataAccess : ICollectibleDataAccess
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
        public CollectibleDataAccess(ILogger<CollectibleDataAccess> logger, IConfiguration configuration)
        {
            _configuration = new(logger, configuration);
        }

        /// <summary>
        /// Gets a collectible
        /// </summary>
        /// <param name="id">The id, of type int, of the collectible</param>
        /// <param name="collectibleType">The type of the collectible</param>
        /// <returns>Returns details about the collectible.</returns>
        public async Task<CollectibleModel?> GetByIdAsync(int id, CollectibleType collectibleType)
        {
            _configuration.Logger.LogInformation($"Calling method {nameof(GetByIdAsync)} with {nameof(id)} of {id}, {nameof(collectibleType)} of {collectibleType}");
            CollectibleModel? collectible = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                var parameters = new { Id = id, CollectibleType = (int)collectibleType };
                collectible = (await connection.QueryAsync<CollectibleModel>("dbo.GetCollectible", parameters, null, _configuration.CommandTimeout, _configuration.CommandType)).First();
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return collectible;
        }

        /// <summary>
        /// Saves a collectible to the database.
        /// </summary>
        /// <param name="request">The request containing details about the collectible to save.</param>
        /// <returns>Returns the number of rows affected.</returns>
        public async Task<int> SaveCollectibleAsync(AddCollectibleRequest request)
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
                       // request.
                        //request.Year,
                        //request.MintId,
                        //request.DenominationId,
                        //request.ListPrice,
                        //request.Quantity
                    };

                    rowsAffected = await connection.ExecuteAsync("dbo.SaveCollectible", parameters, null, _configuration.CommandTimeout, _configuration.CommandType);
                }
                catch (Exception ex)
                {
                    _configuration.Logger.LogError(ex.Message);
                }
            }

            return rowsAffected;
        }

        //public async Task<int> UpdateCoinAsync(UpdateCoinRequest request)
        //{
        //    var rowsAffected = 0;

        //    try
        //    {
        //        using SqlConnection connection = new(_configuration.ConnectionString);
        //        //var parameters = new
        //        //{
        //        //    Year = request.Year.ToInt32(),
        //        //    MintId = request.MintId.ToInt32(),
        //        //    DenominationId = request.DenominationId.ToInt32(),
        //        //    ListPrice = 1.99,
        //        //    Quantity = request.Quantity.ToInt32()
        //        //};

        //        rowsAffected = await connection.ExecuteAsync("dbo.UpdateCoin", null, null, _configuration.CommandTimeout, _configuration.CommandType);
        //    }
        //    catch (Exception ex)
        //    {
        //        _configuration.Logger.LogError(ex.Message);
        //    }

        //    return rowsAffected;
        //}
    }
}
