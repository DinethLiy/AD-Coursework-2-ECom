using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminManageConfigMiscController : Controller
    {
        private readonly IManageConfigMiscService _manageConfigMiscService;

        public AdminManageConfigMiscController(IManageConfigMiscService manageConfigMiscService)
        {
            _manageConfigMiscService = manageConfigMiscService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigMisc/ViewConfigMisc",
                _manageConfigMiscService.GetConfigMiscList());
        }

        public IActionResult ShowAddEditConfigMisc(int miscId)
        {
            SetTempDataForManageConfigMisc(miscId);
            return View("../../Views/Admin/ConfigItems/ManageConfigMisc/AddEditConfigMisc");
        }

        public IActionResult ShowDeleteConfigMisc(int miscId)
        {
            SetTempDataForManageConfigMisc(miscId);
            return View("../../Views/Admin/ConfigItems/ManageConfigMisc/DeleteConfigMisc");
        }

        [HttpPost]
        public IActionResult AddConfigMisc(string miscName, string price, string? miscDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigMiscService.AddConfigMisc(accessToken, miscName, price, miscDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigMisc/ViewConfigMisc",
                    _manageConfigMiscService.GetConfigMiscList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigMisc/AddEditConfigMisc");
            }
        }

        [HttpPost]
        public IActionResult EditConfigMisc(string pcMiscId, string miscName, string price, string status, string? miscDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigMiscService.EditConfigMisc(accessToken, pcMiscId, miscName, price, status, miscDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigMisc/ViewConfigMisc",
                    _manageConfigMiscService.GetConfigMiscList());
            }
            else
            {
                SetTempDataForManageConfigMisc(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigMisc/AddEditConfigMisc");
            }
        }

        public IActionResult DeleteConfigMisc(string pcMiscId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigMiscService.DeleteConfigMisc(accessToken, pcMiscId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigMisc/ViewConfigMisc",
                    _manageConfigMiscService.GetConfigMiscList());
            }
            else
            {
                SetTempDataForManageConfigMisc(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigMisc/AddEditConfigMisc");
            }
        }

        private void SetTempDataForManageConfigMisc(int miscId)
        {
            ConfigMisc? foundMisc = _manageConfigMiscService.GetTempDataForAddEditConfigMisc(miscId);
            if (foundMisc != null)
            {
                TempData["selectedMisc"] = foundMisc;
            }
        }
    }
}
