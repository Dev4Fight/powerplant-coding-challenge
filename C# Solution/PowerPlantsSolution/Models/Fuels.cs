using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PowerPlantsSolution.Models
{
    public class Fuels
    {
        [JsonProperty("gas(euro/MWh)")]
        public double Gas { get; set; }

        [JsonProperty("kerosine(euro/MWh)")]
        public double Kerosine { get; set; }

        [JsonProperty("co2(euro/ton)")]
        public double CO2 { get; set; }

        [JsonProperty("wind(%)")]
        public double Wind { get; set; }
    }
}
