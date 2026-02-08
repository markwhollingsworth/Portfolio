using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio.Shared.Enums;
using Portfolio.Shared.Models;
using Portfolio.UI.Services;

namespace Portfolio.UI.Pages
{
    public partial class Item : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public int CollectibleType { get; set; }

        [Inject]
        public IPortfolioService PortfolioService { get; set; } = default!;

        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;

        public CollectibleModel? Collectible { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadCollectibleAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && Collectible != null)
            {
                // Add delay to ensure libraries are loaded
                await Task.Delay(100);

                // Retry logic in case libraries aren't ready
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        await JSRuntime.InvokeVoidAsync("initializeGallery");
                        break; // Success, exit retry loop
                    }
                    catch (JSException)
                    {
                        if (i == 2) throw; // Rethrow on final attempt
                        await Task.Delay(200); // Wait before retry
                    }
                }
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            // Reinitialize when parameters change (navigating between items)
            if (Collectible != null)
            {
                await Task.Delay(100);
                try
                {
                    await JSRuntime.InvokeVoidAsync("initializeGallery");
                }
                catch (JSException)
                {
                    // Library not ready, ignore
                }
            }
        }

        private async Task LoadCollectibleAsync()
        {
            try
            {
                var result = await PortfolioService.GetCollectibleByIdAsync(Id, (CollectibleType)CollectibleType);

                if (result != null)
                {
                    Collectible = result;
                }
                else
                {
                    Collectible = new CollectibleModel { Description = string.Empty };
                }
            }
            catch (Exception)
            {
                Collectible = new CollectibleModel { Description = string.Empty };
            }
        }

        private string GetCollectibleType()
        {
            var result = "Other";

            switch (CollectibleType)
            {
                case 0:
                    result = "Other";
                    break;
                case 1:
                    result = "Coin";
                    break;
                case 2:
                    result = "Currency";
                    break;
                default:
                    result = "Other";
                    break;
            }

            return result;
        }
    }
}
