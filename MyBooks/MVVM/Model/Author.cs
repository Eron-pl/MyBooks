using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.MVVM.Model
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ICollection<Book> Books { get; set; }

        public static List<Author> GetAuthors()
        {
            using (Context context = new Context())
            {
                var authors = context.Authors.ToList();

                foreach (var author in authors)
                {
                    author.Books = context.Books.Where(b => b.AuthorID == author.AuthorID).ToList();
                }

                return authors;
            }
        }

        public static void Add(Author newAuthor)
        {
            try
            {
                using (Context context = new Context())
                {
                    context.Authors.Add(newAuthor);
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
