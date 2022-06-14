using MyBooks.MVVM.Model;
using MyBooks.MVVM.View;
using MyBooks.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace MyBooks.Windows
{
    /// <summary>
    /// Interaction logic for WindowBooksAdd.xaml
    /// </summary>
    public partial class WindowBooksAdd : Window
    {
        public WindowBooksAdd()
        {
            InitializeComponent();

            BookAuthor.ItemsSource = Author.GetAuthors();

            var categoriesList = Category.GetCategories();

            ThicknessConverter tc = new ThicknessConverter();
            var chkMargin = tc.ConvertFromString("0 5 0 5");

            foreach (var cat in categoriesList)
                AddCategories.Children.Add(new CheckBox { Content = cat.Name, Margin = (Thickness)chkMargin });

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

        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            var categoriesCheckBoxes = new List<String>();
            foreach (CheckBox cb in AddCategories.Children.OfType<CheckBox>())
            {
                if (cb.IsChecked == true)
                    categoriesCheckBoxes.Add(cb.Content.ToString());
            }

            if (BookTitle.Text != String.Empty && BookAuthor.SelectedIndex > -1 && BookStatus.SelectedIndex > -1 
                    && categoriesCheckBoxes.Count > 0)
            {
                var status = BookStatus.SelectedItem.ToString();
                bool bookStatus;

                if (status == "System.Windows.Controls.ComboBoxItem: Tak")
                    bookStatus = true;
                else
                    bookStatus = false;

                

                using (var context = new Context())
                {
                    var autor = context.Authors.Where(a => a.AuthorID == Convert.ToInt32(BookAuthor.SelectedValue)).ToList();

                    var newBook = new Book
                    {
                        Title = BookTitle.Text,
                        Status = bookStatus,
                        AuthorID = Convert.ToInt32(BookAuthor.SelectedValue),
                        Author = autor[0]
                    };

                    if (BookRating.Text != String.Empty)
                        newBook.Rating = Convert.ToInt32(BookRating.Text);
                    else
                        newBook.Rating = null;

                   var categories = context
                        .Categories
                        .Where(c => categoriesCheckBoxes.Contains(c.Name));

                    foreach (var category in categories)
                        newBook.Categories.Add(category);

                    context.Books.Add(newBook);
                    context.SaveChanges();

                    BooksViewModel.BookList.Add(newBook);
                    ViewModels.Update();
                };
                Close();
            }
            else
            {
                Close();
                MessageBox.Show($"Nieudało się dodać nowej książki! Niepodano niektórych danych");
            }
        }
    }


}
