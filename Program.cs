using Microsoft.EntityFrameworkCore;
using ProjectASP.NET_14040.Controllers;
using ProjectASP.NET_14040.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            ///<summary>
            /// DbContext Configuration
            /// </summary>
            builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
            //Authentication and authorization
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookStoreDbContext>();
           //Dodaje zapamiêtywanie przez cookies
            builder.Services.AddMemoryCache();
            //Dodaje zapamiêtywanie przez cookies
            builder.Services.AddSession();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();
          

            app.MapControllerRoute(
                name: "default",
                //przekierownie na
                pattern: "{controller=Books}/{action=Index}/{id?}");
            
            //Czy istnieje jak nie stwórz now¹ 
            BookStoreDbInitializer.Seed(app);
            //Czy istnieje jak nie stwórz now¹ baze user role
            ; BookStoreDbInitializer.SeedUsersAndRoles(app).Wait();
            app.Run();
        }
    }
}