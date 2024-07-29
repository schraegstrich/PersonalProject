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
    /// Interaction logic for ManageRecipiesPage.xaml
    /// </summary>
    public partial class ManageRecipiesPage : Page
    {
        private static RecipeClient _client = new RecipeClient();
        public ManageRecipiesPage()
        {
            InitializeComponent();
            DataGridInitializer();
        }

        public async void DataGridInitializer()
        {
            List<Recipe> recipes = await _client.GetAllRecipesAsync();
            recipesData.ItemsSource = recipes;
        }

        private void recipesData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOrDeleteRecipePage page = new UpdateOrDeleteRecipePage((Recipe)recipesData.SelectedItem);
            NavigationService.Navigate(page);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow window = new AddRecipeWindow();
            window.Show();

        }
    }
}
