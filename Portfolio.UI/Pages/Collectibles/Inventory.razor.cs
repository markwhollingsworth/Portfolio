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

        #endregion Properties

        #region Methods

        private async Task<List<InventoryModel>> GetInventoryAsync()
        {
            List<InventoryModel>? inventory = null;
            var baseApiUrl = Configuration.GetValue<string>("BaseCollectibleApiUrl");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}api/inventory");

            var client = ClientFactory.CreateClient("api");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                inventory = await JsonSerializer.DeserializeAsync<List<InventoryModel>>(responseStream);
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
