using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio.Shared.Enums;
using Portfolio.Shared.Models;
using Portfolio.UI.Services;

namespace Portfolio.UI.Pages
{
    public partial class Inventory : ComponentBase
    {
        [Inject]
        public IPortfolioService PortfolioService { get; set; } = default!;

        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;

        //private ElementReference masonryContainer;
        private List<InventoryModel>? allItems;
        private List<InventoryModel>? Items;
        private HashSet<int> favoriteItems = new();
        private string searchTerm = string.Empty;

        // Pagination properties
        private int currentPage = 1;
        private int pageSize = 9;
        private int totalPages = 1;
        private int totalRecords = 0;

        // Submenu state
        private bool isCoinsExpanded = false;
        private bool isUnitedStatesExpanded = false;
        private CoinDenomination selectedDenomination = CoinDenomination.All;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (Items?.Count > 0)// && !isLoading)
            {
                try
                {
                    //await Task.Delay(100);
                    //await JSRuntime.InvokeVoidAsync("initializeMasonry", masonryContainer);
                    await JSRuntime.InvokeVoidAsync("initializeAllPlugins");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Plugin initialization failed: {ex.Message}");
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadInventoryAsync(currentPage, CoinDenomination.All);
        }

        private async Task LoadInventoryAsync(int pageNumber, CoinDenomination selectedDenomination)
        {
            try
            {
                var searchCriteria = new SearchCriteria(pageNumber, pageSize, selectedDenomination, searchTerm);
                var result = await PortfolioService.GetInventoryAsync(searchCriteria);

                if (result != null)
                {
                    allItems = result.Data.ToList();
                    ApplyFilters();
                    currentPage = result.PageNumber;
                    pageSize = result.PageSize;
                    totalRecords = result.TotalRecords;
                    totalPages = result.TotalPages;
                }
                else
                {
                    Items = new List<InventoryModel>();
                    allItems = new List<InventoryModel>();
                }
            }
            catch (Exception ex)
            {
                Items = new List<InventoryModel>();
                allItems = new List<InventoryModel>();
                Console.WriteLine($"Error loading inventory: {ex}");
            }
       
            //finally
            //{
            //    isLoading = false;
            //}
        }

        private void ToggleCoinsSubmenu()
        {
            isCoinsExpanded = !isCoinsExpanded;
            if (!isCoinsExpanded)
            {
                isUnitedStatesExpanded = false;
                selectedDenomination = CoinDenomination.All;
                FilterByDenomination(selectedDenomination);
            }
        }

        private void ToggleUSCoinsSubmenu()
        {
            isUnitedStatesExpanded = !isUnitedStatesExpanded;

            if (!isUnitedStatesExpanded)
            {
                selectedDenomination = CoinDenomination.All;
                FilterByDenomination(selectedDenomination);
            }
        }

        private async void FilterByDenomination(CoinDenomination denomination)
        {
            selectedDenomination = denomination;
            await LoadInventoryAsync(currentPage, selectedDenomination);
            //ApplyFilters();
            StateHasChanged();
        }

        private void ClearFilters()
        {
            selectedDenomination = CoinDenomination.All;
            searchTerm = string.Empty;
            ApplyFilters();
        }

        private async void ApplyFilters()
        {
            if (allItems == null)
            {
                Items = new List<InventoryModel>();
                return;
            }

            var filtered = allItems.AsEnumerable();


            // Apply denomination filter
            if (selectedDenomination != CoinDenomination.All)
            {
                //await LoadInventoryAsync(currentPage);
                filtered = filtered.Where(item => item.DenominationId == selectedDenomination);
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                filtered = filtered.Where(item =>
                    item.Description != null &&
                    item.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            Items = filtered.ToList();
        }

        private void PerformSearch()
        {
            ApplyFilters();
        }


        private async Task GoToPage(int page)
        {
            if (page < 1 || page > totalPages || page == currentPage)
                return;

            await LoadInventoryAsync(page, selectedDenomination);
            StateHasChanged();
        }

        private async Task PreviousPage()
        {
            if (currentPage > 1)
            {
                await GoToPage(currentPage - 1);
            }
        }

        private async Task NextPage()
        {
            if (currentPage < totalPages)
            {
                await GoToPage(currentPage + 1);
            }
        }

        //private void PerformSearch()
        //{
        //    if (string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        Items = allItems;
        //    }
        //    else
        //    {
        //        Items = allItems?
        //            .Where(item => item.Description != null &&
        //                           item.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
        //            .ToList() ?? new List<InventoryModel>();
        //    }
        //}

        private string GetProductImage(int itemId)
        {
            // Use a placeholder image service or map to actual images
            // For now, cycle through the 9 product images you have
            int imageNumber = ((itemId - 1) % 9) + 1;
            return $"/img/products/product-grey-{imageNumber}.jpg";
        }

        private string GetCategoryName(CoinDenomination denomination)
        {
            return "Coin";//denomination.ToString();
        }

        private void AddToCart(int itemId)
        {
            // Implement add to cart logic
            Console.WriteLine($"Added item {itemId} to cart");
        }

        private void QuickView(int itemId)
        {
            // Implement quick view modal logic
            Console.WriteLine($"Quick view for item {itemId}");
        }

        private void ToggleFavorite(int itemId)
        {
            if (favoriteItems.Contains(itemId))
            {
                favoriteItems.Remove(itemId);
            }
            else
            {
                favoriteItems.Add(itemId);
            }
            StateHasChanged();
        }

        private bool IsFavorite(int itemId)
        {
            return favoriteItems.Contains(itemId);
        }

        private IEnumerable<int> GetPageNumbers()
        {
            var pages = new List<int>();
            var startPage = Math.Max(1, currentPage - 2);
            var endPage = Math.Min(totalPages, currentPage + 2);

            for (int i = startPage; i <= endPage; i++)
            {
                pages.Add(i);
            }

            return pages;
        }
    }
}
