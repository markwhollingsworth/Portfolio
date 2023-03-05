using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Portfolio.UI.Pages
{
    public partial class Photography : ComponentBase
    {
        [Inject]
        private IJSRuntime? JsRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (JsRuntime != null)
            {
                await JsRuntime.InvokeVoidAsync("loadCarousel");
            }
        }
    }
}
