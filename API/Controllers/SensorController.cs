using API.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        public async Task<IActionResult> InsertSensorDataEntry([FromServices] SensorInsertService sensor, [FromQuery] int sensorId, int shelf, int position, Guid foodItemId)
        {
            try
            {
                bool result = await sensor.InsertSensorDataAsync(sensorId, shelf, position, foodItemId);
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
        [HttpGet]
        public async Task<IActionResult> GetLatestDataEntryByFoodItemId([FromServices] SensorDBServices entry, [FromQuery] Guid foodItemId)
        {
            try
            {
                SensorDataEntry latestEntry = await entry.GetLatestDataEntryByFoodItemIdAsync(foodItemId);
                if (latestEntry != null)
                    return Ok(latestEntry);
                else
                    throw new Exception("No entry retrieved");
            }
            catch (FormatException)
            {
                return BadRequest("Invalid GUID format for foodItemId");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
