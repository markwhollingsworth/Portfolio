using Portfolio.Common.Models.Collectibles;
using Portfolio.Common.Requests.Collectibles.Coin;
using System.Text.Json;

namespace Portfolio.UI.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PortfolioService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task AddCoin(AddCoinRequest request)
        {
            var baseApiUrl = _configuration["BasePortfolioApiUrl"];
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{baseApiUrl}/inventory/coin/add");
            httpRequest.Content = JsonContent.Create(httpRequest);
            await _httpClient.SendAsync(httpRequest);
        }

        public async Task<CoinModel?> GetById(int id)
        {
            CoinModel? coin = null;
            var baseApiUrl = _configuration.GetValue<string>("BasePortfolioApiUrl");
            using var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}/coin/{id}");
            using var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                coin = await JsonSerializer.DeserializeAsync<CoinModel>(responseStream);
            }

            return coin;
        }

        public async Task<IEnumerable<DenominationModel>?> GetDenominationsAsync()
        {
            IEnumerable<DenominationModel>? denominations = null;
            var baseApiUrl = _configuration.GetValue<string>("BasePortfolioApiUrl");
            using var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}/denomination/all");
            using var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                denominations = await JsonSerializer.DeserializeAsync<IEnumerable<DenominationModel>>(responseStream);
            }

            return denominations;
        }

        public async Task<IEnumerable<InventoryModel>?> GetInventoryAsync()
        {
            IEnumerable<InventoryModel>? inventory = null;
            var baseApiUrl = _configuration.GetValue<string>("BasePortfolioApiUrl");

            if (!string.IsNullOrWhiteSpace(baseApiUrl))
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}/inventory");
                using var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    inventory = await JsonSerializer.DeserializeAsync<IEnumerable<InventoryModel>>(responseStream);
                }
            }

            return inventory;
        }

        public async Task<IEnumerable<MintModel>?> GetMintsAsync()
        {
            List<MintModel>? mints = null;
            var baseApiUrl = _configuration["BasePortfolioApiUrl"];
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}/mint/mints");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                mints = await JsonSerializer.DeserializeAsync<List<MintModel>>(responseStream);
            }

            return mints;
        }

        public async Task UpdateCoin(UpdateCoinRequest request)
        {
            var baseApiUrl = _configuration["BasePortfolioApiUrl"];
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{baseApiUrl}/coin/update");
            httpRequest.Content = JsonContent.Create(httpRequest);
            await _httpClient.SendAsync(httpRequest);
        }
    }
}
