using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reenbit.TestTask.RealTimeChat.Models;

namespace Reenbit.TestTask.RealTimeChat.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            
            var user = await _userManager.FindByNameAsync(username);
            if (user != null) { 
            var result =  await _signInManager.PasswordSignInAsync(user, password,false,false);
            if (result.Succeeded)
            {
                    await _signInManager.SignInAsync(user, false);
                    _signInManager.Context.Session.SetString("UserName", username);
                    _signInManager.Context.Session.SetString("UserId", user.Id);
                    return RedirectToAction("Index","Home");
            }
            }
            return RedirectToAction("Login","Account");
        }
        [HttpGet]
        public IActionResult Register() => View();
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var newUser = new User {
                UserName = username,
            };
            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Register", "Account");
        }
         public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
