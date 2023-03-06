using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio.Shared.Models.OldArizonaRoads;

namespace Portfolio.UI.Components.OldArizonaRoads
{
    public partial class MapComponent
    {
        #region Properties

        [Parameter]
        public MapModel? Map { get; set; }

        #endregion Properties

        #region Methods

        private string GetFullDescription() => $"{Map?.Month?.Trim()} {Map?.Year?.Trim()} {Map?.State?.Trim()} {Map?.Description?.Trim()}";

        #endregion

        #region Lifecycle

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!string.IsNullOrWhiteSpace(Map?.Url))
            {
                await JSRuntime.InvokeVoidAsync("loadZoomify", new object[] { Map.Url });
            }
        }

        #endregion Lifecycle
    }
}
