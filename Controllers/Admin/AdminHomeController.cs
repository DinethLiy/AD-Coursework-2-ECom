using eComMaster.Business.Interfaces.Admin;
using eComMaster.Data.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        private readonly IAdminHomeService _adminHomeService;

        public AdminHomeController(IAdminHomeService adminHomeService)
        {
            _adminHomeService = adminHomeService;
        }

        // Show Admin Dashboard
        public IActionResult Index()
        {
            SetTempDataForAdminHome();
            return View("../../Views/Admin/AdminHome");
        }

        private void SetTempDataForAdminHome() 
        {
            TempData["pendingOrders"] = _adminHomeService.GetPendingOrderCount();
            TempData["outOfStockModels"] = _adminHomeService.GetOutOfStockModelCount();
            TempData["monthlyOrders"] = _adminHomeService.GetMonthlyOrderCount();
            TempData["monthlyRevenue"] = _adminHomeService.GetMonthlyRevenue();
        }

        // Navigation to other Admin Pages
        public RedirectToActionResult ShowPcCategories()
        {
            return RedirectToAction("Index", "ManagePcCategories");
        }

        public RedirectToActionResult ShowPcSeries()
        {
            return RedirectToAction("Index", "ManagePcSeries");
        }

        public RedirectToActionResult ShowPcModel()
        {
            return RedirectToAction("Index", "ManagePcModel");
        }
        
        public RedirectToActionResult ShowOrder()
        {
            return RedirectToAction("Index", "ManageOrder");
        }

        public RedirectToActionResult ShowPayment()
        {
            return RedirectToAction("Index", "AdminViewPayment");
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

        public RedirectToActionResult ShowOrderReport() 
        {
            return RedirectToAction("ViewOrderReportPage", "AdminReport");
        }

        public RedirectToActionResult ShowPaymentReport()
        {
            return RedirectToAction("ViewPaymentReportPage", "AdminReport");
        }

        public RedirectToActionResult ShowPcModelReport()
        {
            return RedirectToAction("ViewPcModelReportPage", "AdminReport");
        }
    }
}
