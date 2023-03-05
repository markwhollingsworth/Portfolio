namespace Portfolio.Common.Models.Collectibles
{
	public class CoinModel
	{
		public int Id { get; set; }
		public int Year { get; set; }
		public decimal ListPrice { get; set; }
		public int DenominationId { get; set; }
		public int MintId { get; set; }
		public int Quantity {get;set;}
    }
}
