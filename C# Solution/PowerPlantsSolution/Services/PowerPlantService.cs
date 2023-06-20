using PowerPlantsSolution.Models;

namespace PowerPlantsSolution.Services
{
    public class PowerPlantService : IPowerPlantService
    {
        public PowerPlantResponse GeneratePower(PowerPlantRequest powerPlantRequest)
        {
            double availableWindPower = powerPlantRequest.Fuels.Wind / 100 * GetMaxWindPowerCapacity(powerPlantRequest.PowerPlants);
            double requiredGasPower = powerPlantRequest.Load - availableWindPower;
            double totalGasPowerCapacity = GetTotalGasPowerCapacity(powerPlantRequest.PowerPlants);

            var sortedGasPowerPlants = SortGasPowerPlantsByEfficiency(powerPlantRequest.PowerPlants);

            var powerDistribution = new List<PowerPlantProduction>();

            foreach (var powerPlant in sortedGasPowerPlants)
            {
                double maxPower = Math.Min(powerPlant.Pmax, requiredGasPower);
                requiredGasPower -= maxPower;
                powerDistribution.Add(new PowerPlantProduction { Name = powerPlant.Name, P = maxPower });

                if (requiredGasPower <= 0)
                    break;
            }

            if (requiredGasPower > 0)
            {
                DistributeRemainingGasPower(sortedGasPowerPlants, requiredGasPower, powerDistribution);
            }

            AddWindPowerDistribution(powerPlantRequest.PowerPlants, availableWindPower, powerDistribution);

            powerDistribution.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));

            var response = new PowerPlantResponse { Production = powerDistribution };
            return response;
        }

        private double GetMaxWindPowerCapacity(List<PowerPlant> powerPlants)
        {
            return powerPlants.Where(p => p.Type == "windturbine").Sum(p => p.Pmax);
        }

        private double GetTotalGasPowerCapacity(List<PowerPlant> powerPlants)
        {
            return powerPlants.Where(p => p.Type == "gasfired").Sum(p => p.Pmax);
        }

        private List<PowerPlant> SortGasPowerPlantsByEfficiency(List<PowerPlant> powerPlants)
        {
            return powerPlants.Where(p => p.Type == "gasfired")
                .OrderByDescending(p => p.Efficiency)
                .ToList();
        }

        private void DistributeRemainingGasPower(List<PowerPlant> gasPowerPlants, double remainingPower, List<PowerPlantProduction> powerDistribution)
        {
            foreach (var powerPlant in gasPowerPlants)
            {
                if (remainingPower <= 0)
                    break;

                double availablePower = powerPlant.Pmax - powerDistribution.Where(p => p.Name == powerPlant.Name).Sum(p => p.P);
                double allocatedPower = Math.Min(availablePower, remainingPower);
                remainingPower -= allocatedPower;

                powerDistribution.Add(new PowerPlantProduction { Name = powerPlant.Name, P = allocatedPower });
            }
        }

        private void AddWindPowerDistribution(List<PowerPlant> powerPlants, double availableWindPower, List<PowerPlantProduction> powerDistribution)
        {
            foreach (var powerPlant in powerPlants.Where(p => p.Type == "windturbine"))
            {
                double generatedPower = availableWindPower * (powerPlant.Pmax / GetMaxWindPowerCapacity(powerPlants));
                powerDistribution.Add(new PowerPlantProduction { Name = powerPlant.Name, P = generatedPower });
            }
        }
    }
}
