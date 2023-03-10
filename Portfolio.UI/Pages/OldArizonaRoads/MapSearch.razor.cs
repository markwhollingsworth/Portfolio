using Portfolio.Shared.Models;

namespace Portfolio.UI.Pages
{
    public partial class MapSearch
    {
        private string? SearchText { get; set; }

        private List<MapModel>? Maps { get; set; }

        private List<MapModel>? FilteredMaps => PortfolioService.GetFilteredMaps(Maps, SearchText)?.ToList();

        private static string GetMapLink(int id) => $"/map/{id}";

        protected override async Task OnInitializedAsync()
        {
            Maps = (await PortfolioService.GetMapsAsync())?.ToList();
            //FilteredMaps = PortfolioService.GetFilteredMaps(Maps, SearchText)?.ToList();
        }
    }
}
