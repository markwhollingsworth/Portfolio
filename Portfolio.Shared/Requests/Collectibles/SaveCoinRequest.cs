using System.ComponentModel.DataAnnotations;

namespace Portfolio.UI.Requests.Collectibles
{
    public class SaveCoinRequest
    {
        [Required(ErrorMessage = "List price is required")]
        public decimal ListPrice { get; set; } = 0.00m;

        [Required(ErrorMessage = "Year is required")]
        public required string Year { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public required string Description { get; set; }

        public int Quantity { get; set; } = 1;

        public string? GradedBy { get; set; } = null;

        public string? Grade { get; set; } = null;

        public bool IsCleaned { get; set; } = false;

        public bool IsForSale { get; set; } = false;

        public int? MintId { get; set; }

        public int? DenominationId { get; set; }

        public PurchaseDetail PurchaseDetail { get; set; } = new();

        public SaveCoinRequest()
        {
            Description = string.Empty;
            Quantity = 1;
            ListPrice = 0.00M;
            Grade = null;
            GradedBy = null;
            IsCleaned = false;
            IsForSale = false;
            PurchaseDetail = new()
            {
                Quantity = 1,
                Subtotal = 0.00m,
                Shipping = 0.00m,
                Tax = 0.00m,
                Total = 0.00m,
                Date = DateTime.Today.ToShortDateString(),
                SellerName = null,
                SellerAddress = null
            };
        }
    }
}
