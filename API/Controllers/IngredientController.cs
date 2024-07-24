using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace API.Controllers
{
    [Route("[Controller]/[Action]")]
    public class IngredientController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetIngredientsByIds([FromServices] IngredientServices ingredient, [FromQuery] string idType, Guid id)
        {
            try
            {
                List<Ingredient> ingredients = await ingredient.GetIngredientsByIdsAsync(idType, id);
                if (ingredients != null)
                    return Ok(ingredients);
                else
                    throw new Exception("No ingredient with this reference");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> InsertIngredient([FromServices] IngredientServices ingredient, [FromBody] Ingredient newIngredient)
        {
            try
            {
                bool result = await ingredient.InserIngredientAsync(newIngredient);
                if (result)
                    return Ok("Ingredient added");
                else
                    throw new Exception("Not added");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateIngredientById([FromServices] IngredientServices ingredient, [FromBody] Ingredient updatedIngredient)
        {
            try
            {
                bool result = await ingredient.UpdateIngredientByIdAsync(updatedIngredient);
                if (result)
                    return Ok(value: "Ingredient updated");
                else
                    throw new Exception("Not updated");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteIngredientById([FromServices] IngredientServices ingredient, [FromQuery] Guid id)
        {
            try
            {
                bool result = await ingredient.DeleteIngredientByIdAsync(id);
                if (result != null)
                    return Ok("Ingredient deleted");
                else
                    throw new Exception("No ingredient with this id");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }

    }
}
