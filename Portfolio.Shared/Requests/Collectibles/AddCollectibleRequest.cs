using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared.Requests.Collectibles
{
    public class AddCollectibleRequest
    {
        [Required(ErrorMessage = "List price is required")]
        public decimal ListPrice { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public PurchaseDetail PurchaseDetail { get; set; } = new();

        public AddCollectibleRequest()
        {
            ListPrice = 0.00M;
            Description = string.Empty;
            PurchaseDetail = new()
            {
                Quantity = 1,
                Subtotal = 0M,
                Shipping = 0M,
                Tax = 0M,
                Total = 0M,
                Date = DateTime.Today.ToShortDateString(),
                SellerName = string.Empty,
                SellerAddress = string.Empty
            };

        }
    }
}
