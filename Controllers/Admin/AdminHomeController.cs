using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View("../../Views/Admin/AdminHome");
        }

        public RedirectToActionResult ShowPcCategories()
        {
            return RedirectToAction("Index", "ManagePcCategories");
        }

        public RedirectToActionResult ShowPcSeries()
        {
            return RedirectToAction("Index", "ManagePcSeries");
        }
    }
}
