using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminManageConfigPowerController : Controller
    {
        private readonly IManageConfigPowerService _manageConfigPowerService;

        public AdminManageConfigPowerController(IManageConfigPowerService manageConfigPowerService)
        {
            _manageConfigPowerService = manageConfigPowerService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigPower/ViewConfigPower",
                _manageConfigPowerService.GetConfigPowerList());
        }

        public IActionResult ShowAddEditConfigPower(int powerId)
        {
            SetTempDataForManageConfigPower(powerId);
            return View("../../Views/Admin/ConfigItems/ManageConfigPower/AddEditConfigPower");
        }

        public IActionResult ShowDeleteConfigPower(int powerId)
        {
            SetTempDataForManageConfigPower(powerId);
            return View("../../Views/Admin/ConfigItems/ManageConfigPower/DeleteConfigPower");
        }

        [HttpPost]
        public IActionResult AddConfigPower(string powerName, string price, string? powerDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigPowerService.AddConfigPower(accessToken, powerName, price, powerDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigPower/ViewConfigPower",
                    _manageConfigPowerService.GetConfigPowerList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigPower/AddEditConfigPower");
            }
        }

        [HttpPost]
        public IActionResult EditConfigPower(string pcPowerId, string powerName, string price, string status, string? powerDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigPowerService.EditConfigPower(accessToken, pcPowerId, powerName, price, status, powerDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigPower/ViewConfigPower",
                    _manageConfigPowerService.GetConfigPowerList());
            }
            else
            {
                SetTempDataForManageConfigPower(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigPower/AddEditConfigPower");
            }
        }

        public IActionResult DeleteConfigPower(string pcPowerId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigPowerService.DeleteConfigPower(accessToken, pcPowerId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigPower/ViewConfigPower",
                    _manageConfigPowerService.GetConfigPowerList());
            }
            else
            {
                SetTempDataForManageConfigPower(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigPower/AddEditConfigPower");
            }
        }

        private void SetTempDataForManageConfigPower(int powerId)
        {
            ConfigPower? foundPower = _manageConfigPowerService.GetTempDataForAddEditConfigPower(powerId);
            if (foundPower != null)
            {
                TempData["selectedPower"] = foundPower;
            }
        }
    }
}
