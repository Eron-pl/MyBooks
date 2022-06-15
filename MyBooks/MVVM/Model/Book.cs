using MyBooks.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.MVVM.Model
{
    public class Book
    {
        public Book()
        {
            Categories = new List<Category>();
        }
        public int BookID { get; set; }
        public string Title { get; set; }
        public int? Rating { get; set; }
        public bool Status { get; set; }
        public ICollection<Category> Categories { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public static List<Book> GetBooks()
        {
            using (Context context = new Context())
            {
                var books = context.Books.OrderBy(b => b.Author.FirstName).ToList();

                foreach (var book in books)
                {
                    var author = context.Authors.Where(a => a.AuthorID == book.AuthorID).First();
                    book.Author = author;
                }

                return books;
            }
        }
    }
}
