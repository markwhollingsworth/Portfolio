using Portfolio.Common.Models.Collectibles;

namespace Portfolio.UI.Pages.Collectibles
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
