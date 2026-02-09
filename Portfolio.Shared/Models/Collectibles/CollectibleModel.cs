using System;

namespace Portfolio.Shared.Models
{
	public class CollectibleModel
	{
		public int Id { get; set; }
		public string? Year { get; set; }
		public decimal ListPrice { get; set; } = 0;
		public required string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
		public bool IsForSale { get; set; }
		public int? MintId { get; set; } = 0;
		public string? MintName { get; set; } = string.Empty;
        public string? MintAbbreviation { get; set; } = string.Empty;
        public string? DenominationDescription { get; set; } = string.Empty;
		public string? GradingCompanyDescription { get; set; } = string.Empty;
        public string? GradingCompanyAbbreviation { get; set; } = string.Empty;
    }
}