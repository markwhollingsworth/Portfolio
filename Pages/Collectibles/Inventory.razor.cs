using Microsoft.AspNetCore.Components;
using Portfolio.Common.Models.Collectibles;
using System.Text.Json;

namespace Portfolio.UI.Pages.Collectibles
{
    public partial class Inventory
    {
        #region Properties

        private List<InventoryModel> Items { get; set; } = new List<InventoryModel>();

        //private bool IsDeleteCoinSuccessful { get; set; } = false;
        private bool IsLoadingComplete { get; set; } = false;

        [Inject] IHttpClientFactory? ClientFactory { get; set; }
        [Inject] IConfiguration? Configuration { get; set; }

        #endregion Properties

        #region Methods

        private async Task<List<InventoryModel>> GetInventoryAsync()
        {
            List<InventoryModel>? inventory = null;
            try
            {
                var baseApiUrl = Configuration?.GetValue<string>("BaseCollectibleApiUrl");
                if (!string.IsNullOrWhiteSpace(baseApiUrl) && ClientFactory != null)
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}api/inventory");
                    var client = new HttpClient()
                    {
                        BaseAddress = new Uri(baseApiUrl)
                    };
                    var response = await client.SendAsync(request);

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        inventory = await JsonSerializer.DeserializeAsync<List<InventoryModel>>(responseStream);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return inventory ?? new List<InventoryModel>();
        }

        private static string GetItemLink(int id) => $"/item/{id}";

        //private async Task DeleteCoin(int coinId)
        //{
        //    // Validation

        //    var baseApiUrl = Configuration["BaseCollectibleApiUrl"];
        //    var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseApiUrl}api/inventory/delete/coin");
        //    request.Content = JsonContent.Create(coinId);

        //    var client = ClientFactory.CreateClient("api");
        //    var response = await client.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        IsDeleteCoinSuccessful = true;
        //    }
        //}

        #endregion Methods

        #region Lifecycle

        protected override async Task OnInitializedAsync()
        {
            Items = await GetInventoryAsync();
            IsLoadingComplete = true;
        }

        #endregion Lifecycle
    }
}
