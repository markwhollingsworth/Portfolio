using Portfolio.Shared.Enums;

namespace Portfolio.UI.Models
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal ListPrice { get; set; }
        //public Denomination DenominationId { get; set; }
        //public Mint MintId { get; set; }
        public int Quantity { get; set; }
    }
}