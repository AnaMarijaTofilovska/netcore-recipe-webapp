using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Controllers
{
    //Handels user authentication actions
    public class AccountController : Controller
    {
        //Using the services provided for managing users and sign-ins
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Login action responsible for rendering the login view and handling the login submission
        public IActionResult Login()
        {
            return View();
        }
        //Using SignInManager to perform sign-in operation
        //If login successfull-redirects to Home ,if not-displayes error!
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login,string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                        return LocalRedirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                    
                ModelState.AddModelError("", "Invalid LogIn Attempt");
            }
            return View(login);
        }

        //Logout action using SigninManager to sign out the user and redirect to Home
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //Register action for rendering registration view and handling register submision
        public IActionResult Register()
        {
            return View();
        }
        //Using UserManager to create new user using the model ApplicationUser and sign in succesfully
        [HttpPost]
        public async Task<IActionResult> Register( RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Name = register.Name,
                    Address = register.Address,
                    Email = register.Email,
                    UserName=register.Email
                };
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await _signInManager.PasswordSignInAsync(user, register.Password, false, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var err in result.Errors)
                    {
                        ModelState.AddModelError(" ",err.Description);
                    }
                }
            }
            return View(register);
        }
    }
}
