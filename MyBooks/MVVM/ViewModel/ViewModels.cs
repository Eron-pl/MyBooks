using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.MVVM.ViewModel
{
    public static class ViewModels
    {
        public static void Update()
        {
            BooksViewModel.Update();
            CategoriesViewModel.Update();
            AuthorsViewModel.Update();
        }
    }
}
