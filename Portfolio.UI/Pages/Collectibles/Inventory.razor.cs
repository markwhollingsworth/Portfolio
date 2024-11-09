using Portfolio.Shared.Models;

namespace Portfolio.UI.Pages
{
    public partial class Inventory
    {
        private List<InventoryModel>? Items { get; set; }

        private static string GetItemLink(int id) => $"/item/{id}";

        protected override async Task OnInitializedAsync()
        {
            Items = (await PortfolioService.GetInventoryAsync())?.ToList();
        }
    }
}
