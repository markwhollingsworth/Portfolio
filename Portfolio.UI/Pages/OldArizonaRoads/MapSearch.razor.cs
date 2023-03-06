using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Models.OldArizonaRoads;
using Portfolio.UI.Extensions;
using System.Text.Json;

namespace Portfolio.UI.Pages.OldArizonaRoads
{
    public partial class MapSearch : ComponentBase
    {
        #region Properties

        [Inject]
        private IConfiguration Configuration { get; set; }

        [Inject]
        private IHttpClientFactory ClientFactory { get; set; }

        private string? SearchText { get; set; }

        private List<MapModel>? Maps { get; set; }

        private List<MapModel>? FilteredMaps => GetFilteredMaps();

        #endregion Properties

        #region Methods

        private async Task<List<MapModel>?> GetMaps()
        {
            List<MapModel>? maps = null;
            var baseUrl = Configuration.GetValue<string>("BasePortfolioApiUrl");

            if (!string.IsNullOrWhiteSpace(baseUrl))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/map/all");

                var client = ClientFactory.CreateClient("api");
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    maps = await JsonSerializer.DeserializeAsync<List<MapModel>>(responseStream);
                }
            }

            return maps;
        }

        private List<MapModel>? GetFilteredMaps()
        {
            List<MapModel>? filteredMaps = null;

            if (Maps != null && !string.IsNullOrWhiteSpace(SearchText))
            {
                bool predicate(MapModel x)
                {
                    return x.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                           x.Year.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                           x.Month.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }

                filteredMaps = Maps.FindAll(predicate);
            }

            return filteredMaps;
        }

        private static string GetMapLink(int id) => $"/map/{id}";

        #endregion Methods

        #region Lifecycle

        protected override async Task OnInitializedAsync()
        {
            Maps = await GetMaps();
        }

        #endregion Lifecycle
    }
}
