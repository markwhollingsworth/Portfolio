using Dapper;
using Microsoft.Data.SqlClient;
using Portfolio.API.Interfaces;
using Portfolio.Common.Models.Collectibles;
using Portfolio.Common.Requests.Collectibles.Currency;

namespace Portfolio.API.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private RepositoryConfiguration _config;

        public async Task<int> AddCurrency(AddCurrencyRequest request)
        {
            var result = 0;

            try
            {
                using var connection = new SqlConnection(_config.ConnectionString);
                result = await connection.ExecuteAsync("dbo.AddCurrency", null, null, _config.CommandTimeout, _config.CommandType);
            }
            catch (Exception ex)
            {
                _config.Logger.LogError(ex.Message);
            }

            return result;
        }

        public async Task<IEnumerable<CurrencyModel>?> GetAllCurrency()
        {
            IEnumerable<CurrencyModel>? currency = null;

            try
            {
                using var connection = new SqlConnection(_config.ConnectionString);
                currency = (await connection.QueryAsync<CurrencyModel>("dbo.GetAllCurrency", null, null, _config.CommandTimeout, _config.CommandType));
            }
            catch (Exception ex)
            {
                _config.Logger.LogError(ex.Message);
            }

            return currency;
        }

        public async Task<CurrencyModel?> GetCurrencyById(int id)
        {
            CurrencyModel? currency = null;

            try
            {
                var parameters = new { Id = id };
                using var connection = new SqlConnection(_config.ConnectionString);
                currency = (await connection.QueryAsync<CurrencyModel>("dbo.GetCurrencyById", parameters, null, _config.CommandTimeout, _config.CommandType)).First();
            }
            catch (Exception ex)
            {
                _config.Logger.LogError(ex.Message);
            }

            return currency;
        }

        public void InjectDependencies(ILogger logger, IConfiguration configuration)
        {
            _config = new RepositoryConfiguration(logger, configuration);
        }

        public async Task<int> UpdateCurrency(UpdateCurrencyRequest request)
        {
            var result = 0;

            try
            {
                using var connection = new SqlConnection(_config.ConnectionString);
                result = await connection.ExecuteAsync("dbo.UpdateCurrency", null, null, _config.CommandTimeout, _config.CommandType);
            }
            catch (Exception ex)
            {
                _config.Logger.LogError(ex.Message);
            }

            return result;
        }
    }
}
