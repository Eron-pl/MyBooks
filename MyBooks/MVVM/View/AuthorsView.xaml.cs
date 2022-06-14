using MyBooks.MVVM.Model;
using MyBooks.MVVM.ViewModel;
using MyBooks.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyBooks.MVVM.View
{
    /// <summary>
    /// Interaction logic for AuthorsView.xaml
    /// </summary>
    public partial class AuthorsView : UserControl
    {
        public AuthorsView()
        {
            InitializeComponent();

            dgAuthors.ItemsSource = AuthorsViewModel.AuthorList;
        }

        private void ButtonAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorsAdd waa = new WindowAuthorsAdd();
            waa.Show();
        }

        private void ButtonRemoveAuthors_Click(object sender, RoutedEventArgs e)
        {
            List<Author> selectedAuthors = dgAuthors.SelectedItems.Cast<Author>().ToList();

            if (selectedAuthors.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Czy napewno chcesz usunąć zaznaczonych autorów?", "Uwaga!", MessageBoxButton.YesNo);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        using (var context = new Context())
                        {
                            foreach (var author in selectedAuthors)
                            {
                                context.Authors.Remove(author);
                                AuthorsViewModel.AuthorList.Remove(author);
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
                MessageBox.Show("Nie wybrano żadnego autora!");
            }
        }
    }
}
