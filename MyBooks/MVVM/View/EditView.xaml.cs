using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyBooks.MVVM.View
{
    /// <summary>
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        public EditView()
        {
            InitializeComponent();

            // Edit Book
            EditCBBooks.ItemsSource = BooksViewModel.BookList;
            EditCBBooks.DisplayMemberPath = "Title";

            EditCBBooksAuthors.ItemsSource = AuthorsViewModel.AuthorList;

            var categoriesList = CategoriesViewModel.CategoryList;

            ThicknessConverter tc = new ThicknessConverter();
            var chkMargin = tc.ConvertFromString("0 5 0 5");

            foreach (var cat in categoriesList)
                EditBookCategories.Children.Add(new CheckBox { Content = cat.Name, Margin = (Thickness)chkMargin });

            // Edit Author
            EditCBAuthors.ItemsSource = AuthorsViewModel.AuthorList;

            var bookList = BooksViewModel.BookList;

            ThicknessConverter tc2 = new ThicknessConverter();
            var chkMargin2 = tc.ConvertFromString("0 5 0 5");

            foreach (var book in bookList)
                EditAuthorBooks.Children.Add(new CheckBox { Content = book.Title, Margin = (Thickness)chkMargin2 });

            // Edit Category
            EditCBCategories.ItemsSource = CategoriesViewModel.CategoryList;

            var bookList2 = BooksViewModel.BookList;

            ThicknessConverter tc3 = new ThicknessConverter();
            var chkMargin3 = tc.ConvertFromString("0 5 0 5");

            foreach (var book in bookList2)
                EditCategoryBooks.Children.Add(new CheckBox { Content = book.Title, Margin = (Thickness)chkMargin3 });
        }

        private void ButtonEditBook_Click(object sender, RoutedEventArgs e)
        {
            var categoriesCheckBoxes = new List<String>();
            foreach (CheckBox cb in EditBookCategories.Children.OfType<CheckBox>())
            {
                if (cb.IsChecked == true)
                    categoriesCheckBoxes.Add(cb.Content.ToString());
            }

            if (EditCBBooks.SelectedIndex > -1 && EditBookTitle.Text != String.Empty && EditCBBooks.SelectedIndex > -1
                && EditCBBooksRead.SelectedIndex > -1 && EditBookRating.Text != String.Empty && categoriesCheckBoxes.Count > 0)
            {
                using (var context = new Context())
                {
                    var autor = context.Authors.Where(a => a.AuthorID == Convert.ToInt32(EditCBBooksAuthors.SelectedValue)).First();
                    var bookStatus = (EditCBBooksRead.SelectedItem.ToString() == "System.Windows.Controls.ComboBoxItem: Tak" ? true : false);
                    var categories = context
                        .Categories
                        .Where(c => categoriesCheckBoxes.Contains(c.Name))
                        .ToList();

                    var bookToUpdate = context.Books
                        .Include(b => b.Categories)
                        .FirstOrDefault(b => b.BookID == Convert.ToInt32(EditCBBooks.SelectedValue));

                    bookToUpdate.Title = EditBookTitle.Text;
                    bookToUpdate.Rating = Convert.ToInt32(EditBookRating.Text);
                    bookToUpdate.Status = bookStatus;
                    bookToUpdate.AuthorID = Convert.ToInt32(EditCBBooksAuthors.SelectedValue);
                    bookToUpdate.Author = autor;
                    bookToUpdate.Categories = categories;

                    context.Books.Update(bookToUpdate);
                    context.SaveChanges();

                    ViewModels.Update();

                    MessageBox.Show("Udało się zmienić dane.");
                }
            }
            else
            {
                MessageBox.Show("Nie udało sie zmienić danych! Nie wypełniono niektórych pól");
            }

        }

        private void ButtonEditAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (EditCBAuthors.SelectedIndex > -1 && EditAuthorName.Text != String.Empty && EditAuthorSurname.Text != String.Empty)
            {
                using (var context = new Context())
                {
                    var booksCheckBoxes = new List<String>();
                    foreach (CheckBox cb in EditAuthorBooks.Children.OfType<CheckBox>())
                    {
                        if (cb.IsChecked == true)
                            booksCheckBoxes.Add(cb.Content.ToString());
                    }

                    var editedAuthor = new Author
                    {
                        AuthorID = Convert.ToInt32(EditCBAuthors.SelectedValue),
                        FirstName = EditAuthorName.Text,
                        Surname = EditAuthorSurname.Text,
                    };

                    if (booksCheckBoxes.Count > 0)
                    {
                        var books = context
                        .Books
                        .Where(b => booksCheckBoxes.Contains(b.Title)).ToList();

                        editedAuthor.Books = books;
                    }

                    context.Authors.Update(editedAuthor);
                    context.SaveChanges();

                    ViewModels.Update();

                }
            }
            else
            {
                MessageBox.Show("Nie udało sie zmienić danych! Nie wypełniono niektórych pól");
            }
        }

        private void ButtonEditCategory_Click(object sender, RoutedEventArgs e)
        {
            var booksCheckBoxes = new List<String>();
            foreach (CheckBox cb in EditCategoryBooks.Children.OfType<CheckBox>())
            {
                if (cb.IsChecked == true)
                    booksCheckBoxes.Add(cb.Content.ToString());
            }

            if (EditCBCategories.SelectedIndex > -1 && EditCategoryName.Text != String.Empty && booksCheckBoxes.Count > 0)
            {
                using (var context = new Context())
                {
                    var categoryToEdit = context
                        .Categories
                        .Include(c => c.Books)
                        .FirstOrDefault(c => c.CategoryID == Convert.ToInt32(EditCBCategories.SelectedValue));

                    var books = context
                        .Books
                        .Where(b => booksCheckBoxes.Contains(b.Title)).ToList();

                    categoryToEdit.Books = books;
                    categoryToEdit.Name = EditCategoryName.Text;

                    context.Categories.Update(categoryToEdit);
                    context.SaveChanges();

                    ViewModels.Update();
                }
            }
            else
            {
                MessageBox.Show("Nie udało sie zmienić danych! Nie wypełniono niektórych pól");
            }
        }
    }
}
