using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client_FrontEnd.Clients;
using Models;

namespace Client_FrontEnd
{
    /// <summary>
    /// Interaction logic for AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        public static Recipe recipe = new Recipe();
        public static Ingredient ingredient = new Ingredient();
        public static FoodItemClient foodClient = new FoodItemClient();
        public static IngredientClient ingredientClient = new IngredientClient();
        public static RecipeClient recipeClient = new RecipeClient();
        public static List<FoodItem> allFoodItems = new List<FoodItem>();

        public AddIngredientWindow(Recipe recipeToUpdateWithIngredients)
        {
            recipe = recipeToUpdateWithIngredients;
            InitializeComponent();
            InitializeAsync();
        }
        public async void InitializeAsync()
        {
            allFoodItems = await foodClient.GetAllFoodItemsAsync();
            List<string> names = new List<string>();

            foreach(var food in allFoodItems)
            {
                names.Add(food.Name);
            }
            cbFoodItem.ItemsSource = names;

        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await FoodItemAdder();
        }

        private async Task<bool> FoodItemAdder()
        {
            Recipe addedRecipe = (await recipeClient.GetAllRecipesAsync()).FirstOrDefault(r => r.Name == recipe.Name);

            ingredient.RecipeId =  addedRecipe.Id;
            ingredient.FoodItemId = allFoodItems[cbFoodItem.SelectedIndex].Id;
            ingredient.Name = tName.Text;

            if (string.IsNullOrWhiteSpace(tQuantityGrams.Text))
            {
                ingredient.QuantityInGramsOrMl = null;
            }
            else
            {
                if (int.TryParse(tQuantityGrams.Text.Trim(), out int grams))
                {
                    ingredient.QuantityInGramsOrMl = grams;
                }
                else
                {
                    MessageBox.Show($"Invalid input for Quantity in Grams: '{tQuantityGrams.Text}'. Please enter a valid number.");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(tQuantityUnits.Text))
            {
                ingredient.QuantityInPcs = null;
            }
            else
            {
                if (int.TryParse(tQuantityUnits.Text.Trim(), out int units))
                {
                    ingredient.QuantityInPcs = units;
                }
                else
                {
                    MessageBox.Show($"Invalid input for Quantity in Units: '{tQuantityUnits.Text}'. Please enter a valid number.");
                    return false;
                }
            }

            bool result = false;
            try
            {
                result = await ingredientClient.InsertIngredientAsync(ingredient);
                if (result)
                {
                    MessageBox.Show("Added successfully");
                    
                }
                else
                {
                    MessageBox.Show("Adding failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }
            return result;
        }
    }
}
