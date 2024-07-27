using Models;
using Services;
using System.Data.SqlClient;

namespace API.Services
{
    public class SensorDBServices
    {
        public SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));

        public async Task<SensorDataEntry> GetLatestDataEntryByFoodItemIdAsync(Guid foodItemId)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("GET_LatestEntryForFoodItemId", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue(parameterName: "@FoodItemId", foodItemId);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                SensorDataEntry entry = new SensorDataEntry();

                while (await reader.ReadAsync())
                {
                    entry.DataEntryId = reader.GetGuid(0);
                    entry.SensorId = reader.GetInt32(1);
                    entry.Shelf = reader.GetInt32(2);
                    entry.PositionOnShelf = (Position)(int)reader.GetValue(3);
                    entry.FoodItemId = reader.GetGuid(4);
                    entry.ProductPresent = reader.GetInt32(5);
                    entry.DateAdded = reader.GetDateTime(6);
                }
                await connection.CloseAsync();
                if (entry == null)
                    return null;
                return entry;
            }
            catch (Exception e)
            {
                await connection.CloseAsync();
                return null;
            }
        }

    }
}
