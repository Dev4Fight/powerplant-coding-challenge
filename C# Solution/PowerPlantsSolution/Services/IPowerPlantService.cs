using PowerPlantsSolution.Models;

namespace PowerPlantsSolution.Services
{
    public interface IPowerPlantService
    {
        PowerPlantResponse GeneratePower(PowerPlantRequest powerPlantRequest);
    }
}
