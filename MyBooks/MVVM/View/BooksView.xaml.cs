using MyBooks.MVVM.Model;
using MyBooks.MVVM.ViewModel;
using MyBooks.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for BooksView.xaml
    /// </summary>
    public partial class BooksView : UserControl
    {
        public BooksView()
        {
            InitializeComponent();

            dgBooks.ItemsSource = BooksViewModel.BookList;
        }

        private void ButtonAddBooks_Click(object sender, RoutedEventArgs e)
        {
            WindowBooksAdd wba = new WindowBooksAdd();
            wba.Show();
        }

        private void ButtonRemoveBooks_Click(object sender, RoutedEventArgs e)
        {
            List<Book> selectedBooks = dgBooks.SelectedItems.Cast<Book>().ToList(); 

            if(selectedBooks.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Czy napewno chcesz usunąć zaznaczone książki?", "Uwaga!", MessageBoxButton.YesNo);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        using (var context = new Context())
                        {
                            foreach (var book in selectedBooks)
                            {
                                context.Books.Remove(book);
                                BooksViewModel.BookList.Remove(book);
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
                MessageBox.Show("Nie wybrano żadnej książki");
            }
        }
    }
}
