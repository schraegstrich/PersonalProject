
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
            sensorUpdater();
            InitializeAsync();
        }

        private async void sensorUpdater()
        {
            List<FoodItem> itemsInRecipe = await GetAllFoodItemsinRecipe(recipe.Id);
            foreach (FoodItem item in itemsInRecipe)
            {
                try
                {
                    bool result = await sensor.InsertSensorDataEntryAsync(item.SensorId);
                    /*if (result)
                        MessageBox.Show($"Check successful for {item.Name}");
                    else
                        MessageBox.Show($"Check failed for {item.Name}");*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing {item.Name}: {ex.Message}");
                }
            }
            Task.Delay(1000);
            bool resultInitialize = await InitializeAsync();
        }

        private async Task<bool> InitializeAsync()
        {
            List<string> names = await GetMissingFoodItemNames(await GetAllFoodItemsinRecipe(recipe.Id));
            missingItemsListView.ItemsSource = names;
            if (names.Count > 0)
                return true;
            return false;
        }

        public async Task<List<FoodItem>> GetAllFoodItemsinRecipe(Guid recipeId)
        {
            List<Ingredient> ingredientsInRecipe = await ingredientClient.GetIngredientsByRecipeId(recipeId);
            List<FoodItem> foodItemsInRecipe = new List<FoodItem>();
            foreach (var ingredient in ingredientsInRecipe)
            {
                var foodItem = await foodClient.GetFoodItemById(ingredient.FoodItemId);
                if (foodItem != null)
                {
                    foodItemsInRecipe.Add(foodItem);
                }
                else
                {
                    MessageBox.Show($"Food item not found for ingredient: {ingredient.Name}");
                }
            }
            return foodItemsInRecipe;
        }

        public async Task<List<string>> GetMissingFoodItemNames(List<FoodItem> foods)
        {
            List<string> missingFoodItemNames = new List<string>();
            foreach (FoodItem food in foods)
            {
                SensorDataEntry entry = await sensor.GetLatestDataEntryBySensorIdAsync(food.SensorId);
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
                string encodedIngredient = WebUtility.UrlEncode(ingredient);
                string url = $"https://www.amazon.de/s?k={encodedIngredient}&i=amazonfresh&__mk_de_DE=%C3%85M%C3%85%C5%BD%C3%95%C3%91";
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

    /// <summary>
    /// Interaction logic for ToCookPage.xaml
    /// </summary>
    /*public partial class ToCookPage : Page
    {
        public static Recipe recipe = new Recipe();
        public SensorDataClient sensor = new SensorDataClient();
        public IngredientClient ingredientClient = new IngredientClient();
        public FoodItemClient foodClient = new FoodItemClient();
        public ToCookPage(Recipe recipeToCook)
        {
            recipe = recipeToCook;
            InitializeComponent();
            sensorUpdater();
            InitializeAsync();
        }

        private async void sensorUpdater()
        {
            List<FoodItem> itemsInRecipe = await GetAllFoodItemsinRecipe(recipe.Id);
            bool result = false;
            foreach (FoodItem item in itemsInRecipe)
            {
                result = await sensor.InsertSensorDataEntryAsync(item.SensorId);
                if (result == false)
                    MessageBox.Show($"Check failed for {item.Name}");
                if (result == true)
                    MessageBox.Show($"Check successful for {item.Name}");
            }

        }
        private async void InitializeAsync()
        {            
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

    }*/
}
