using Dapper;
using Microsoft.Data.SqlClient;
using Portfolio.API.Interfaces;
using Portfolio.Shared.Models.Collectibles;

namespace Portfolio.API.Repository
{
    public class DenominationRepository : IDenominationRepository
    {
        private RepositoryConfiguration? _configuration;

        public async Task<IEnumerable<DenominationModel>?> GetDenominations()
        {
            IEnumerable<DenominationModel>? denominations = null;

            try
            {
                using var connection = new SqlConnection(_configuration?.ConnectionString);
                denominations = (await connection.QueryAsync<DenominationModel>("dbo.GetDenominations", null, null, _configuration?.CommandTimeout, _configuration?.CommandType));
            }
            catch (Exception ex)
            {
                _configuration?.Logger.Log(LogLevel.Error, ex.Message);
            }

            return denominations;
        }

        public void InjectDependencies(ILogger logger, IConfiguration configuration)
        {
            _configuration = new RepositoryConfiguration(logger, configuration);
        }
    }
}