using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET_14040.Data;

namespace ProjectASP.NET_14040.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookStoreDbContext _context;

        public AuthorsController(BookStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Authors.ToList();

            return View();
        }
    }
}
