using Portfolio.Shared.Models.Collectibles;
using Portfolio.Shared.Requests.Collectibles.Coin;

namespace Portfolio.UI.Pages.Collectibles
{
    public partial class AddCoin
    {
        private List<MintModel>? Mints { get; set; }
        private List<DenominationModel>? Denominations { get; set; }
        private AddCoinRequest AddCoinRequest { get; set; } = new AddCoinRequest();
        private bool IsLoadingComplete { get; set; } = false;
        private bool IsAddCoinSuccessful { get; set; } = false;
        private string AddCoinMessage { get; set; } = "Success!  Coin was added to inventory.";

        private async Task SaveCoin()
        {
            await PortfolioService.AddCoin(AddCoinRequest);
        }

        protected override async Task OnInitializedAsync()
        {
            Mints = (await PortfolioService.GetMintsAsync())?.OrderBy(x => x.Name)?.ToList();
            Denominations = (await PortfolioService.GetDenominationsAsync())?.OrderBy(x => x.Description)?.ToList();
            IsLoadingComplete = true;
        }
    }
}
