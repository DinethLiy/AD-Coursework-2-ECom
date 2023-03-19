using eComMaster.Data.Utility;
using Microsoft.AspNetCore.Authorization;
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

        public RedirectToActionResult ShowConfigCasing()
        {
            return RedirectToAction("Index", "AdminManageConfigCasing");
        }

        public RedirectToActionResult ShowConfigDisplay()
        {
            return RedirectToAction("Index", "AdminManageConfigDisplay");
        }

        public RedirectToActionResult ShowConfigGraphics()
        {
            return RedirectToAction("Index", "AdminManageConfigGraphics");
        }

        public RedirectToActionResult ShowConfigMemory()
        {
            return RedirectToAction("Index", "AdminManageConfigMemory");
        }

        public RedirectToActionResult ShowConfigMisc()
        {
            return RedirectToAction("Index", "AdminManageConfigMisc");
        }

        public RedirectToActionResult ShowConfigPorts()
        {
            return RedirectToAction("Index", "AdminManageConfigPorts");
        }

        public RedirectToActionResult ShowConfigPower()
        {
            return RedirectToAction("Index", "AdminManageConfigPower");
        }

        public RedirectToActionResult ShowConfigProcessor()
        {
            return RedirectToAction("Index", "AdminManageConfigProcessor");
        }

        public RedirectToActionResult ShowConfigStorage()
        {
            return RedirectToAction("Index", "AdminManageConfigStorage");
        }
    }
}
