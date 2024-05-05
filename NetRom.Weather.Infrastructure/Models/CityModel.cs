namespace NetRom.Weather.Infrastructure.Models
{
    public class CityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double Temperature { get; set; }
    }
}
