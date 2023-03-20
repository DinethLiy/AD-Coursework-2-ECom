using eComMaster.Business.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Auth
{
    public class AuthController : Controller
    {
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		public IActionResult Index()
		{
			return View("Login");
		}

		[HttpPost]
		public RedirectToActionResult Login(string username, string password) 
		{
			string redirectPath = _authService.LoginUser(username, password);
			if (redirectPath != "error")
			{
				Response.Cookies.Append("access_token", _authService.GetToken(), _authService.GetCookieOptions());
				return RedirectToAction("Index", redirectPath);
			}
			else 
			{
				ModelState.AddModelError("", "Invalid username or password");
				return RedirectToAction("Index", "Auth");
			}
		}

		public IActionResult Logout() 
		{
			// Cookie containing JWT Auth key is destroyed at logout.
            Response.Cookies.Delete("access_token");
			return View("Login");
        }
	}
}
