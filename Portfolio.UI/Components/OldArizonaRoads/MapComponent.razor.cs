using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Portfolio.UI.Components.OldArizonaRoads
{
    public partial class MapComponent
    {
        #region Properties

        [Parameter]
        public required string Url { get; set; }

        [Parameter]
        public required string Description { get; set; }

        [Parameter]
        public required string Year { get; set; }

        [Parameter]
        public string? Month { get; set; }

        [Parameter]
        public required string State { get; set; }

        #endregion Properties

        #region Methods

        private string GetFullDescription() => $"{Month?.Trim()} {Year?.Trim()} {State?.Trim()} {Description?.Trim()}";

        #endregion

        #region Lifecycle

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!string.IsNullOrWhiteSpace(Url))
            {
                await JSRuntime.InvokeVoidAsync("loadZoomify", new object[] { Url });
            }
        }

        #endregion Lifecycle
    }
}
