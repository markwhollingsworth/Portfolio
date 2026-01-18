using Microsoft.Extensions.Configuration;
using Portfolio.Shared.Repository;
using System.Configuration;

namespace Portfolio.UI.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Strings.DefaultConnection);
            return connectionString == null
                ? throw new ConfigurationErrorsException($"Check {Strings.DefaultConnection} configuation setting.")
                : connectionString;
        }

        public static int GetCommandTimeout(this IConfiguration configuration)
        {
            var commandTimeout = configuration[Strings.CommandTimeout]
                ?? throw new ConfigurationErrorsException($"Check {Strings.CommandTimeout} configuration setting.");
            return commandTimeout == null ? 30 : Convert.ToInt32(commandTimeout);
        }

        public static string GetMapDataLocation(this IConfiguration configuration)
        {
            var location = configuration[Strings.MapDataLocation];
            return location == null
                ? throw new ConfigurationErrorsException($"Check {Strings.MapDataLocation} configuration setting.")
                : location;
        }

        public static string GetAzureUrl(this IConfiguration configuration)
        {
            var url = configuration[Strings.AzureUrlKey] ?? Strings.AzureFallbackUrl;
            return url;
        }

        public static string GetBlazorUrl(this IConfiguration configuration)
        {
            var url = configuration[Strings.BlazorUrlKey] ?? Strings.BlazorFallbackUrl;
            return url;
        }

        public static string GetBootstrapUrl(this IConfiguration configuration)
        {
            var url = configuration[Strings.BootstrapUrlKey] ?? Strings.BootstrapFallbackUrl;
            return url;
        }

        public static string GetCSharpUrl(this IConfiguration configuration)
        {
            var url = configuration[Strings.CSharpUrlKey] ?? Strings.CSharpFallbackUrl;
            return url;
        }

        public static string GetDotNetUrl(this IConfiguration configuration)
        {
            var url = configuration[Strings.DotNetUrlKey] ?? Strings.DotNetFallbackUrl;
            return url;
        }

        public static string GetGithubUrl(this IConfiguration configuration)
        {
            var url = configuration[Strings.GithubUrlKey] ?? Strings.GithubFallbackUrl;
            return url;
        }

        public static string GetJavascriptUrl(this IConfiguration configuration)
        {
            var url = configuration[Strings.JavascriptUrlKey] ?? Strings.JavascriptFallbackUrl;
            return url;
        }
    }
}
