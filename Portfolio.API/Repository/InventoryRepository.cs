using Dapper;
using Microsoft.Data.SqlClient;
using Portfolio.API.Interfaces;
using Portfolio.Shared.Models;

namespace Portfolio.API.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private RepositoryConfiguration? _configuration;

        public async Task<IEnumerable<InventoryModel>?> GetInventory()
        {
            IEnumerable<InventoryModel>? result = null;
            try
            {
                using var connection = new SqlConnection(_configuration?.ConnectionString);
                result = await connection.QueryAsync<InventoryModel>("dbo.GetInventory", null, null, _configuration?.CommandTimeout, _configuration?.CommandType);
            }
            catch (Exception ex)
            {
                _configuration?.Logger.LogError(ex.Message);
            }

            return result;
        }

        public void InjectDependencies(ILogger logger, IConfiguration configuration)
        {
            _configuration = new RepositoryConfiguration(logger, configuration);
        }
    }
}
