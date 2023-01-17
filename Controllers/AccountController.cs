using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET_14040.Data;
using ProjectASP.NET_14040.Data.Static;
using ProjectASP.NET_14040.Data.ViewModels;
using ProjectASP.NET_14040.Models;

namespace ProjectASP.NET_14040.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        ///Kontroler odpowiadający za użytkowników
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly BookStoreDbContext _context;

        /// <summary>
        /// Konstruktor przypisujący dane 
        /// </summary>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, BookStoreDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        ///Login towrzy nowy login
        /// </summary>
        public IActionResult Login() => View(new LoginVM());
        [HttpPost]
        /// <summary>
        ///tutaj jest wysyłany przez formularz login i sprawdzany czy jest poprawny i czy istenieje
        /// </summary>
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Books");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }
        /// <summary>
        ///Login towrzy nowy register
        /// </summary>
        public IActionResult Register() => View(new RegisterVM());
        [HttpPost]
        /// <summary>
        ///tutaj jest wysyłany przez formularz register i sprawdzany czy jest poprawny i czy istenieje
        /// </summary>
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");
        }
        [HttpPost]
        /// <summary>
        ///Wylogowanie używkonika 
        /// </summary>
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Books");
        }
        /// <summary>
        ///Lista użytkowników
        /// </summary>
        public IActionResult Users()
        {
            var users =  _context.Users.ToList();
            return View(users);
        }
    }
}
