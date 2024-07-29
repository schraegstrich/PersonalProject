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
using Models;
using Client_FrontEnd.Clients;

namespace Client_FrontEnd
{
    /// <summary>
    /// Interaction logic for AddFoodItemPage.xaml
    /// </summary>
    public partial class AddFoodItemWindow : Window
    {
        public static FoodItem foodItem = new FoodItem();
        public static FoodItemClient foodClient = new FoodItemClient();
        public static List<FoodItem> allFoodItems = new List<FoodItem>();
        public AddFoodItemWindow()
        {
            InitializeComponent();
            List<string> position = new List<string>();

            foreach (FoodItem.Position option in Enum.GetValues(typeof(FoodItem.Position)))
            {
                position.Add(option.ToString());
            }
            cbPosition.ItemsSource = position;

        }

        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await FoodItemInserter();
            if(result)
                Window.GetWindow((Button)sender).Close();

        }

        private async Task<bool> FoodItemInserter()
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
            if (allFoodItems.FirstOrDefault(f => f.Shelf == foodItem.Shelf && f.PositionOnShelf == foodItem.PositionOnShelf) != null)
            {
                MessageBox.Show("messageBoxText: This position is not empty, please change position");
                return false;
            }

            bool result = new bool();
            try
            {
                result = await foodClient.InsertFoodItemAsync(foodItem);
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

