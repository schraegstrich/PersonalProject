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
        public async Task<IActionResult> InsertSensorDataEntry([FromServices] SensorInsertService sensor, [FromQuery] string sensorId)
        {
            try
            {
                bool result = await sensor.InsertSensorDataAsync(sensorId);
                if (result)
                    return Ok("Data entry added");
                else
                    return StatusCode(500, "Failed to add data entry.");
            }
            catch (Exception ex)
            {
                // Log the exception details
                System.Diagnostics.Debug.WriteLine($"Controller exception: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetLatestDataEntryBySensorId([FromServices] SensorDBServices entry, [FromQuery] string sensorId)
        {
            try
            {
                SensorDataEntry latestEntry = await entry.GetLatestDataEntryBySensorIdAsync(sensorId);
                if (latestEntry != null)
                    return Ok(latestEntry);
                else
                    throw new Exception("No entry retrieved");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
