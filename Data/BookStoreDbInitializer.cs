using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Data
{
    public class BookStoreDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //odniesienie do bazy danych
                var context = serviceScope.ServiceProvider.GetService<BookStoreDbContext>();
                // czy istnieje
                context.Database.EnsureCreated();

                //BookStore
                if (!context.BookStores.Any())
                {
                    context.BookStores.AddRange(new List<BookStore>()
                    {
                        new BookStore()
                        {
                            Name = "BookStore 1",
                            BookStoreLogo = "https://images.pexels.com/photos/626986/pexels-photo-626986.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Description = "This is the description for first BookStore "
                        },
                            new BookStore()
                        {
                            Name = "BookStore 2",
                            BookStoreLogo = "https://images.pexels.com/photos/1907785/pexels-photo-1907785.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Description = "This is the description for second BookStore "
                        }
                    }

                        );
                    context.SaveChanges();
                }
                //Author
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            FullName = "Author 1",
                            ProfilePicture = "https://images.pexels.com/photos/9696093/pexels-photo-9696093.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Bio = "This is the Bio for first Author"
                        },
                            new Author()
                        {
                            FullName = "Author 2",
                            ProfilePicture = "https://images.pexels.com/photos/4024732/pexels-photo-4024732.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Bio = "This is the Bio for second Author "
                        }
                    }

                        );
                    context.SaveChanges();
                }
                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Name = "Book 1",
                            Description = "This is the Description for first Book",
                            StartDate = DateTime.Now,
                            Image = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Price = 39.50,
                            BookCategory = BookCategory.Historia,
                            AuthorId = 1,
                        },
                            new Book()
                        {
                           Name = "Book 2",
                            Description = "This is the Description for second Book",
                            StartDate = DateTime.Now.AddDays(5),
                            Image = "https://images.pexels.com/photos/256450/pexels-photo-256450.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Price = 29.50,
                            BookCategory = BookCategory.Fantastyka,
                         AuthorId = 2,
                        },
                            new Book()
                        {
                           Name = "Book 3",
                            Description = "This is the Description for third Book",
                            StartDate = DateTime.Now.AddDays(2),
                            Image = "https://images.pexels.com/photos/256450/pexels-photo-256450.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Price = 69.50,
                            BookCategory = BookCategory.Kriminał,
                            
                            AuthorId = 1,
                        },
                            new Book()
                        {
                           Name = "Book 4",
                            Description = "This is the Description for fourth Book",
                            StartDate = DateTime.Now.AddDays(5),
                            Image = "https://images.pexels.com/photos/256450/pexels-photo-256450.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Price = 49.50,
                            BookCategory = BookCategory.Poezja,
                         
                            AuthorId = 2,
                        },
                            new Book()
                        {
                           Name = "Book 5",
                            Description = "This is the Description for fifth Book",
                            StartDate = DateTime.Now,
                            Image = "https://images.pexels.com/photos/256450/pexels-photo-256450.jpeg?auto=compress&cs=tinysrgb&w=400",
                            Price = 19.50,
                            BookCategory = BookCategory.Historia,
                          
                            AuthorId = 2,
                        }
                    }

                      ); ;
                    context.SaveChanges();
                }
              
                //Books & Reviews
                if (!context.BookStores_Books.Any())
                {
                    context.BookStores_Books.AddRange(new List<BookStore_Book>()
                    {
                        new BookStore_Book()
                        {
                         BookId = 1,
                         BookStoreId = 2
                        },
                            new BookStore_Book()
                        {
                           BookId = 2,
                         BookStoreId = 1
                        }
                    }

                   );
                    context.SaveChanges();
                }
            }
        }
    }
}
