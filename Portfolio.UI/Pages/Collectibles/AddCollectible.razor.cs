using Microsoft.JSInterop;
using Portfolio.Shared.Requests.Collectibles;

namespace Portfolio.UI.Pages
{
    public partial class AddCollectible
    {
        //private List<MintModel>? Mints { get; set; }
        //private List<DenominationModel>? Denominations { get; set; }
        private AddCollectibleRequest AddCollectibleRequest { get; set; } = new();
        private bool IsLoadingComplete { get; set; } = false;
        private bool IsAddCollectibleSuccessful { get; set; } = false;
        private string AddCollectibleMessage { get; set; } = "Success!  Collectible was added to inventory.";

        private async Task<int> SaveCollectible()
        {
            return await PortfolioService.AddCollectibleAsync(AddCollectibleRequest);
        }

        protected override async Task OnInitializedAsync()
        {
            //Mints = (await PortfolioService.GetMintsAsync())?.OrderBy(x => x.Name)?.ToList();
            //Denominations = (await PortfolioService.GetDenominationsAsync())?.OrderBy(x => x.Description)?.ToList();
            IsLoadingComplete = true;
        }

        //private IJSObjectReference? module;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var format = "mm-dd-yyyy";
                var minimumDate = DateTime.Today.AddYears(-100).ToShortDateString();
                var maximumDate = DateTime.Today.ToShortDateString();
                await JS.InvokeVoidAsync("interop.initDatepicker", new object[] { format, minimumDate, maximumDate });
            }
        }
    }
}
