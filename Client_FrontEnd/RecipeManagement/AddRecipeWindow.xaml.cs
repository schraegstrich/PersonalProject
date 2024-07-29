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
using Models;

namespace Client_FrontEnd
{
    public partial class AddRecipeWindow : Window
    {
        public static Recipe recipe = new Recipe();
        public static RecipeClient recipeClient = new RecipeClient();
        public AddRecipeWindow()
        {
            InitializeComponent();
        }

        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await RecipeInserter();
            //if (result)
              //  Window.GetWindow((Button)sender).Close();

        }

        private async void ingredientsButton_Click(object sender, RoutedEventArgs e)
        {
            if (recipe == null)
                MessageBox.Show("Please add recipe first");
            else
            {
                AddIngredientWindow window = new AddIngredientWindow(recipe);
                window.Show();

            }
           

        }

        private async Task<bool> RecipeInserter()
        {
            recipe.Name = tName.Text;
            recipe.Description = tDescription.Text;
            recipe.CookingTimeInMinutes = Convert.ToInt32(tCookingTime.Text);
            bool result = new bool();
            try
            {
                result = await recipeClient.InsertRecipeAsync(recipe);
                if (result)
                {
                    MessageBox.Show("Added successfully");
                    //Window.GetWindow((Button)sender).Close();
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
