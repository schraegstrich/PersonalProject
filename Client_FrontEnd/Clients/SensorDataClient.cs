using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Models;
using System.Text.Json;

namespace Client_FrontEnd
{
    public class SensorDataClient : HttpClient
    {
        private readonly string _baseUri = @"https://localhost:7000/Sensor/";
        public SensorDataClient()
        {
        }

        public async Task<bool> InsertSensorDataEntryAsync(string id)
        {
            string apiUrl = $"{_baseUri}InsertSensorDataEntry?sensorId={id}";

            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
            {
                Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await base.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
        public async Task<SensorDataEntry> GetLatestDataEntryBySensorIdAsync(string sensorId)
        {
            string apiUrl = $"{_baseUri}GetLatestDataEntryBySensorId?sensorId={sensorId}";
            var response = await base.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SensorDataEntry>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception("Error retrieving entry");
            }
        }

    }
}