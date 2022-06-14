using MyBooks.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.MVVM.ViewModel
{
    public class AuthorsViewModel
    {
        public static ObservableCollection<Author> AuthorList;

        public AuthorsViewModel()
        {
            AuthorList = new ObservableCollection<Author>();
            foreach (var item in Author.GetAuthors())
            {
                AuthorList.Add(item);
            }
        }

        public static void Update()
        {
            AuthorList.Clear();
            foreach (var item in Author.GetAuthors())
            {
                AuthorList.Add(item);
            }
        }
    }
}
