using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Portfolio.Common.Models.OldArizonaRoads;

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
            var url = Configuration?.GetValue<string>("MapsDataUrl");

            if (!string.IsNullOrWhiteSpace(url))
            {
                using var client = new HttpClient();
                using var stream = await client.GetStreamAsync(url);
                using var streamReader = new StreamReader(stream);
                var text = streamReader.ReadToEnd();
                map = JsonConvert.DeserializeObject<List<MapModel>>(text)?.FirstOrDefault(x => x.Id == Id);
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
