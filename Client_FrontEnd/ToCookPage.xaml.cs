
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client_FrontEnd.Clients;
using Models;

namespace Client_FrontEnd
{
    /// <summary>
    /// Interaction logic for ToCookPage.xaml
    /// </summary>
    public partial class ToCookPage : Page
    {
        public static Recipe recipe = new Recipe();
        public SensorDataClient sensor = new SensorDataClient();
        public IngredientClient ingredientClient = new IngredientClient();
        public FoodItemClient foodClient = new FoodItemClient();
        public ToCookPage(Recipe recipeToCook)
        {
            recipe = recipeToCook;
            InitializeComponent();
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            //add logic to insert new data entry for each food item in recipe
            //change food item model and procedures to include shelf, position on shelf and sensor id, maybe a setter based on shelf and position

            List<string> names = await GetMissingFoodItemNames(await GetAllFoodItemsinRecipe(recipe.Id));
            missingItemsListView.ItemsSource = names;
        }

        public async Task<List<FoodItem>> GetAllFoodItemsinRecipe( Guid recipeId)
        {
            List<Ingredient> ingredientsInRecipe = await ingredientClient.GetIngredientsByRecipeId(recipeId);
            List<FoodItem> foodItemsInRecipe = new List <FoodItem>();
            foreach(var ingredient in ingredientsInRecipe)
            {
                foodItemsInRecipe.Add(await foodClient.GetFoodItemById(ingredient.FoodItemId));
            }
            return(foodItemsInRecipe);

        }
        public async Task<List<string>> GetMissingFoodItemNames(List<FoodItem> foods)
        {
            SensorDataEntry entry = new SensorDataEntry();
            List<string> missingFoodItemNames = new List<string>();
            foreach (FoodItem food in foods)
            {
                entry = await sensor.GetLatestDataEntryBySensorIdAsync(food.SensorId);
                if (entry.ProductPresent == 0)
                {
                    missingFoodItemNames.Add(food.Name);
                }
            }
            return missingFoodItemNames;
        }

        private void SearchOnAmazon_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string ingredient)
            {
                // URL encode the ingredient to handle spaces and special characters.
                string encodedIngredient = WebUtility.UrlEncode(ingredient);

                // Construct the Amazon Fresh search URL. Here we use the amazon.de site as an example.
                string url = $"https://www.amazon.de/s?k={encodedIngredient}&i=amazonfresh&__mk_de_DE=%C3%85M%C3%85%C5%BD%C3%95%C3%91";

                // Open the default web browser with the constructed URL.
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Invalid ingredient.");
            }
        }

    }
}
