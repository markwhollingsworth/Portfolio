using Portfolio.Shared.Enums;

namespace Portfolio.Shared.Models
{
    public class SearchCriteria
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public CoinDenomination Denomination { get; set; } = CoinDenomination.All;

        public string SearchTerm { get; set; } = string.Empty;

        public SearchCriteria(int pageNumber, int pageSize, CoinDenomination denomination, string searchTerm)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Denomination = denomination;
            SearchTerm = searchTerm;
        }

        public SearchCriteria()
        {
                
        }
    }
}
