using Microsoft.AspNetCore.Components;

namespace Portfolio.UI.Pages
{
    public partial class Resume
    {
        public MarkupString ResumeHtml { get; set; }
        private bool IsLoading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            ResumeHtml = await PortfolioService.ConvertDocumentToHtmlAsync("ResumeUrl");

            IsLoading = false;
        }
    }
}
