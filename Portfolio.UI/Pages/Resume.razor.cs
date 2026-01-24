using Microsoft.AspNetCore.Components;
using Portfolio.UI.Services;

namespace Portfolio.UI.Pages
{
    public partial class Resume
    {
        [Inject]
        public required IPortfolioService PortfolioService { get; set; }
        public MarkupString ResumeHtml { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ResumeHtml = await PortfolioService.ConvertDocumentToHtmlAsync("ResumeUrl");
        }
    }
}
