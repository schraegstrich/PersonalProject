using API.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{
    [Route("[Controller]/[Action]")]
    public class SensorController : Controller
    {
        /*[Route("/checker")]
        [HttpGet]
        public IActionResult Checker()
        {
            return Ok("API is running");
        }*/

        //[Route("/GetAllRecipies")]
        
    
        [HttpPost]
        public async Task<IActionResult> InsertSensorDataEntry([FromServices] SensorInteractorServices sensor, [FromQuery] int sensorId, int shelf, int position, Guid foodItemId)
        {
            try
            {
                bool result = await sensor.InsertSensorDataAsync(sensorId, shelf, position,foodItemId);
                if (result)
                    return Ok("Data entry added");
                else
                    throw new Exception("Not added");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        
    }
}
