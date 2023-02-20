namespace Portfolio.UI.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string? GetBasePortfolioApiUri(this IConfiguration configuration)
        {
            var uri = configuration?.GetValue<string>("BasePortfolioApiUrl");
            return uri;
        }
    }
}
