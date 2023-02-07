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

        private MapModel MapDetail { get; set; } = new MapModel();

        #endregion Properties

        #region Methods

        private async Task<MapModel> GetMap()
        {
            var mapDataJsonUrl = Configuration.GetValue<string>("MapDataJsonUrl");
            using var client = new HttpClient();
            using var stream = await client.GetStreamAsync(mapDataJsonUrl);
            using var streamReader = new StreamReader(stream);
            var text = streamReader.ReadToEnd();
            var map = JsonConvert.DeserializeObject<List<MapModel>>(text)?.FirstOrDefault(x => x.Id == Id);
            return map ?? new MapModel();
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
