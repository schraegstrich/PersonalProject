﻿using System;
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
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        private static RecipeClient _client = new RecipeClient();
        public WelcomePage()
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
            ToCookPage page = new ToCookPage((Recipe)recipesData.SelectedItem);
            NavigationService.Navigate(page);


        }
    }
}
