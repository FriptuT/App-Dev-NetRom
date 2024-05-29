using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NetRom.Weather.Application.Models
{
    public class Coordinates
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class Main
    {
        public double Pressure { get; set; }
        public long Humidity { get; set; }
        public double Temp { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
    }

    public class WeatherModel
    {
        public Coordinates? Coord { get; set; }
        public double TimeZone { get; set; }

        [JsonProperty("dt")]
        public long Date { get; set; }

        public Main? Main { get; set; }
        public Wind? Wind { get; set; }
    }
}