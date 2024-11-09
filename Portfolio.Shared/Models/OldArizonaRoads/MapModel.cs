namespace Portfolio.Shared.Models
{
    public class MapModel
    {
        public Guid Id { get; set; }
        public string? Year { get; set; }
        public string? Month { get; set; }
        public string? State { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public string? Source { get; set; }
    }
}