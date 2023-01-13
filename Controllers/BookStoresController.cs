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
            _context.BookStores.Add(bookStore);
            _context.SaveChanges();
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
      
        public IActionResult Index()
        {
            var data = getAll();
            return View(data);
        }
        //Get Request: BookStore/Create

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //Bind które pola mają być wysłane 
        public IActionResult Create([Bind("Name,BookStoreLogo,Description")]BookStore bookStore)
        {
            //sprawdza Validatons
            if (ModelState.IsValid)
            {
                _context.Add(bookStore);
                return RedirectToAction(nameof(Index));
            }
            return View(bookStore);
        }
    }
}
