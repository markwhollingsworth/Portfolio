using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Portfolio.UI.Components.OldArizonaRoads
{
    public partial class MapComponent
    {
        [Parameter]
        public string MapUrl { get; set; } = string.Empty;

        [Parameter]
        public string PageTitle { get; set; } = string.Empty;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!string.IsNullOrWhiteSpace(MapUrl))
            {
                await jsRuntime.InvokeVoidAsync("loadZoomify", new object[] { MapUrl });
            }
        }
    }
}
