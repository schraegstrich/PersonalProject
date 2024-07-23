using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{
    [Route("[Controller]/[Action]")]
    public class RecipeController : Controller
    {
        /*[Route("/checker")]
        [HttpGet]
        public IActionResult Checker()
        {
            return Ok("API is running");
        }*/

        //[Route("/GetAllRecipies")]
        [HttpGet]
        public async Task<IActionResult> GetAllRecipies([FromServices]RecipeServices recipe)
        {
            try
            {
                List<Recipe> allRecipies = await recipe.GetAllRecipiesAsync();
                if (allRecipies.Count > 0)
                    return Ok(allRecipies);
                else
                    throw new Exception("No recipies found");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetRecipeById([FromServices] RecipeServices recipe, [FromQuery] Guid id)
        {
            try
            {
                Recipe recipeWithId = await recipe.GetRecipeByIdAsync(id);
                if (recipeWithId != null)
                    return Ok(recipeWithId);
                else
                    throw new Exception("No recipe with this id");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> InsertRecipe([FromServices] RecipeServices recipe, [FromBody] Recipe newRecipe)
        {
            try
            {
                bool result = await recipe.InsertRecipeAsync(newRecipe);
                if (result)
                    return Ok("Recipe added");
                else
                    throw new Exception("Not added");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRecipeById([FromServices] RecipeServices recipe, [FromBody] Recipe updatedRecipe)
        {
            try
            {
                bool result = await recipe.UpdateRecipeByIdAsync(updatedRecipe);
                if (result)
                    return Ok(value: "Recipe updated");
                else
                    throw new Exception("Not updated");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRecipeById([FromServices] RecipeServices recipe, [FromQuery] Guid id)
        {
            try
            {
                bool result = await recipe.DeleteRecipeByIdAsync(id);
                if (result != null)
                    return Ok("Recipe deleted");
                else
                    throw new Exception("No recipe with this id");
            }
            catch (Exception ex)
            {
                return BadRequest(500);
            }
        }
    }
}
