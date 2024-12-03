using LibraryManageModel.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryManageModel.BusinessModel;
using Newtonsoft.Json;


namespace LibraryManage.Controllers
{
	public class AccountController : BaseController
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;


        public AccountController(SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
					var result = await _userManager.CreateAsync(user, model.Password);

					if (result.Succeeded)
					{
						//optionally add user to a default role e.g. "User"
						await _userManager.AddToRoleAsync(user, "User");

						await _signInManager.SignInAsync(user, isPersistent: false);
						return RedirectToAction("Index", "Home");
					}

					var msg = string.Empty;
					foreach (var error in result.Errors)
					{
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
					TempData["ErrorMessage"] = msg;
					return RedirectToAction("Index", "Home");

				}

				return View(model);

			}

			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("NotFound");
			}

		}


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "Home/Index")
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email,
                        model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "Successfully Logged In";
                        // Redirect to returnUrl if it is set and is local; otherwise, go to default.
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Invalid login attempt.";
                    }

                }
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
