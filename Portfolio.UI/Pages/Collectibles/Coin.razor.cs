using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio.Shared.Models.Collectibles;
using Portfolio.UI.Models;
using Portfolio.UI.Services;

namespace Portfolio.UI.Pages
{
    public partial class Coin
    {
        #region Properties

        [Inject]
        public required IJSRuntime JS { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public required IPortfolioService PortfolioService { get; set; }

        public CoinViewModel? Item { get; set; }

        public bool IsLoading { get; set; } = true;

        #endregion Properties

        #region Blazor

        protected async override Task OnInitializedAsync()
        {
            IsLoading = true;

            if (PortfolioService != null)
            {
                if (Id > 0)
                {
                    var coin = await PortfolioService.GetCoinByIdAsync(Id);
                    var purchaseDetail = coin?.PurchaseDetailId != null ? await PortfolioService.GetPurchaseDetailByIdAsync(coin.PurchaseDetailId.Value) : null;
                    var mint = coin?.MintId != null ? await PortfolioService.GetMintByIdAsync(coin.MintId.Value) : null;

                    Item = new CoinViewModel(coin, purchaseDetail, mint);
                }
            }

            IsLoading = false;
        }

        #endregion Blazor
    }

    public class CoinViewModel
    {
        public CoinModel? Coin { get; set; }

        public PurchaseDetailModel? PurchaseDetail { get; set; }

        public MintModel? Mint { get; set; }

        public CoinViewModel(CoinModel? coin, PurchaseDetailModel? purchaseDetail, MintModel? mint)
        {
            Coin = coin;
            PurchaseDetail = purchaseDetail;
            Mint = mint;
        }
    }
}
