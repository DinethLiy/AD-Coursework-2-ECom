using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminManageConfigDisplayController : Controller
    {
        private readonly IManageConfigDisplayService _manageConfigDisplayService;

        public AdminManageConfigDisplayController(IManageConfigDisplayService manageConfigDisplayService)
        {
            _manageConfigDisplayService = manageConfigDisplayService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/ViewConfigDisplay",
                _manageConfigDisplayService.GetConfigDisplayList());
        }

        public IActionResult ShowAddEditConfigDisplay(int displayId)
        {
            SetTempDataForManageConfigDisplay(displayId);
            return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/AddEditConfigDisplay");
        }

        public IActionResult ShowDeleteConfigDisplay(int displayId)
        {
            SetTempDataForManageConfigDisplay(displayId);
            return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/DeleteConfigDisplay");
        }

        [HttpPost]
        public IActionResult AddConfigDisplay(string displayName, string price, string? displayDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigDisplayService.AddConfigDisplay(accessToken, displayName, price, displayDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/ViewConfigDisplay",
                    _manageConfigDisplayService.GetConfigDisplayList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/AddEditConfigDisplay");
            }
        }

        [HttpPost]
        public IActionResult EditConfigDisplay(string pcDisplayId, string displayName, string price, string status, string? displayDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigDisplayService.EditConfigDisplay(accessToken, pcDisplayId, displayName, price, status, displayDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/ViewConfigDisplay",
                    _manageConfigDisplayService.GetConfigDisplayList());
            }
            else
            {
                SetTempDataForManageConfigDisplay(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/AddEditConfigDisplay");
            }
        }

        public IActionResult DeleteConfigDisplay(string pcDisplayId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigDisplayService.DeleteConfigDisplay(accessToken, pcDisplayId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/ViewConfigDisplay",
                    _manageConfigDisplayService.GetConfigDisplayList());
            }
            else
            {
                SetTempDataForManageConfigDisplay(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigDisplay/AddEditConfigDisplay");
            }
        }

        private void SetTempDataForManageConfigDisplay(int displayId)
        {
            ConfigDisplay? foundDisplay = _manageConfigDisplayService.GetTempDataForAddEditConfigDisplay(displayId);
            if (foundDisplay != null)
            {
                TempData["selectedDisplay"] = foundDisplay;
            }
        }
    }
}
