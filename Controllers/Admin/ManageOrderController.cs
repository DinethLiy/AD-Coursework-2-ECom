using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Services.Admin;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace eComMaster.Controllers.Admin
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class ManageOrderController : Controller
    {
        private readonly IManageOrderService _manageOrderService;

        public ManageOrderController(IManageOrderService manageOrderService)
        {
            _manageOrderService = manageOrderService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ManageOrder/ViewOrder",
                _manageOrderService.GetOrderList());
        }

        public IActionResult ShowEditOrder(int orderId)
        {
            SetTempDataForManageOrder(orderId);
            return View("../../Views/Admin/ManageOrder/EditOrder");
        }

        [HttpPost]
        public IActionResult EditOrder(string orderId, string status)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageOrderService.EditOrder(accessToken, orderId, status);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ManageOrder/ViewOrder",
                    _manageOrderService.GetOrderList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                SetTempDataForManageOrder(int.Parse(editResult));
                return View("../../Views/Admin/ManageOrder/EditOrder");
            }
        }

        private void SetTempDataForManageOrder(int orderId)
        {
            TempData["selectedOrder"] = _manageOrderService.GetTempDataForEditOrder(orderId);
        }
    }
}
