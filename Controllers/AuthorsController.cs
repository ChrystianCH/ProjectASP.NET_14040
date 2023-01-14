using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET_14040.Data;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly BookStoreDbContext _context;

        public AuthorsController(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public void DeleteAuthor(int id)
        {
            var result = _context.Authors.FirstOrDefault(n => n.Id == id);
            _context.Authors.Remove(result);
            _context.SaveChanges();
        }
        public IEnumerable<Author> getAll()
        {
            var result = _context.Authors.ToList();
            return result;
        }
        public Author GetByid(int id)
        {
            var result = _context.Authors.FirstOrDefault(n => n.Id == id);
            return result;
        }
        public Author Update(int id, Author newAuthor)
        {
            _context.Update(newAuthor);
            _context.SaveChanges();
            return newAuthor;

        }

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
        //Bind które pola mają być wysłane 
        public IActionResult Create([Bind("FullName,ProfilePicture,Bio")] Author author)
        {
            //sprawdza Validatons
            if (ModelState.IsValid)
            {
                _context.Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        //Get: Author/Details/id
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
