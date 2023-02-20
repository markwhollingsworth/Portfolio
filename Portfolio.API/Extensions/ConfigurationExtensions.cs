using Microsoft.Extensions.Configuration;
using System.Data;

namespace Portfolio.API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string? GetDefaultConnectionString(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            return connectionString;
        }

        public static int GetCommandTimeout(this IConfiguration configuration)
        {
            var commandTimeout = configuration.GetValue<int>("CommandTimeout");
            return commandTimeout;
        }

        public static string? GetMapDataLocation(this IConfiguration configuration)
        {
            var location = configuration.GetValue<string>("MapDataLocation");
            return location;
        }
    }
}
