using Library.WebApp.Models.Account;
using Library.WebApp.Models.Reader;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public IConfiguration Configuration;

        public AccountController(SignInManager<IdentityUser> singInManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _signInManager = singInManager;
            _userManager = userManager;
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:hostUrl"];
            return Content(result);
        }

        private async Task CreateReader(ReaderCreateVM reader)
        {
            string _restpath = GetHostUrl().Content + "reader";

            using (var httpClient = new HttpClient())
            {
                string readerJson = System.Text.Json.JsonSerializer.Serialize(reader);
                var content = new StringContent(readerJson, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(_restpath, content);
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {


                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło...");

            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = registerVM.UserName };
                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, registerVM.Role));
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", result.ToString());

            }

            return View(registerVM);
        }

        public IActionResult RegisterReader()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterReader(RegisterReaderVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = registerVM.UserName };
                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Reader"));

                    await CreateReader(new ReaderCreateVM()
                    {
                        FirstName = registerVM.FirstName,
                        LastName = registerVM.LastName,
                        Email = registerVM.Email,
                        UserName = registerVM.UserName
                    });

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", result.ToString());

            }

            return View(registerVM);
        }
    }
}
