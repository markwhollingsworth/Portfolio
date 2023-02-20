using Portfolio.Common.Models.Collectibles;
using Portfolio.UI.Extensions;
using System.Text.Json;

namespace Portfolio.UI.Pages.Collectibles
{
    public partial class Inventory
    {
        #region Properties

        private List<InventoryModel>? Items { get; set; }

        #endregion Properties

        #region Methods

        private async Task<List<InventoryModel>?> GetInventoryAsync()
        {
            List<InventoryModel>? inventory = null;
            var baseApiUrl = Configuration.GetBasePortfolioApiUri();

            if (!string.IsNullOrWhiteSpace(baseApiUrl))
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, $"{baseApiUrl}/inventory");
                using var client = ClientFactory.CreateClient("api");
                using var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    inventory = await JsonSerializer.DeserializeAsync<List<InventoryModel>>(responseStream);
                }
            }

            return inventory;
        }

        private static string GetItemLink(int id) => $"/item/{id}";

        #endregion Methods

        #region Lifecycle

        protected override async Task OnInitializedAsync()
        {
            Items = await GetInventoryAsync();
        }

        #endregion Lifecycle
    }
}
