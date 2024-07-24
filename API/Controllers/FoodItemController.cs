using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Services
{
    [Route("[Controller]/[Action]")]
    public class FoodItemController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllFoodItems([FromServices] FoodItemServices food)
        {
            try
            {
                List<FoodItem> allFoodItems = await food.GetAllFoodItemsAsync();
                if (allFoodItems.Count > 0)
                    return Ok(allFoodItems);
                else
                    throw new Exception("No items found");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        public async Task<IActionResult> GetFoodItemById([FromServices] FoodItemServices food, [FromQuery] Guid id)
        {
            try
            {
                FoodItem foodWithId = await food.GetFoodItemByIdAsync(id);
                if (foodWithId != null)
                    return Ok(foodWithId);
                else
                    throw new Exception("No food item with this id");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> InsertFoodItem([FromServices] FoodItemServices food, [FromBody] FoodItem newFood)
        {
            try
            {
                bool result = await food.InsertFoodItemAsync(newFood);
                if (result)
                    return Ok("Food item added");
                else
                    throw new Exception("Not added");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFoodItemById([FromServices] FoodItemServices food, [FromBody] FoodItem updatedFood)
        {
            try
            {
                bool result = await food.UpdateFoodItemByIdAsync(updatedFood);
                if (result)
                    return Ok(value: "Food item updated");
                else
                    throw new Exception("Not updated");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFoodItemById([FromServices] FoodItemServices food, [FromQuery] Guid id)
        {
            try
            {
                bool result = await food.DeleteFoodItemByIdAsync(id);
                if (result != null)
                    return Ok("Food item deleted");
                else
                    throw new Exception("No food item with this id");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
    }
}
