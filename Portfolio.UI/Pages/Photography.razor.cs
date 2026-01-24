using Microsoft.JSInterop;

namespace Portfolio.UI.Pages
{
    public partial class Photography
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JS.InvokeVoidAsync("interop.loadCarousel");
            }
        }
    }
}
