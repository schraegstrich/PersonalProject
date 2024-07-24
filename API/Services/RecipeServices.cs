using System.Data.SqlClient;
using Models;

namespace Services
{
    public class RecipeServices
    {
        public SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        public IngredientServices ingredientServices = new IngredientServices();

        public async Task<List<Recipe>> GetAllRecipiesAsync()
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("GET_AllRecipies", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    return null;
                }

                var recipies = new List<Recipe>();
                while (await reader.ReadAsync())
                {
                    recipies.Add(new Recipe()
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        Description = await reader.IsDBNullAsync(2) ? null : reader.GetString(2),
                        CookingTimeInMinutes = reader.GetInt32(3),
                        DateAdded = reader.GetDateTime(4),
                        Ingredients = await ingredientServices.GetIngredientsByIdsAsync("RecipeId", reader.GetGuid(0))

                    });
                }
                await connection.CloseAsync();
                return recipies;
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return null;
            }
        }

        public async Task<Recipe> GetRecipeByIdAsync(Guid id)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("GET_RecipeById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue(parameterName: "@Id", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                Recipe recipe = new Recipe();
                
                while (await reader.ReadAsync())
                {
                    recipe.Id = id;
                    recipe.Name = reader.GetString(1);
                    recipe.Description = await reader.IsDBNullAsync(2) ? null : reader.GetString(2);
                    recipe.CookingTimeInMinutes = reader.GetInt32(3);
                    recipe.DateAdded = reader.GetDateTime(4);
                    recipe.Ingredients = await ingredientServices.GetIngredientsByIdsAsync("RecipeId", reader.GetGuid(0));
                }
                await connection.CloseAsync();
                if (recipe == null)
                    return null;
                return recipe;
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return null;
            }
        }

        public async Task<bool> InsertRecipeAsync(Recipe recipe)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("INSERT_Recipe", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("Name", value: recipe.Name);
                command.Parameters.AddWithValue("Description", recipe.Description == null ? DBNull.Value : recipe.Description);
                command.Parameters.AddWithValue("CookingTimeInMinutes", recipe.CookingTimeInMinutes);


                int result = await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return false;
            }
        }

        public async Task<bool> UpdateRecipeByIdAsync(Recipe recipe)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("UPDATE_RecipeById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", recipe.Id);
                command.Parameters.AddWithValue("Name",  recipe.Name);
                command.Parameters.AddWithValue("Description", recipe.Description == null ? DBNull.Value : recipe.Description);
                command.Parameters.AddWithValue("CookingTimeInMinutes", recipe.CookingTimeInMinutes);


                int result = await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return false;
            }
        }

        public async Task<bool> DeleteRecipeByIdAsync(Guid id)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("DELETE_RecipeById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue(parameterName: "@Id", id);

                int result = await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return false;
            }
        }


    }
}
