using Microsoft.AspNetCore.Mvc;
using PowerPlantsSolution.Models;
using PowerPlantsSolution.Services;

namespace PowerPlantsSolution.Controllers
{
    public class ProductionPlanController : Controller
    {
        private readonly IPowerPlantService _powerPlantService;  
        public ProductionPlanController(IPowerPlantService powerPlantService)
        {
            _powerPlantService = powerPlantService;
        }

        [HttpPost]
        [Route("productionplan")]
        public IActionResult CalculateProductionPlan([FromBody] PowerPlantRequest powerPlantRequest)
        {
            // Validate the payload and perform error handling if needed

            // Optimize power generation based on the payload
            
            var response = _powerPlantService.GeneratePower(powerPlantRequest);

            // Return the response
            return Ok(response);
        }
    }
}
