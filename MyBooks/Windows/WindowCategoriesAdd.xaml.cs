using MyBooks.MVVM.Model;
using MyBooks.MVVM.ViewModel;
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

namespace MyBooks.Windows
{
    /// <summary>
    /// Interaction logic for WindowCategoriesAdd.xaml
    /// </summary>
    public partial class WindowCategoriesAdd : Window
    {
        public WindowCategoriesAdd()
        {
            InitializeComponent();
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryName.Text != String.Empty) 
            {
                var newCategory = (new Category
                {
                    Name = CategoryName.Text
                });

                Category.Add(newCategory);
                CategoriesViewModel.CategoryList.Add(newCategory);
                ViewModels.Update();

                Close();
            }
            else
            {
                Close();
                MessageBox.Show("Nie udało się dodać nowej kategorii! Niewypełniono niektórych danych");
            }
        }
    }
}
