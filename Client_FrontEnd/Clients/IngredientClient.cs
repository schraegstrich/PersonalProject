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
    public class IngredientClient : HttpClient
    {

        private readonly string _baseUri = @"https://localhost:7000/Ingredient/";
        public IngredientClient()
        {
        }

        public async Task<List<Ingredient>> GetIngredientsByRecipeId(Guid id)
        {
            string apiUrl = $"{_baseUri}GetIngredientsByIds?idType=RecipeId&id={id}";
            var response = await base.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Ingredient>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception("Error retrieving entry");
            }
        }

        public async Task<bool> InsertIngredientAsync(Ingredient ingredient)
        {
            string apiUrl = $"{_baseUri}InsertIngredient";
            var json = JsonSerializer.Serialize(ingredient);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await base.PostAsync(apiUrl, data);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateIngredientAsync(Ingredient ingredient)
        {
            string apiUrl = $"{_baseUri}UpdateIngredientById";
            var json = JsonSerializer.Serialize(ingredient);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await base.PostAsync(apiUrl, data);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteIngredientAsync(Guid id)
        {
            string apiUrl = $"{_baseUri}DeleteIngredientById?id={id}";
            var response = await base.DeleteAsync(apiUrl);
            return response.IsSuccessStatusCode;
        }
    }

}
