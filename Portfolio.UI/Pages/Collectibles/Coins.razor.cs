using Microsoft.AspNetCore.Components;
using Portfolio.UI.Models;
using Portfolio.UI.Services;

namespace Portfolio.UI.Pages
{
    public partial class Coins : ComponentBase 
    {
        private List<InventoryModel>? Items { get; set; }

        private static string GetItemLink(int id) => $"/coin/{id}";

        [Inject]
        private IPortfolioService? PortfolioService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (PortfolioService != null)
            {
                Items = (await PortfolioService.GetCoinsAsync())?.ToList();
            }
        }
    }
}
