using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Models;

namespace Portfolio.UI.Pages
{
    public partial class Map
    {
        [Parameter]
        public Guid Id { get; set; }

        private MapModel? MapDetail { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MapDetail = await PortfolioService.GetMapByIdAsync(Id);
        }
    }
}
