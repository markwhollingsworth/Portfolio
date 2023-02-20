using Microsoft.AspNetCore.Components;
using Portfolio.Common.Models.OldArizonaRoads;
using Portfolio.UI.Extensions;
using System.Text.Json;

namespace Portfolio.UI.Pages.OldArizonaRoads
{
    public partial class Map
    {
        #region Properties

        [Parameter]
        public int Id { get; set; }

        public MapModel? MapDetail { get; set; }

        #endregion Properties

        #region Methods

        private async Task<MapModel?> GetMap()
        {
            MapModel? map = null;
            var baseUri = Configuration?.GetBasePortfolioApiUri();

            if (!string.IsNullOrWhiteSpace(baseUri))
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUri}/map/{Id}");
                using var client = ClientFactory.CreateClient("api");
                using var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    map = await JsonSerializer.DeserializeAsync<MapModel>(responseStream);
                }
            }

            return map;
        }

        #endregion Methods

        #region Lifecycle

        protected override async Task OnInitializedAsync()
        {
            MapDetail = await GetMap();
        }

        #endregion Lifecycle
    }
}
