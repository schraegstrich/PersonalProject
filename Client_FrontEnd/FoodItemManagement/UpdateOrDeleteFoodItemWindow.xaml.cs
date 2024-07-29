using Client_FrontEnd.Clients;
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
using System.Windows.Shapes;
using static Models.FoodItem;

namespace Client_FrontEnd
{
    /// <summary>
    /// Interaction logic for UpdateOrDeleteFoodItemWindow.xaml
    /// </summary>
    public partial class UpdateOrDeleteFoodItemWindow : Window
    {
        public static FoodItem foodItem = new FoodItem();
        public static FoodItemClient foodClient = new FoodItemClient();
        public static List<FoodItem> allFoodItems = new List<FoodItem>();
        public UpdateOrDeleteFoodItemWindow(FoodItem foodToAmend)
        {
            foodItem = foodToAmend;
            InitializeComponent();
            ContentInitializer();
        }

        private async void ContentInitializer()
        {
            List<string> position = new List<string>();

            foreach (FoodItem.Position option in Enum.GetValues(typeof(FoodItem.Position)))
            {
                position.Add(option.ToString());
            }
            cbPosition.ItemsSource = position;
            tName.Text = foodItem.Name;
            tLink.Text = foodItem.Link;
            if (foodItem.QuantityInPackInGramsOrMl != null)
                tQuantityPackage.Text = foodItem.QuantityInPackInGramsOrMl.ToString();
            if (foodItem.QuantityInPcs != null)
                tQuantityUnits.Text = foodItem.QuantityInPcs.ToString();
            tShelf.Text = foodItem.Shelf.ToString();
            cbPosition.SelectedIndex = (int)foodItem.PositionOnShelf;
        }

        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await FoodItemUpdater();
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await FoodItemDeleter();
            if(result)
                Window.GetWindow((Button)sender).Close();
        }

        private async Task<bool> FoodItemUpdater()
        {
            foodItem.Name = tName.Text;
            foodItem.Link = tLink.Text;
            if (string.IsNullOrWhiteSpace(tQuantityPackage.Text))
            {
                foodItem.QuantityInPackInGramsOrMl = null;
            }
            else
            {
                if (int.TryParse(tQuantityPackage.Text.Trim(), out int grams))
                {
                    foodItem.QuantityInPackInGramsOrMl = grams;
                }
                else
                {
                    MessageBox.Show($"Invalid input for Quantity in Grams: '{tQuantityPackage.Text}'. Please enter a valid number.");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(tQuantityUnits.Text))
            {
                foodItem.QuantityInPcs = null;
            }
            else
            {
                if (int.TryParse(tQuantityUnits.Text.Trim(), out int units))
                {
                    foodItem.QuantityInPcs = units;
                }
                else
                {
                    MessageBox.Show($"Invalid input for Quantity in Units: '{tQuantityUnits.Text}'. Please enter a valid number.");
                    return false;
                }
            }
            foodItem.Shelf = Convert.ToInt32(tShelf.Text);
            foodItem.PositionOnShelf = (FoodItem.Position)(int)cbPosition.SelectedIndex;

            allFoodItems = await foodClient.GetAllFoodItemsAsync();
            if (allFoodItems.FirstOrDefault(f => f.Shelf == foodItem.Shelf && f.PositionOnShelf == foodItem.PositionOnShelf && f.Id != foodItem.Id) != null)
            {
                MessageBox.Show("messageBoxText: This position is not empty, please change position");
                return false;
            }

            bool result = new bool();
            try
            {
                result = await foodClient.UpdateFoodItemAsync(foodItem);
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

        private async Task<bool> FoodItemDeleter()
        {
            bool result = new bool();
            try
            {
                result = await foodClient.DeleteFoodItemAsync(foodItem.Id);
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

    }
}
