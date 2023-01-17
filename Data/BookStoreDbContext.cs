

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Data
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// konstruktor dziedziczący z IndetityDbContext
        ///  </summary>
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {

        }
        /// <summary>
        ///Łącząca  tablica dla BookStore_Book
        ///  </summary>
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// <summary>
            ///Wskazanie dla translatora 
            ///  </summary>
            modelBuilder.Entity<BookStore_Book>().HasKey(bs =>
            new
            {
                bs.BookId,
                bs.BookStoreId
            });
            /// <summary>
            /// Generowanie domyślnych wskazań dla tablicy
            /// </summary>

            modelBuilder.Entity<BookStore_Book>().HasOne(b => b.Book).WithMany(bs => bs.BookStore_Books).HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookStore_Book>().HasOne(b => b.BookStore).WithMany(bs => bs.BookStore_Books).HasForeignKey(b => b.BookStoreId);
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// Tworzenie nowych tablicy dla bazy
        /// </summary>
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
       
        public DbSet<BookStore_Book> BookStores_Books { get; set; }

        public DbSet<Author> Authors { get; set; }
     
    }
}
