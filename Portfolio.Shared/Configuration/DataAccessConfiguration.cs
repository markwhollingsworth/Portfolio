using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.UI.Extensions;
using System.Data;

namespace Portfolio.UI.Configuration
{
    public class DataAccessConfiguration
    {
        public readonly ILogger Logger;
        public readonly string ConnectionString;
        public readonly CommandType CommandType;
        public readonly int CommandTimeout;

        public DataAccessConfiguration(ILogger logger, IConfiguration configuration)
        {
            Logger = logger;
            ConnectionString = configuration.GetDefaultConnectionString();
            CommandType = CommandType.StoredProcedure;
            CommandTimeout = configuration.GetCommandTimeout();
        }
    }
}
