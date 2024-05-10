using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VTPAdmin.Models;
using VTPAdmin.ViewModels.Users;

namespace VTPAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if(!ModelState.IsValid)
            {
                return View(userLoginVM);
            }

            var result = await signInManager.PasswordSignInAsync(userLoginVM.Email, userLoginVM.Password, userLoginVM.RememberMe, false);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email or password is incorrect");
                return View();
            }            
        }

        [HttpGet]
        [Authorize] 
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login), "Account");
        }
    }
}
