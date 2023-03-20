using eComMaster.Business.Interfaces.Admin;
using eComMaster.Data.Utility;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminReportController : Controller
    {
        private readonly IReportService _reportService;

        public AdminReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult ViewOrderReportPage()
        {
            return View("../../Views/Admin/Reports/OrderReport");
        }

        public IActionResult ViewPaymentReportPage()
        {
            return View("../../Views/Admin/Reports/PaymentReport", _reportService.GetPcModelList());
        }

        public IActionResult ViewPcModelReportPage()
        {
            return View("../../Views/Admin/Reports/PcModelReport", _reportService.GetPcSeriesList());
        }

        [HttpPost]
        public FileResult DownloadOrderReport(string price) 
        {
            var stream = _reportService.GenerateOrderReport(price);
            return File(stream.ToArray(), "application/pdf", "Order Report.pdf");
        }

        [HttpPost]
        public FileResult DownloadPaymentReport(string model)
        {
            var stream = _reportService.GeneratePaymentReport(model);
            return File(stream.ToArray(), "application/pdf", "Payment Report.pdf");
        }

        [HttpPost]
        public FileResult DownloadPcModelReport(string series)
        {
            var stream = _reportService.GeneratePcModelReport(series);
            return File(stream.ToArray(), "application/pdf", "PC Model Report.pdf");
        }
    }
}
