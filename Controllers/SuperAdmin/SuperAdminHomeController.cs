using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.SuperAdmin
{
    public class SuperAdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("../../Views/SuperAdmin/SuperAdminHome");
        }

        public RedirectToActionResult ShowAdmins()
        {
            return RedirectToAction("Index", "ManageAdmins");
        }
    }
}
