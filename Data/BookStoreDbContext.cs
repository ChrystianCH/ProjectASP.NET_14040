

using Microsoft.EntityFrameworkCore;

namespace ProjectASP.NET_14040.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {

        }
            }
}
