using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET_14040.Data;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly BookStoreDbContext _context;
        /// <summary>
        /// zapisywanie do bazy konturkotr tworzy nową tabele
        /// </summary>
        public AuthorsController(BookStoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// dodanie authora do bazy
        /// </summary>
        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        /// <summary>
        /// usuwanie authora z bazy
        /// </summary>
        public void DeleteAuthor(int id)
        {
            var result = _context.Authors.FirstOrDefault(n => n.Id == id);
            _context.Authors.Remove(result);
            _context.SaveChanges();
        }
        /// <summary>
        /// lista wszystkich autorów
        /// </summary>
        public IEnumerable<Author> getAll()
        {
            var result = _context.Authors.ToList();
            return result;
        }
        /// <summary>
        /// szukanie authora po id
        /// </summary>
        public Author GetByid(int id)
        {
            var result = _context.Authors.FirstOrDefault(n => n.Id == id);
            return result;
        }
        /// <summary>
        /// akutaliacja danych dla authora
        /// </summary>
        public Author Update(int id, Author newAuthor)
        {
            _context.Update(newAuthor);
            _context.SaveChanges();
            return newAuthor;

        }
        /// <summary>
        /// zwraca liste wszystkich autorów
        /// </summary>
        public IActionResult Index()
        {
            var data = getAll();
            return View(data);
        }
        //Get Request: Author/Create

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        /// <summary>
        ///tutaj jest wysyłany przez formularz Author i sprawdzany czy jest poprawny 
        /// </summary>
        //Bind które pola mają być wysłane 
        public IActionResult Create([Bind("FullName,ProfilePicture,Bio")] Author author)
        {
            //sprawdza Validatons
            if (ModelState.IsValid)
            {
                Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        //Get: Author/Details/id
        ///  <summary>
        /// zwracane details dla autora z danym id
        /// </summary>
        public IActionResult Details(int id)
        {
            var authorDetails = GetByid(id);
            if (authorDetails == null)
            {
                return View("NotFound");
            }
            return View(authorDetails);
        }
        //Get Request: Author/Edit
        ///  <summary>
        /// edytowanie dla autora z danym id
        /// </summary>
        public IActionResult Edit(int id)
        {
            var authorDetails = GetByid(id);
            if (authorDetails == null)
            {
                return View("NotFound");
            }
            return View(authorDetails);
        }
        [HttpPost]
        //Bind które pola mają być edytowane 
        ///  <summary>
        /// tutaj jest edytowany przez formularz Author i sprawdzany czy jest poprawny
        /// </summary>
        public IActionResult Edit([Bind("FullName,ProfilePicture,Bio")] Author author, int id)
        {
            //sprawdza Validatons
            if (ModelState.IsValid)
            {
                Update(id, author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        //Get Request: author/Delete
        ///   <summary>
        /// usuwanie dla autora z danym id
        /// </summary>
        public IActionResult Delete(int id)
        {
            var authorDetails = GetByid(id);
            if (authorDetails == null)
            {
                return View("NotFound");
            }
            return View(authorDetails);

        }
        [HttpPost, ActionName("Delete")]
        //Bind które pola mają być wysłane 
        ///  <summary>
        /// formularz czy jesteś pewny usunięcia
        /// </summary>
        public IActionResult DeleteConfirmed(int id)
        {
            var authorDetails = GetByid(id);
            if (authorDetails == null)
            {
                return View("NotFound");
            }
            DeleteAuthor(id);

            return RedirectToAction(nameof(Index));

        }
    }

}
