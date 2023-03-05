using Microsoft.AspNetCore.Components;

namespace Portfolio.UI.Pages
{
    public partial class AboutSite : ComponentBase
    {
        #region Properties

        [Inject]
        private IConfiguration? Configuration { get; set; }

        #endregion Properties

        #region Methods

        private string GetBlazorUrl()
        {
            var url = "https://www.google.com/search?q=blazor";
            if (Configuration != null)
            {
                url = Configuration.GetValue<string>("BlazorUrl");
            }
            return url ?? "https://www.google.com/search?q=blazor";
        }

        private string GetCSharpUrl()
        {
            var url = "https://www.google.com/search?q=c%23";
            if (Configuration != null)
            {
                url = Configuration.GetValue<string>("CSharpUrl");
            }
            return url ?? "https://www.google.com/search?q=c%23";
        }

        private string GetBootstrapUrl()
        {
            var url = "https://www.google.com/?q=bootstrap";
            if (Configuration != null)
            {
                url = Configuration.GetValue<string>("BootstrapUrl");
            }
            return url ?? "https://www.google.com/?q=bootstrap";
        }

        private string GetJavascriptUrl()
        {
            var url = "https://www.google.com/?q=javascript";
            if (Configuration != null)
            {
                url = Configuration.GetValue<string>("JavascriptUrl");
            }
            return url ?? "https://www.google.com/?q=javascript";
        }

        private string GetDotNetUrl()
        {
            var url = "https://www.google.com/?q=.net%207";
            if (Configuration != null)
            {
                url = Configuration.GetValue<string>("DotNetUrl");
            }
            return url ?? "https://www.google.com/?q=.net%207";
        }

        private string GetAzureUrl()
        {
            var url = "https://www.google.com/?q=azure";
            if (Configuration != null)
            {
                url = Configuration.GetValue<string>("AzureUrl");
            }
            return url ?? "https://www.google.com/?q=azure";
        }

        private string GetGithubUrl()
        {
            var url = "https://www.google.com/?q=github";
            if (Configuration != null)
            {
                url = Configuration.GetValue<string>("GithubUrl");
            }
            return url ?? "https://www.google.com/?q=github";
        }

        #endregion
    }
}
