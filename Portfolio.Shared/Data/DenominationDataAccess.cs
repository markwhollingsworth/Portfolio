using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Configuration;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.DataAccess
{
    public class DenominationDataAccess : IDenominationDataAccess
    {
        private DataAccessConfiguration _configuration;

        public DenominationDataAccess(ILogger<IDenominationDataAccess> logger, IConfiguration configuration)
        {
            _configuration = new(logger, configuration);
        }

        public async Task<IEnumerable<DenominationModel>?> GetDenominationsAsync()
        {
            IEnumerable<DenominationModel>? denominations = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                denominations = (await connection.QueryAsync<DenominationModel>("dbo.GetDenominations", null, null, _configuration.CommandTimeout, _configuration.CommandType));
            }
            catch (Exception ex)
            {
                _configuration.Logger.Log(LogLevel.Error, ex.Message);
            }

            return denominations;
        }
    }
}