using Collectible.API.Controllers;
using Portfolio.API.Extensions;
using System.Data;

namespace Portfolio.API
{
    public class RepositoryConfiguration
    {
        public readonly ILogger Logger;
        public readonly string? ConnectionString;
        public readonly CommandType CommandType;
        public readonly int CommandTimeout;

        public RepositoryConfiguration(ILogger logger, IConfiguration configuration)
        {
            Logger = logger;
            ConnectionString = configuration.GetDefaultConnectionString();
            CommandType = CommandType.StoredProcedure;
            CommandTimeout = configuration.GetCommandTimeout();
        }
    }
}
