using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio.Shared.Repository;
using Portfolio.UI.Requests.Collectibles;
using Portfolio.UI.Services;

namespace Portfolio.UI.Pages
{
    public partial class AddCoin
    {
        #region Properties

        public Dictionary<int, string>? Denominations { get; set; }
        public Dictionary<int, string>? GradingCompanies { get; set; }
        public Dictionary<int, string>? Mints { get; set; }
        public required SaveCoinRequest SaveCoinRequest { get; set; } = new SaveCoinRequest() { Year = string.Empty, Description = string.Empty };
        public bool IsLoadingComplete { get; set; } = false;
        public bool IsAddCoinSuccessful { get; set; } = false;
        public string AddCoinMessage { get; set; } = Strings.AddCoinMessage;

        [Inject]
        public required IPortfolioService PortfolioService { get; set; }

        [Inject]
        public required IConfiguration Configuration { get; set; }

        [Inject]
        public required IJSRuntime Js { get; set; }

        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        #endregion Properties

        #region Blazor

        protected override async Task OnInitializedAsync()
        {
            GradingCompanies = await PopulateGradingCompaniesAsync();
            Mints = await PopulateMintsAsync();
            Denominations = await PopulateDenominationsAsync();
            IsLoadingComplete = true;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var minimumDate = DateTime.Today.AddYears(-100).ToShortDateString();
            var maximumDate = DateTime.Today.ToShortDateString();
            await Js.InvokeVoidAsync(Strings.InteropInitDatepicker, [Strings.DefaultDateFormat, minimumDate, maximumDate]);
        }

        #endregion Blazor

        #region Private methods

        private void HandleCancel()
        {
            NavigationManager.NavigateTo(string.Empty);
        }

        private async Task<Dictionary<int, string>?> PopulateGradingCompaniesAsync()
        {
            Dictionary<int, string>? result = null;
            var gradingCompanies = (await PortfolioService.GetGradingCompaniesAsync())?.OrderBy(x => x.Description)?.ToList();

            if (gradingCompanies?.Count > 0)
            {
                result = new Dictionary<int, string>();
                foreach (var gradingCompany in gradingCompanies)
                {
                    result.Add(gradingCompany.Id, gradingCompany.Abbreviation ?? string.Empty);
                }
            }

            return result;
        }

        private async Task<Dictionary<int, string>?> PopulateDenominationsAsync()
        {
            Dictionary<int, string>? result = null;
            var denominations = (await PortfolioService.GetDenominationsAsync())?.OrderBy(x => x.Description)?.ToList();

            if (denominations?.Count > 0)
            {
                result = new Dictionary<int, string>();
                foreach (var denomination in denominations)
                {
                    result.Add(denomination.Id, denomination.Description ?? string.Empty);
                }
            }

            return result;
        }

        private async Task<Dictionary<int, string>?> PopulateMintsAsync()
        {
            Dictionary<int, string>? result = null;
            var mints = (await PortfolioService.GetMintsAsync())?.OrderBy(x => x.Name)?.ToList();

            if (mints?.Count > 0)
            {
                result = new Dictionary<int, string>();
                foreach (var mint in mints)
                {
                    result.Add(mint.Id, $"{mint.Name} ({mint.Abbreviation})" ?? string.Empty);
                }
            }

            return result;
        }

        private async Task<int> SaveCoinAsync()
        {
            var result = await PortfolioService.SaveCoinAsync(SaveCoinRequest);
            ResetForm();
            IsAddCoinSuccessful = result != 0 ? true : false;
            return result;
        }

        private async Task UpdateForm()
        {
            //var description = SaveCoinRequest?.Description;
            //if (!string.IsNullOrWhiteSpace(description))
            //{
            //    var result = Denominations?.FirstOrDefault(x => description.Contains(x.Value.Trim())).Value;
            //    SelectedDenomination = result;
            //}
            //else
            //{
            //    SelectedDenomination = "Choose";
            //}
        }

        private void ResetForm()
        {
            SaveCoinRequest = new() { Year = string.Empty, Description = string.Empty, IsCleaned = false };
        }

        #endregion Private methods
    }
}
