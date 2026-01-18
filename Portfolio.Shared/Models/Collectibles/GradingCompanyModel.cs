using System.ComponentModel.DataAnnotations;

namespace Portfolio.Shared.Models.Collectibles
{
    public class GradingCompanyModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        public required string Description { get; set; }

        [StringLength(25)]
        public required string Abbreviation { get; set; }
    }
}
