using Newtonsoft.Json;
using PowerPlantsSolution.Models;
using PowerPlantsSolution.Services;

namespace PowerPlant.Tests
{
    public class PowerPlantServiceTests
    {
        private readonly PowerPlantService powerPlantService;

        public PowerPlantServiceTests()
        {
            powerPlantService = new PowerPlantService();
        }

        [Theory]
        [InlineData("payload1.json")]
        [InlineData("payload2.json")]
        [InlineData("payload3.json")]
        public void CalculateProductionPlan_ValidPayload_ReturnsOk(string payload)
        {
            // Arrange
            var powerPlantRequest = LoadPayloadFromFile(payload);

            // Act
            var powerPlantResponse = powerPlantService.GeneratePower(powerPlantRequest);

            // Assert
            Assert.NotNull(powerPlantResponse);
            //Assert.IsType<OkObjectResult>(result);
            Assert.Equal(powerPlantRequest.Load, powerPlantResponse.Production.Sum(x => x.P));
        }

        private PowerPlantRequest LoadPayloadFromFile(string fileName)
        {
            var filePath = Path.Combine("payloads", fileName);
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<PowerPlantRequest>(json);
        }
    }
}