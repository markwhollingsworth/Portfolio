using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Portfolio.API.Interfaces;
using Portfolio.Common.Models.Collectibles;

namespace Portfolio.API.Repository
{
    public class MintRepository : IMintRepository
    {
        private RepositoryConfiguration? _configuration;

        public async Task<IEnumerable<MintModel>?> GetAllMints()
        {
            IEnumerable<MintModel>? mints = null;

            try
            {
                using var connection = new SqlConnection(_configuration?.ConnectionString);
                mints = await connection.QueryAsync<MintModel>("dbo.GetMintMarks", null, null, _configuration?.CommandTimeout, _configuration?.CommandType);
            }
            catch (Exception ex)
            {
                _configuration?.Logger.LogError(ex.Message);
            }

            return mints;
        }

        public void InjectDependencies(ILogger logger, IConfiguration configuration)
        {
            _configuration = new RepositoryConfiguration(logger, configuration);
        }
    }
}
