using Client_FrontEnd.Clients;
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
    /// <summary>
    /// Interaction logic for ManageFoodItemsPage.xaml
    /// </summary>
    /// 
    public partial class ManageFoodItemsPage : Page
    {
        public static FoodItemClient foodClient = new FoodItemClient();
        public ManageFoodItemsPage()
        {
            InitializeComponent();
            DataGridInitializer();
        }
        private async void DataGridInitializer()
        {
            List<FoodItem> allFoodItems = await foodClient.GetAllFoodItemsAsync();
            foodData.ItemsSource = allFoodItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddFoodItemWindow window = new AddFoodItemWindow();
            window.Show();

        }

        private void foodData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (foodData.SelectedItem is FoodItem selectedFoodItem)
            {
                UpdateOrDeleteFoodItemWindow window = new UpdateOrDeleteFoodItemWindow(selectedFoodItem);
                window.Show();
            }
        }
    }
}
