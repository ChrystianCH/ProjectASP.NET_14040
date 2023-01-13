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
            var result = _context.BookStores.FirstOrDefault(n => n.Id == id);
            return result;
        }
        public BookStore Update(int id, BookStore newbookStore)
        {
            _context.Update(newbookStore);
            _context.SaveChanges();
            return newbookStore;

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
        //Get: Bookstore/Details/id
        public IActionResult Details(int id)
        {
            var bookstoreDetails = GetByid(id);
            if (bookstoreDetails == null)
            {
                return View("NotFound");
             }
            return View(bookstoreDetails);
        }
        //Get Request: BookStore/Edit

        public IActionResult Edit(int id)
        {
            var bookstoreDetails = GetByid(id);
            if (bookstoreDetails == null)
            {
                return View("NotFound");
            }
            return View(bookstoreDetails);
        }
        [HttpPost]
        //Bind które pola mają być edytowane 
        public IActionResult Edit([Bind("Id,Name,BookStoreLogo,Description")] BookStore bookStore,int id)
        {
            //sprawdza Validatons
            if (ModelState.IsValid)
            {
                Update(id,bookStore);
                return RedirectToAction(nameof(Index));
            }
            return View(bookStore);
        }
    }
}
