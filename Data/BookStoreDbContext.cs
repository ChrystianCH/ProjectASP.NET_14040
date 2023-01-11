

using Microsoft.EntityFrameworkCore;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {

        }
        //Joining tablica dla BookStore_Book
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Wskazanie dla translatora 
            modelBuilder.Entity<BookStore_Book>().HasKey(bs =>
            new
            {
                bs.BookId,
                bs.BookStoreId
            });
            //Generowanie defoltowych wskazan dla tablicy
            modelBuilder.Entity<BookStore_Book>().HasOne(b => b.Book).WithMany(bs => bs.BookStore_Books).HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookStore_Book>().HasOne(b => b.BookStore).WithMany(bs => bs.BookStore_Books).HasForeignKey(b => b.BookStoreId);
            base.OnModelCreating(modelBuilder);
        }
        //Określanie nazwy tablic
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
       
        public DbSet<BookStore_Book> BookStore_Book { get; set; }

        public DbSet<Author> Authors { get; set; }
     
    }
}
