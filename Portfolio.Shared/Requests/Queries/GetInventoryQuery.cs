using MediatR;
using Portfolio.Shared.Enums;
using Portfolio.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared.Requests.Queries
{
    public class GetInventoryQuery : IRequest<PaginatedResult<InventoryModel>>
    {
        public GetInventoryQuery(SearchCriteria searchCriteria)
        {
            PageNumber = searchCriteria?.PageNumber ?? 1;
            PageSize = searchCriteria?.PageSize ?? 9;
            Denomination = searchCriteria?.Denomination ?? CoinDenomination.All;
            SearchTerm = searchCriteria?.SearchTerm ?? string.Empty;
        }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 9;

        public CoinDenomination Denomination { get; set; } = CoinDenomination.All;

        [MaxLength(150)]
        public string SearchTerm { get; set; } = string.Empty;
    }
}