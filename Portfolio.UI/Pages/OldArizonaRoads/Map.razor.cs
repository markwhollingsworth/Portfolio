using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Models;

namespace Portfolio.UI.Pages
{
    public partial class Map
    {
        [Parameter]
        public int Id { get; set; }

        private MapModel? MapDetail { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MapDetail = await PortfolioService.GetMapAsync(Id);
        }
    }
}
