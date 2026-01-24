using Microsoft.AspNetCore.Components;
using Portfolio.UI.Models;

namespace Portfolio.UI.Pages
{
    public partial class Map
    {
        #region Properties

        [Parameter]
        public int Id { get; set; }

        private MapModel? MapDetail { get; set; }

        #endregion Properties

        #region Blazor

        protected override async Task OnInitializedAsync()
        {
            MapDetail = await PortfolioService.GetMapByIdAsync(Id);
        }

        #endregion Blazor
    }
}
