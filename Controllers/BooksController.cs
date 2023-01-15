using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectASP.NET_14040.Data;
using ProjectASP.NET_14040.Data.ViewModels;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookStoreDbContext _context;
        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var result = _context.Books.FirstOrDefault(n => n.Id == id);
            _context.Books.Remove(result);
            _context.SaveChanges();
        }
        public Book GetBookById(int id)
        {
            var bookDetails =  _context.Books
                .Include(p => p.Author)
                .Include(am => am.BookStore_Books).ThenInclude(a => a.Book)
                .FirstOrDefault(n => n.Id == id);

            return bookDetails;
        }
        public IEnumerable<Book> GetAll() =>  _context.Books.ToList();
        public IEnumerable<Book> getAll()
        {
            var result = _context.Books.ToList();
            return result;
        }
        public Book GetByid(int id)
        {
            var result = _context.Books.FirstOrDefault(n => n.Id == id);
            return result;
        }
        public Book Update(int id, Book newBook)
        {
            _context.Update(newBook);
            _context.SaveChanges();
            return newBook;

        }
        public NewBookDropdownsVM GetNewMovieDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
              
                BookStores =  _context.BookStores.OrderBy(n => n.Name).ToList(),
                Authors = _context.Authors.OrderBy(n => n.FullName).ToList()
            };

            return response;
        }
        public async Task AddNewBook(NewBookVm data)
        {
            var newbook = new Book()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                Image = data.Image,
                StartDate = data.StartDate,

                BookCategory = data.BookCategory,
                AuthorId = data.AuthorId
            };
            _context.Books.Add(newbook);
            _context.SaveChanges();
        }
    
    public IActionResult Index()
        {
            var data = _context.Books.Include(name => name.BookStore_Books).Include(name => name.Author).OrderBy(n=> n.Name).ToList();

            return View(data);
        }
        //GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our store";
            ViewBag.Description = "This is the store description";
            var bookDropdownsData =GetNewMovieDropdownsValues();

            ViewBag.BookStores = new SelectList(bookDropdownsData.BookStores, "Id", "Name");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");
          
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewBookVm book)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData =  GetNewMovieDropdownsValues();

      
                ViewBag.Authors = new SelectList(movieDropdownsData.Authors, "Id", "FullName");
                ViewBag.BookStores = new SelectList(movieDropdownsData.BookStores, "Id", "Name");

                return View(book);
            }

            AddNewBook(book);
            return RedirectToAction(nameof(Index));
        }
    }
    }



