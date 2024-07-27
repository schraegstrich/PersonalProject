using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Models;
using System.Text.Json;

namespace Client_FrontEnd.Clients
{
    public class FoodItemClient : HttpClient
    {

        private readonly string _baseUri = @"https://localhost:7000/FoodItem/";
        public FoodItemClient()
        {
        }

        public async Task<FoodItem> GetFoodItemById(Guid id)
        {
            string apiUrl = $"{_baseUri}GetFoodItemById?id={id}";
            var response = await base.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<FoodItem>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception("Error retrieving entry");
            }
        }
    }
}
