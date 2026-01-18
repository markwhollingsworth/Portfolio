using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.UI.Configuration;
using Portfolio.UI.Interfaces;
using Portfolio.UI.Models;

namespace Portfolio.UI.DataAccess
{
    public class CurrencyDataAccess : ICurrencyDataAccess
    {
        private DataAccessConfiguration _config;

        public CurrencyDataAccess(ILogger<ICurrencyDataAccess> logger, IConfiguration configuration)
        {
            _config = new(logger, configuration);
        }

        public async Task<IEnumerable<CurrencyModel>?> GetAllCurrencyAsync()
        {
            IEnumerable<CurrencyModel>? currency = null;

            try
            {
                using SqlConnection connection = new(_config.ConnectionString);
                currency = await connection.QueryAsync<CurrencyModel>("dbo.GetAllCurrency", null, null, _config.CommandTimeout, _config.CommandType);
            }
            catch (Exception ex)
            {
                _config.Logger.LogError(ex.Message);
            }

            return currency;
        }

        public async Task<CurrencyModel?> GetCurrencyByIdAsync(long id)
        {
            CurrencyModel? currency = null;

            try
            {
                var parameters = new { Id = id };
                using SqlConnection connection = new(_config.ConnectionString);
                currency = (await connection.QueryAsync<CurrencyModel>("dbo.GetCurrencyById", parameters, null, _config.CommandTimeout, _config.CommandType)).First();
            }
            catch (Exception ex)
            {
                _config.Logger.LogError(ex.Message);
            }

            return currency;
        }
    }
}
