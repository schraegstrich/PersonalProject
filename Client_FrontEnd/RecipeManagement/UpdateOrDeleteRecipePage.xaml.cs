using Client_FrontEnd.Clients;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Models;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client_FrontEnd
{
    /// <summary>
    /// Interaction logic for UpdateOrDeleteRecipePage.xaml
    /// </summary>
    public partial class UpdateOrDeleteRecipePage : Page
    {
        public static Recipe recipe = new Recipe();
        private static RecipeClient recipeClient = new RecipeClient();
        private static IngredientClient ingredientClient = new IngredientClient();

        public UpdateOrDeleteRecipePage(Recipe recipeToAmend)
        {
            InitializeComponent();
            recipe = recipeToAmend;
            ContentInitializer();
        }

        public async void ContentInitializer()
        {
            tName.Text = recipe.Name;
            tDescription.Text = recipe.Description;
            tCookingTime.Text = recipe.CookingTimeInMinutes.ToString();
            List<Ingredient> ingredients = await ingredientClient.GetIngredientsByRecipeId(recipe.Id);
            ingredientsData.ItemsSource = ingredients;
        }

        private void ingredientsData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOrDeleteIngredientWindow window = new UpdateOrDeleteIngredientWindow((Ingredient)ingredientsData.SelectedItem);
            window.Show();
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {

            bool result = await RecipeUpdater();
            //if (result)
                //Window.GetWindow((Button)sender).Close();
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await RecipeDeleter();
            //if (result)
                //Window.GetWindow((Button)sender).Close();

        }

        private async Task<bool> RecipeUpdater()
        {
            Recipe updatedRecipe = new Recipe
            {
                Id = recipe.Id,
                Name = tName.Text,
                Description = tDescription.Text,
                CookingTimeInMinutes = Convert.ToInt32(tCookingTime.Text)
            };
            bool result = new bool(); 
            try
            {
                result = await recipeClient.UpdateRecipeAsync(updatedRecipe);
                if (result)
                {
                    MessageBox.Show("Updated successfully");
                }
                else
                {
                    MessageBox.Show("Update failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }
            return result;    
        }

        private async Task<bool> RecipeDeleter()
        {
            bool result = new bool();
            try
            {
                result = await recipeClient.DeleteRecipeAsync(recipe.Id);
                if (result)
                {
                    MessageBox.Show("Deleted successfully");
                    //Window.GetWindow((Button)sender).Close();
                }
                else
                {
                    MessageBox.Show("Deleting failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }
            return result;
        }

        private void addIngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            AddIngredientWindow window = new AddIngredientWindow(recipe);
            window.Show();
        }
    }
}
