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

namespace Client_FrontEnd
{
    /// <summary>
    /// Interaction logic for UpdateOrDeleteIngredientWindow.xaml
    /// </summary>
    public partial class UpdateOrDeleteIngredientWindow : Window
    {
        public static Ingredient ingredient =new Ingredient();
        public UpdateOrDeleteIngredientWindow(Ingredient ingredientToAmend)
        {
            InitializeComponent();
            ingredient = ingredientToAmend;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
             
        }
    }
}
