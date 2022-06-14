using MyBooks.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyBooks.MVVM.ViewModel
{
    public class BooksViewModel
    {
        public static ObservableCollection<Book> BookList;

        public BooksViewModel()
        {
            BookList = new ObservableCollection<Book>();
            foreach (var item in Book.GetBooks())
            {
                BookList.Add(item);
            }
        }

        public static void Update()
        {
            BookList.Clear();
            foreach (var item in Book.GetBooks())
            {
                BookList.Add(item);
            }
        }
    }
}
