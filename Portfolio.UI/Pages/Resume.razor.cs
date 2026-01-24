using Microsoft.AspNetCore.Components;

namespace Portfolio.UI.Pages
{
    public partial class Resume
    {
        public MarkupString ResumeHtml { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ResumeHtml = await PortfolioService.ConvertDocumentToHtmlAsync("ResumeUrl");
        }
    }
}
