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
    /// Interaction logic for WindowAuthorsAdd.xaml
    /// </summary>
    public partial class WindowAuthorsAdd : Window
    {
        public WindowAuthorsAdd()
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

        private void ButtonAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            if(AuthorFirstName.Text != String.Empty && AuthorSurname.Text != String.Empty)
            {
                var newAuthor = new Author
                {
                    FirstName = AuthorFirstName.Text,
                    Surname = AuthorSurname.Text
                };

                Author.Add(newAuthor);
                AuthorsViewModel.AuthorList.Add(newAuthor);
                ViewModels.Update();

                Close();
            }
            else
            {
                Close();
                MessageBox.Show($"Nieudało się dodać nowego autora! Niepodano niektórych danych");
            }
        }
    }
}
