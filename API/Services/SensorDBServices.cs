using Models;
using Services;
using System.Data.SqlClient;

namespace API.Services
{
    public class SensorDBServices
    {
        public SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));

        public async Task<SensorDataEntry> GetLatestDataEntryBySensorIdAsync(string sensorId)
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("GET_LatestEntryForSensorId", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue(parameterName: "@SensorId", sensorId);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                SensorDataEntry entry = new SensorDataEntry();

                while (await reader.ReadAsync())
                {
                    entry.DataEntryId = reader.GetGuid(0);
                    entry.SensorId = reader.GetString(1);
                    entry.ProductPresent = reader.GetInt32(2);
                    entry.DateAdded = reader.GetDateTime(3);
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
