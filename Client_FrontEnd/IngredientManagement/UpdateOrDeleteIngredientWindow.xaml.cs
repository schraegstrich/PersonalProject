using Client_FrontEnd.Clients;
using Models;
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

namespace Client_FrontEnd
{
    /// <summary>
    /// Interaction logic for UpdateOrDeleteIngredientWindow.xaml
    /// </summary>
    public partial class UpdateOrDeleteIngredientWindow : Window
    {
        public static Ingredient ingredient =new Ingredient();
        public static IngredientClient ingredientClient = new IngredientClient();
        public static FoodItemClient foodClient = new FoodItemClient();
        List<FoodItem> allFoodItems = new List<FoodItem>();
        public UpdateOrDeleteIngredientWindow(Ingredient ingredientToAmend)
        {
            InitializeComponent();
            ingredient = ingredientToAmend;
            ContentInitializerAsync();
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await IngredientUpdater();

        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await IngredientDeleter();
            if(result)
                Window.GetWindow((Button)sender).Close();
        }
        public async void ContentInitializerAsync()
        {
           allFoodItems = await foodClient.GetAllFoodItemsAsync();
            List<string> names = new List<string>();

            foreach (var food in allFoodItems)
            {
                names.Add(food.Name);
            }
            cbFoodItem.ItemsSource = names;
            cbFoodItem.SelectedIndex = names.FindIndex(a => a.Contains(allFoodItems.FirstOrDefault(r => r.Id == ingredient.FoodItemId).Name));
            tName.Text = ingredient.Name;
            if (ingredient.QuantityInGramsOrMl != null)
                tQuantityGrams.Text = ingredient.QuantityInGramsOrMl.ToString();
            if (ingredient.QuantityInPcs != null)
                tQuantityUnits.Text = ingredient.QuantityInPcs.ToString();
            
        }

        private async Task<bool>  IngredientDeleter()
        {
            bool result = new bool();
            try
            {
                result = await ingredientClient.DeleteIngredientAsync(ingredient.Id);
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

        private async Task<bool> IngredientUpdater()
        {

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
                    MessageBox.Show("Updateded successfully");

                }
                else
                {
                    MessageBox.Show("Updating failed");
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

