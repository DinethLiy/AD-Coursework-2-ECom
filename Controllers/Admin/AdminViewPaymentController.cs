using eComMaster.Business.Interfaces.Admin;
using eComMaster.Data.Utility;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminViewPaymentController : Controller
    {
        private readonly IAdminViewPaymentService _adminViewPaymentService;

        public AdminViewPaymentController(IAdminViewPaymentService adminViewPaymentService)
        {
            _adminViewPaymentService = adminViewPaymentService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ManagePayment/ViewPayment",
                _adminViewPaymentService.GetPaymentList());
        }
    }
}
