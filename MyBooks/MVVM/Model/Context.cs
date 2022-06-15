using Microsoft.EntityFrameworkCore;
using MyBooks.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.MVVM.Model
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"Server={ConnectionString.Address};Database=MyBooks;Trusted_Connection=True");
        }
    
    }
}
