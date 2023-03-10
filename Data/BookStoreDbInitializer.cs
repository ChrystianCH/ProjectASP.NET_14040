using Microsoft.AspNetCore.Identity;
using ProjectASP.NET_14040.Models;
using ProjectASP.NET_14040.Data.Static;

namespace ProjectASP.NET_14040.Data
{
    public class BookStoreDbInitializer
    {
        /// <summary>
        ///Tworzenie bazy danych
        ///  </summary>
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                
                ///  <summary>
                /// odniesienie do bazy danych
                ///  </summary>
                var context = serviceScope.ServiceProvider.GetService<BookStoreDbContext>();
                
                ///  <summary>
                ///  czy istnieje
                ///  </summary>
                                context.Database.EnsureCreated();

                ///  <summary>
                ///  jeżeli pusta stwórz tabele BookStores
                ///  </summary>
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
                    ///  <summary>
                    ///  zapisanie
                    ///  </summary>
                    context.SaveChanges();
                }
                ///  <summary>
                ///  jeżeli pusta stwórz tabele Authors
                ///  </summary>
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
                ///  <summary>
                ///  jeżeli pusta stwórz tabele Books
                ///  </summary>
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
                           
                    }

                      ); ;
                    context.SaveChanges();
                }

                ///  <summary>
                ///  jeżeli pusta stwórz tabele BookStores_Books
                ///  </summary>
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
        /// <summary>
        ///Tworzenie bazy danych dla użytkowników i roli 
        ///  </summary>
        public static async Task SeedUsersAndRoles(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                /// <summary>
                ///Nadanie roli
                ///  </summary>
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                /// <summary>
                ///stowrzenie przykładowego admina 
                ///  </summary>
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@eBookStore.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Test@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                /// <summary>
                ///stowrzenie przykładowego użytkownika  
                ///  </summary>
                string appUserEmail = "user@eBookStore.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Test@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
