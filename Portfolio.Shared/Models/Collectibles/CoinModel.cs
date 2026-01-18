using System.ComponentModel.DataAnnotations;

namespace Portfolio.UI.Models
{
    public class CoinModel
	{
		[Range(int.MinValue, int.MaxValue)]
		public int Id { get; set; }

		[StringLength(250)]
		public required string Year { get; set; }

		public decimal? ListPrice { get; set; }

		[StringLength(1000)]
		public required string Description { get; set; }

		[Range(int.MinValue, int.MaxValue)]
        public int Quantity { get; set; }

		public int? PurchaseDetailId { get; set; }

		public int? DenominationId { get; set; }

		public int? MintId { get; set; }

		public int? GradingCompanyId { get; set; }

		[StringLength(50)]
		public string? Grade { get; set; }

		public bool IsForSale { get; set; }
    }
}