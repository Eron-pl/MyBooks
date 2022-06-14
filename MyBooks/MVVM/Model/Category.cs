using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MyBooks.MVVM.Model
{
    public class Category
    {
        public Category()
        {
            Books = new List<Book>();
        }

        public int CategoryID { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }


        public static List<Category> GetCategories()
        {
            using (Context context = new Context())
            {
                var categories = context.Categories.ToList();

                foreach (var category in categories)
                {
                   category.Books = context.Books.Where(b => b.Categories.Any(c => c.CategoryID == category.CategoryID)).ToList();
                }

                return categories;
            }
        }

        public static void Add(Category newCategory)
        {
            try
            {
                using (Context context = new Context())
                {
                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}