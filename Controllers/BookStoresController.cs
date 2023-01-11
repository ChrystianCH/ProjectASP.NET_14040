using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET_14040.Data;

namespace ProjectASP.NET_14040.Controllers
{
    public class BookStoresController : Controller
    {
        private readonly BookStoreDbContext _context;
      
        public BookStoresController(BookStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.BookStores.ToList();
            return View();
        }
    }
}
