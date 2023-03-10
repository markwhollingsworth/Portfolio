using Microsoft.Extensions.Configuration;
using Portfolio.Shared.Repository;

namespace Portfolio.Shared.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetAzureUrl(this IConfiguration configuration)
        {
            var url = configuration[StringRepository.AzureUrlKey] ?? StringRepository.AzureFallbackUrl;
            return url;
        }


        public static string GetBlazorUrl(this IConfiguration configuration)
        {
            var url = configuration[StringRepository.BlazorUrlKey] ?? StringRepository.BlazorFallbackUrl;
            return url;
        }

        public static string GetBootstrapUrl(this IConfiguration configuration)
        {
            var url = configuration[StringRepository.BootstrapUrlKey] ?? StringRepository.BootstrapFallbackUrl;
            return url;
        }

        public static string GetCSharpUrl(this IConfiguration configuration)
        {
            var url = configuration[StringRepository.CSharpUrlKey] ?? StringRepository.CSharpFallbackUrl;
            return url;
        }

        public static string GetDotNetUrl(this IConfiguration configuration)
        {
            var url = configuration[StringRepository.DotNetUrlKey] ?? StringRepository.DotNetFallbackUrl;
            return url;
        }

        public static string GetGithubUrl(this IConfiguration configuration)
        {
            var url = configuration[StringRepository.GithubUrlKey] ?? StringRepository.GithubFallbackUrl;
            return url;
        }

        public static string GetJavascriptUrl(this IConfiguration configuration)
        {
            var url = configuration[StringRepository.JavascriptUrlKey] ?? StringRepository.JavascriptFallbackUrl;
            return url;
        }
    }
}
