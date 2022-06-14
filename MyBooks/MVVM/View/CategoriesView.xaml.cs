using MyBooks.MVVM.Model;
using MyBooks.MVVM.ViewModel;
using MyBooks.Windows;
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

namespace MyBooks.MVVM.View
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        public CategoriesView()
        {
            InitializeComponent();

            dgCategories.ItemsSource = CategoriesViewModel.CategoryList;
        }

        private void ButtonAddCategory_Click(object sender, RoutedEventArgs e)
        {
            WindowCategoriesAdd wca = new WindowCategoriesAdd();
            wca.Show();
        }

        private void ButtonRemoveCategories_Click(object sender, RoutedEventArgs e)
        {
            List<Category> selectedCategories = dgCategories.SelectedItems.Cast<Category>().ToList();

            if (selectedCategories.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Czy napewno chcesz usunąć zaznaczone kategorie?", "Uwaga!", MessageBoxButton.YesNo);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        using (var context = new Context())
                        {
                            foreach (var category in selectedCategories)
                            {
                                context.Categories.Remove(category);
                                CategoriesViewModel.CategoryList.Remove(category);
                            }
                            context.SaveChanges();
                            ViewModels.Update();
                        }
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnej kategorii");
            }
        }
    }
}
