namespace planetary_api.Models{
    public enum PlanetaryClass {D, H, J, K, L, M, R, T, Y}
    public class Planet{
        public long Id {get; set;}
        public string PlanetName {get; set;}
        public PlanetaryClass PlanetClass {get; set;}
        public string home_star {get; set;}
        public decimal mass {get; set;}
        public decimal radius {get; set;}
        public decimal distance {get; set;}
    }
}