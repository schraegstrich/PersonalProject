using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace API.Services
{
    public class FoodItemServices
    {
        public SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        public IngredientServices ingredientServices = new IngredientServices();

        public async Task<List<FoodItem>> GetAllFoodItemsAsync()
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("GET_AllFoodItems", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    return null;
                }

                var foods = new List<FoodItem>();
                while (await reader.ReadAsync())
                {
                    foods.Add(new FoodItem()
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        Link = await reader.IsDBNullAsync(2) ? null : reader.GetString(2),
                        QuantityInPackInGramsOrMl = await reader.IsDBNullAsync(3) ? null : reader.GetInt32(3),
                        QuantityInPcs = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4),
                        DateAdded = reader.GetDateTime(5),
                        UsedAsIngredient = await ingredientServices.GetIngredientsByIdsAsync("FoodItemId", reader.GetGuid(0))

                    });
                }
                await connection.CloseAsync();
                return foods;
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return null;
            }
        }
        public async Task<FoodItem> GetFoodItemByIdAsync(Guid id)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("GET_FoodItemById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue(parameterName: "@Id", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                FoodItem food = new FoodItem();

                while (await reader.ReadAsync())
                {
                    food.Id = reader.GetGuid(0);
                    food.Name = reader.GetString(1);
                    food.Link = await reader.IsDBNullAsync(2) ? null : reader.GetString(2);
                    food.QuantityInPackInGramsOrMl = await reader.IsDBNullAsync(3) ? null : reader.GetInt32(3);
                    food.QuantityInPcs = await reader.IsDBNullAsync(4) ? null : reader.GetInt32(4);
                    food.DateAdded = reader.GetDateTime(5);
                    food.UsedAsIngredient = await ingredientServices.GetIngredientsByIdsAsync("FoodItemId", reader.GetGuid(0));
                }
                await connection.CloseAsync();
                if (food == null)
                    return null;
                return food;
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return null;
            }
        }

        public async Task<bool> InsertFoodItemAsync(FoodItem food)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("INSERT_FoodItem", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("Name", value: food.Name);
                command.Parameters.AddWithValue("Link", food.Link == null ? DBNull.Value : food.Link);
                command.Parameters.AddWithValue("QuantityInPackInGramsOrMl", food.QuantityInPackInGramsOrMl == null ? DBNull.Value : food.QuantityInPackInGramsOrMl);
                command.Parameters.AddWithValue("QuantityInPcs", food.QuantityInPcs == null ? DBNull.Value : food.QuantityInPcs);


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
        public async Task<bool> UpdateFoodItemByIdAsync(FoodItem food)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("UPDATE_FoodItemById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", food.Id);
                command.Parameters.AddWithValue("Name",  food.Name);
                command.Parameters.AddWithValue("Link", food.Link == null ? DBNull.Value : food.Link);
                command.Parameters.AddWithValue("QuantityInPackInGramsOrMl", food.QuantityInPackInGramsOrMl == null ? DBNull.Value : food.QuantityInPackInGramsOrMl);
                command.Parameters.AddWithValue("QuantityInPcs", food.QuantityInPcs == null ? DBNull.Value : food.QuantityInPcs);


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
        public async Task<bool> DeleteFoodItemByIdAsync(Guid id)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("DELETE_FoodItemById", connection);
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
