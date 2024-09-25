using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.ViewModels;

namespace TravelGuide.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
			if (ModelState.IsValid)
			{
				var newuser = new AppUser
				{
					UserName = model.Username,
					Email = model.Email,
					Address = "",
					EmailConfirmed = true
				};
				var result = await _userManager.CreateAsync(newuser, model.Password);

				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(newuser, "User");
					await _signInManager.SignInAsync(newuser, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}

				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(string.Empty, item.Description);
				}

			}
			return View(model);
		}
    }
}
