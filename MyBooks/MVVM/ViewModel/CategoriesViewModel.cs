using MyBooks.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.MVVM.ViewModel
{
    public class CategoriesViewModel
    {
        public static ObservableCollection<Category> CategoryList;

        public CategoriesViewModel()
        {
            CategoryList = new ObservableCollection<Category>();
            foreach (var item in Category.GetCategories())
            {
                CategoryList.Add(item);
            }
        }

        public static void Update()
        {
            CategoryList.Clear();
            foreach (var item in Category.GetCategories())
            {
                CategoryList.Add(item);
            }
        }
    }
}
