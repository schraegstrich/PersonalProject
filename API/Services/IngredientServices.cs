using System.Data.SqlClient;
using Microsoft.AspNetCore.Components;
using Models;

namespace Services
{
    public class IngredientServices
    {
        public SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));

        public async Task<List<Ingredient>> GetIngredientsByIdsAsync(string idType, Guid id)
        {
            Dictionary<string, string> procedureMap = new Dictionary<string, string>
            {
                {"Id", "GET_IngredientById" },
                {"FoodItemId", "GET_IngredientsByFoodItemId" },
                {"RecipeId", "GET_IngredientsByRecipeId" },
            };

            try
            {
                await connection.OpenAsync();
                if (!procedureMap.ContainsKey(idType))
                {
                    throw new ArgumentException("Incorrect search parameter");
                }
                string procedure = procedureMap[idType];
                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue(idType, id);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                var ingredients = new List<Ingredient>();
                while (await reader.ReadAsync())
                {
                    ingredients.Add(new Ingredient()
                    {
                        Id = reader.GetGuid(0),
                        RecipeId = reader.GetGuid(1),
                        FoodItemId = reader.GetGuid(2),
                        Name = reader.GetString(3),
                        QuantityInGramsOrMl = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4),
                        QuantityInPcs = await reader.IsDBNullAsync(5) ? null : reader.GetInt32(5),
                        DateAdded = reader.GetDateTime(6)
                    });
                }
                await connection.CloseAsync();
                return ingredients;

            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return null;
            }
        }

       public async Task<bool> InserIngredientAsync(Ingredient ingredient)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("INSERT_Ingredient", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("RecipeId",  ingredient.RecipeId);
                command.Parameters.AddWithValue("FoodItemId",  ingredient.FoodItemId);
                command.Parameters.AddWithValue("Name",  ingredient.Name);
                command.Parameters.AddWithValue("QuantityInGramsOrMl",  ingredient.QuantityInGramsOrMl == null ? DBNull.Value : ingredient.QuantityInGramsOrMl);
                command.Parameters.AddWithValue("QuantityInPcs", ingredient.QuantityInPcs == null ? DBNull.Value : ingredient.QuantityInPcs);

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

        public async Task<bool> UpdateIngredientByIdAsync(Ingredient ingredient)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("UPDATE_IngredientById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("Id", ingredient.Id);
                command.Parameters.AddWithValue("RecipeId", ingredient.RecipeId);
                command.Parameters.AddWithValue("FoodItemId", ingredient.FoodItemId);
                command.Parameters.AddWithValue("Name", ingredient.Name);
                command.Parameters.AddWithValue("QuantityInGramsOrMl", ingredient.QuantityInGramsOrMl == null ? DBNull.Value : ingredient.QuantityInGramsOrMl);
                command.Parameters.AddWithValue("QuantityInPcs", ingredient.QuantityInPcs == null ? DBNull.Value : ingredient.QuantityInPcs);


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
        public async Task<bool> DeleteIngredientByIdAsync(Guid id)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("DELETE_IngredientById", connection);
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
