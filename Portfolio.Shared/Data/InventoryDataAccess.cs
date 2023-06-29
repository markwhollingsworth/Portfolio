using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Configuration;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.DataAccess
{
    public class InventoryDataAccess : IInventoryDataAccess
    {
        private DataAccessConfiguration _configuration;

        public InventoryDataAccess(ILogger<IInventoryDataAccess> logger, IConfiguration configuration)
        {
            _configuration = new(logger, configuration);
        }

        public async Task<IEnumerable<InventoryModel>?> GetInventoryAsync()
        {
            IEnumerable<InventoryModel>? result = null;
            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);
                result = await connection.QueryAsync<InventoryModel>("dbo.GetInventory", null, null, _configuration.CommandTimeout, _configuration.CommandType);
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex.Message);
            }

            return result;
        }
    }
}
