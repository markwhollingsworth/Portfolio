namespace Portfolio.Common.Models.OldArizonaRoads
{
    public class MapModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Month { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string MapUrl { get; set; } = string.Empty;
        public string MapDescription { get; set; } = string.Empty;
    }
}
