using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio.UI.Models;

namespace Portfolio.UI.Components
{
    public partial class MapComponent
    {
        #region Properties

        [Inject]
        public required IJSRuntime JS { get; set; }

        [Parameter]
        public MapModel? Map { get; set; }

        private string GetFullDescription() => $"{Map?.Month?.Trim()} {Map?.Year?.Trim()} {Map?.Description?.Trim()} ({Map?.State?.Trim()})";

        #endregion

        #region Blazor

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (!string.IsNullOrWhiteSpace(Map?.Url))
                {
                    await JS.InvokeVoidAsync("interop.loadZoomify", new object[] { Map.Url });
                }
            }
        }

        #endregion
    }
}