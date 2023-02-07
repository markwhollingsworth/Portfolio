using Newtonsoft.Json;
using Portfolio.Common.Models.OldArizonaRoads;

namespace Portfolio.UI.Pages.OldArizonaRoads
{
    public partial class MapSearch
    {
        #region Properties

        public string SearchText { get; set; } = string.Empty;

        public List<MapModel> Maps { get; set; } = new List<MapModel>();

        public List<MapModel> FilteredMaps => Maps.Where(
            x => x.MapDescription.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();

        #endregion Properties

        #region Methods

        private async Task<List<MapModel>> GetMaps()
        {
            var mapDataJsonUrl = Configuration.GetValue<string>("MapDataJsonUrl");
            using var client = new HttpClient();
            using var stream = await client.GetStreamAsync(mapDataJsonUrl);
            using var streamReader = new StreamReader(stream);
            var text = streamReader.ReadToEnd();
            var maps = JsonConvert.DeserializeObject<List<MapModel>>(text);
            return maps ?? new List<MapModel>();
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
