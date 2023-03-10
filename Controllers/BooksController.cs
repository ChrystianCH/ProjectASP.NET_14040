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
        /// <summary>
        /// zapisywanie do bazy konturkotr tworzy nową tabele
        /// </summary>
        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// dodanie ksiązki do bazy
        /// </summary>
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        /// <summary>
        /// usuwanie ksiązki z bazy
        /// </summary>
        public void DeleteBook(int id)
        {
            var result = _context.Books.FirstOrDefault(n => n.Id == id);
            _context.Books.Remove(result);
            _context.SaveChanges();
        }
        /// <summary>
        /// szukanie ksiązki  po id wraz z relacjami
        /// </summary>
        public Book GetBookById(int id)
        {
            var bookDetails =  _context.Books
              .Include(p => p.Author)
              .Include(am => am.BookStore_Books).ThenInclude(a => a.BookStore)
              .FirstOrDefault(n => n.Id == id);

            return bookDetails;
        }
        /// <summary>
        /// lista wszystkich ksiązek
        /// </summary>
        public IEnumerable<Book> GetAll()
        {
            var result = _context.Books.ToList();
            return result;
        }
        /// <summary>
        /// szukanie ksiązki  po id 
        /// </summary>
        public Book GetByid(int id)
        {
            var result = _context.Books.FirstOrDefault(n => n.Id == id);
            return result;
        }
        /// <summary>
        /// akutaliacja danych dla ksiązki
        /// </summary>
        public Book Update(int id, Book newBook)
        {
            _context.Update(newBook);
            _context.SaveChanges();
            return newBook;

        }
        /// <summary>
        /// dropdown menu dla bibiliotek i autora
        /// </summary>
        public NewBookDropdownsVM GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
              
                BookStores =  _context.BookStores.OrderBy(n => n.Name).ToList(),
                Authors = _context.Authors.OrderBy(n => n.FullName).ToList()
            };

            return response;
        }  
        /// <summary>
           /// dodanie dowej ksiązki
           /// </summary>
        public void AddNewBook(NewBookVm data)
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
        /// <summary>
        /// edycja ksiązki
        /// </summary>
        public void UpdateBook(NewBookVm data)
        {
            var dbbook =  _context.Books.FirstOrDefault(n => n.Id == data.Id);

            if (dbbook != null)
            {
                dbbook.Name = data.Name;
                dbbook.Description = data.Description;
                dbbook.Price = data.Price;
                dbbook.Image = data.Image;
            
                dbbook.StartDate = data.StartDate;
            
                dbbook.BookCategory = data.BookCategory;
                dbbook.AuthorId = data.AuthorId;
               _context.SaveChanges();
            }

            //Remove existing books
            var existingBookStoresDb = _context.BookStores_Books.Where(n => n.BookId == data.Id).ToList();
            _context.BookStores_Books.RemoveRange(existingBookStoresDb);
           _context.SaveChanges();

            //Add book 
            foreach (var bookStoreId in data.BookStoreIds)
            {
                var newBookStorebook = new BookStore_Book()
                {
                    BookId = data.Id,
                    BookStoreId = bookStoreId
                };
                _context.BookStores_Books.Add(newBookStorebook);
            }
            _context.SaveChanges();
        }
        public IActionResult Index()
        {
            var data = _context.Books.Include(name => name.BookStore_Books).Include(name => name.Author).OrderBy(n=> n.Name).ToList();

            return View(data);
        }
        //GET: books/Create
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our store";
            ViewBag.Description = "This is the store description";
            var bookDropdownsData =GetNewBookDropdownsValues();

            ViewBag.BookStores = new SelectList(bookDropdownsData.BookStores, "Id", "Name");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");
          
            return View();
        }
        [HttpPost]
        /// <summary>
        ///tutaj jest wysyłany przez formularz ksiązka i sprawdzany czy jest poprawny 
        /// </summary>
        public IActionResult Create(NewBookVm book)
        {
            if (!ModelState.IsValid)
            {
                var bookDropdownsData =  GetNewBookDropdownsValues();

      
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");
                ViewBag.BookStores = new SelectList(bookDropdownsData.BookStores, "Id", "Name");

                return View(book);
            }

            AddNewBook(book);
            return RedirectToAction(nameof(Index));
        }
        //GET: books/Edit/id
        ///   <summary>
        /// edytowanie dla ksiązki przypisanie danych
        /// </summary
        public IActionResult Edit(int id)
        {
            var bookDetails = GetBookById(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVm()
            {
                Id = bookDetails.Id,
                Name = bookDetails.Name,
                Description = bookDetails.Description,
                Price = bookDetails.Price,
                StartDate = bookDetails.StartDate,
                Image = bookDetails.Image,
                BookCategory = bookDetails.BookCategory,
                AuthorId = bookDetails.AuthorId,
                BookStoreIds = bookDetails.BookStore_Books.Select(n => n.BookStoreId).ToList(),
            };

            var bookDropdownsData = GetNewBookDropdownsValues();
            ViewBag.BookStores = new SelectList(bookDropdownsData.BookStores, "Id", "Name");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");
        

            return View(response);
        }

        [HttpPost]
        ///   <summary>
        /// edytowanie dla ksiązki z danym id
        /// </summary
        public IActionResult Edit(int id, NewBookVm book)
        {
            if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var bookDropdownsData = GetNewBookDropdownsValues();

              
                ViewBag.BookStores = new SelectList(bookDropdownsData.BookStores, "Id", "Name");
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "FullName");

                return View(book);
            }

            UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }
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
            DeleteBook(id);

            return RedirectToAction(nameof(Index));


        }
    }

    }



