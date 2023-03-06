using Dapper;
using Microsoft.Data.SqlClient;
using Portfolio.API.Interfaces;
using Portfolio.Shared.Extensions.Colectibles;
using Portfolio.Shared.Models.Collectibles;
using Portfolio.Shared.Requests.Collectibles.Coin;

namespace Portfolio.API.Repository
{
    public class CoinRepository : ICoinRepository
    {
        private RepositoryConfiguration _configuration;

        public async Task<CoinModel> GetById(int id)
        {
            var coin = new CoinModel();

            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"{nameof(id)} is invalid.");
                }

                using var connection = new SqlConnection(_configuration.ConnectionString);
                var parameters = new { Id = id };
                coin = (await connection.QueryAsync<CoinModel>("dbo.GetCoinById", parameters, null, _configuration.CommandTimeout, _configuration.CommandType)).First();
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return coin;
        }

        public async Task<int> AddCoin(AddCoinRequest request)
        {
            var rowsAffected = 0;

            try
            {
                using var connection = new SqlConnection(_configuration.ConnectionString);
                var parameters = new
                {
                    Year = request.Year.ToInt32(),
                    MintId = request.MintId.ToInt32(),
                    DenominationId = request.DenominationId.ToInt32(),
                    ListPrice = 1.99,
                    Quantity = request.Quantity.ToInt32()
                };

                rowsAffected = await connection.ExecuteAsync("dbo.AddCoin", parameters, null, _configuration.CommandTimeout, _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return rowsAffected;
        }

        public async Task<int> UpdateCoin(UpdateCoinRequest request)
        {
            var rowsAffected = 0;

            try
            {
                using var connection = new SqlConnection(_configuration.ConnectionString);
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

        public void InjectDependencies(ILogger logger, IConfiguration configuration)
        {
            _configuration = new RepositoryConfiguration(logger, configuration);
        }
    }
}
