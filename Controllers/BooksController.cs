using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectASP.NET_14040.Data;

namespace ProjectASP.NET_14040.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookStoreDbContext _context;

        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Books.Include(name => name.BookStore_Books).Include(name => name.Author).OrderBy(n=> n.Name).ToList();

            return View(data);
        }
    }
}
