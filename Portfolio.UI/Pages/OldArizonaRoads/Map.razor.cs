using Microsoft.AspNetCore.Components;
using Portfolio.Common.Models.OldArizonaRoads;
using System.Text.Json;

namespace Portfolio.UI.Pages.OldArizonaRoads
{
    public partial class Map
    {
        #region Properties

        [Parameter]
        public int Id { get; set; }

        private MapModel? MapDetail { get; set; }

        #endregion Properties

        #region Methods

        private async Task<MapModel?> GetMap()
        {
            MapModel? map = null;
            var url = Configuration?.GetValue<string>("BasePortfolioApiUrl");

            if (!string.IsNullOrWhiteSpace(url))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/map/{Id}");

                var client = ClientFactory.CreateClient("api");
                var response = await client.SendAsync(request);

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
