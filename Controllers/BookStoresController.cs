using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET_14040.Data;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Controllers
{
    public class BookStoresController : Controller
    {
        private readonly BookStoreDbContext _context;
        /// <summary>
        /// zapisywanie do bazy konturkotr tworzy nową tabele
        /// </summary>
        public BookStoresController(BookStoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// dodanie biblioteki do bazy
        /// </summary>
        public void Add(BookStore bookStore)
        {
            _context.BookStores.Add(bookStore);
            _context.SaveChanges();
        }
        /// <summary>
        /// usuwanie biblioteki z bazy
        /// </summary>
        public void DeleteBookStore(int id)
        {
            var result = _context.BookStores.FirstOrDefault(n => n.Id == id);
            _context.BookStores.Remove(result);
            _context.SaveChanges();
        }
        /// <summary>
        /// lista wszystkich bibliotek
        /// </summary>
        public IEnumerable<BookStore> getAll()
        {
            var result = _context.BookStores.ToList();
            return result;
        }
        /// <summary>
        /// zwrócenie biblioteki po id
        /// </summary>
        public BookStore GetByid(int id)
        {
            var result = _context.BookStores.FirstOrDefault(n => n.Id == id);
            return result;
        }
        /// <summary>
        /// akutaliacja danych dla biblioteki
        /// </summary>
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
        //  <summary>
        // tutaj jest wysyłany przez formularz biblioteki i sprawdzany czy jest poprawny
        // </summary>
        public IActionResult Create([Bind("Name,BookStoreLogo,Description")]BookStore bookStore)
        {
            //sprawdza Validatons
            if (ModelState.IsValid)
            {
                Add(bookStore);
                return RedirectToAction(nameof(Index));
            }
            return View(bookStore);
        }
        //Get: Bookstore/Details/id
        //   <summary>
        // zwracane details dla autora z danym id
        // </summary>
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
        ///  <summary>
        /// edytowanie dla autora z danym id
        /// </summary>
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
        ///  <summary>
        /// tutaj jest edytowany przez formularz Author i sprawdzany czy jest poprawny
        /// </summary> 
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
        //Get Request: BookStore/Delete
        ///   <summary>
        /// usuwanie dla autora z danym id
        /// </summary>
        public IActionResult Delete(int id)
        {
            var bookstoreDetails = GetByid(id);
            if (bookstoreDetails == null)
            {
                return View("NotFound");
            }
            return View(bookstoreDetails);
          
        }
        [HttpPost, ActionName("Delete")]
        //Bind które pola mają być wysłane 
        //   <summary>
        // formularz czy jesteś pewny usunięcia
        // </summary>
        public IActionResult DeleteConfirmed(int id)
        {
            var bookstoreDetails = GetByid(id);
            if (bookstoreDetails == null)
            {
                return View("NotFound");
            }
            DeleteBookStore(id);
          
            return RedirectToAction(nameof(Index));
            
            
        }
    }
}
