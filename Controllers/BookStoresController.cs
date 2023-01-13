using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET_14040.Data;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Controllers
{
    public class BookStoresController : Controller
    {
        private readonly BookStoreDbContext _context;
      
        public BookStoresController(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Add(BookStore bookStore)
        {

        }
        public void Delete(int id)
        {

        }
        public IEnumerable<BookStore> getAll()
        {
            var result = _context.BookStores.ToList();
            return result;
        }
        public BookStore GetByid(int id)
        {
            throw new NotImplementedException();

        }
        public BookStore Update(int id, BookStore newbookStore)
        {
            throw new NotImplementedException();

        }
        //Get : Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            var data = getAll();
            return View(data);
        }
    }
}
