namespace PowerPlantsSolution.Models
{
    public class PowerPlantRequest
    {
        public double Load { get; set; }
        public Fuels Fuels { get; set; }
        public List<PowerPlant> PowerPlants { get; set; }
    }
}
