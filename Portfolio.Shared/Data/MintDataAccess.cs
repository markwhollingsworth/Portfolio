using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Configuration;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.DataAccess
{
    public class MintDataAccess : IMintDataAccess
    {
        private DataAccessConfiguration _configuration;

        public MintDataAccess(ILogger<IMintDataAccess> logger, IConfiguration configuration)
        {
            _configuration = new(logger, configuration);
        }

        public async Task<IEnumerable<MintModel>?> GetMintsAsync()
        {
            IEnumerable<MintModel>? mints = null;

            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                mints = await connection.QueryAsync<MintModel>("dbo.GetMintMarks", null, null, _configuration.CommandTimeout, _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return mints;
        }
    }
}
