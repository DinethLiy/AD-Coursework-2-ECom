using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.SuperAdmin
{
    public class SuperAdminHomeController : Controller
    {
        private readonly IAuthService _authService;

        public SuperAdminHomeController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            /*// Get access token from cookie -> use Service to get logged in user -> parse user's username for View's display.
            string? accessToken = Request.Cookies["access_token"];
            accessToken ??= "empty";
            var foundUser = _authService.GetLoggedInUser(accessToken);
            string? name = null;
            if (foundUser != null)
            {
                name = foundUser.USERNAME;
            }
            TempData["superAdminUsername"] = name;*/

            return View("../../Views/SuperAdmin/SuperAdminHome");
        }

        public RedirectToActionResult ShowAdmins()
        {
            return RedirectToAction("Index", "ManageAdmins");
        }
    }
}
