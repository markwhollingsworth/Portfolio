using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Configuration;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Models;
using Portfolio.Shared.Requests.Queries;
using System.Text.RegularExpressions;

namespace Portfolio.Shared.DataAccess
{
    public class InventoryDataAccess : IInventoryDataAccess
    {
        private DataAccessConfiguration _configuration;

        public InventoryDataAccess(ILogger<IInventoryDataAccess> logger, IConfiguration configuration)
        {
            _configuration = new(logger, configuration);
        }

        public async Task<PaginatedResult<InventoryModel>> GetInventoryAsync(GetInventoryQuery query)
        {
            PaginatedResult<InventoryModel> result = new();
            try
            {
                using SqlConnection connection = new(_configuration.ConnectionString);

                // Sanitize and validate search term
                var sanitizedSearchTerm = SanitizeSearchTerm(query?.SearchTerm ?? string.Empty);

                var parameters = new
                {
                    PageNumber = query?.PageNumber ?? 1,
                    PageSize = query?.PageSize ?? 9,
                    Denomination = (int)(query?.Denomination ?? Enums.CoinDenomination.All),
                    SearchTerm = sanitizedSearchTerm
                };

                using var multi = await connection.QueryMultipleAsync(
                    "dbo.GetInventory", 
                    parameters, 
                    commandTimeout: _configuration.CommandTimeout, 
                    commandType: _configuration.CommandType);

                var totalRecords = await multi.ReadSingleAsync<int>();
                var items = await multi.ReadAsync<InventoryModel>();

                result = new PaginatedResult<InventoryModel>
                {
                    Data = items,
                    PageNumber = query?.PageNumber ?? 1,
                    PageSize = query?.PageSize ?? 9,
                    TotalRecords = totalRecords
                };
            }
            catch (Exception ex)
            {
                _configuration.Logger.LogError(ex, "Error retrieving paginated inventory");
            }

            return result;
        }

        private string SanitizeSearchTerm(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return string.Empty;

            // Limit length
            if (searchTerm.Length > 150)
                searchTerm = searchTerm.Substring(0, 150);

            // Escape LIKE wildcards if you want literal matching
            searchTerm = searchTerm
                .Replace("[", "[[]")  // Escape brackets first
                .Replace("%", "[%]")
                .Replace("_", "[_]");

            // Remove potentially dangerous characters
            searchTerm = Regex.Replace(searchTerm, @"[^\w\s-]", "");

            return searchTerm.Trim();
        }
    }
}
