using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sun.DAL.Models;
using Sun.PL.ViewModels;

namespace Sun.PL.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager) 
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
		}
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Register(RegisterVm vm)
		{
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = vm.UserName,
                    Email = vm.Email
                };
                var result = await userManager.CreateAsync(user,vm.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
			return View();
		}

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Login(LoginVm vm)
		{
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(vm.Email);
                if(user is not null)
                {
                    var check = await userManager.CheckPasswordAsync(user, vm.Password);
                    if (check)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index","Home");
                        }
                        {
                            
                        }
                    }
                }
            }
			return View(vm);
		}
	}
}
