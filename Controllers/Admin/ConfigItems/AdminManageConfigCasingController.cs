using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Services.Admin;
using eComMaster.Models.MasterData;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    public class AdminManageConfigCasingController : Controller
    {
        private readonly IManageConfigCasingService _manageConfigCasingService;

        public AdminManageConfigCasingController(IManageConfigCasingService manageConfigCasingService)
        {
            _manageConfigCasingService = manageConfigCasingService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigCasing/ViewConfigCasing",
                _manageConfigCasingService.GetConfigCasingList());
        }

        public IActionResult ShowAddEditConfigCasing(int casingId)
        {
            SetTempDataForManageConfigCasing(casingId);
            return View("../../Views/Admin/ConfigItems/ManageConfigCasing/AddEditConfigCasing");
        }

        public IActionResult ShowDeleteConfigCasing(int casingId)
        {
            SetTempDataForManageConfigCasing(casingId);
            return View("../../Views/Admin/ConfigItems/ManageConfigCasing/DeleteConfigCasing");
        }

        [HttpPost]
        public IActionResult AddConfigCasing(string casingName, string price, string? casingDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigCasingService.AddConfigCasing(accessToken, casingName, price, casingDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigCasing/ViewConfigCasing",
                    _manageConfigCasingService.GetConfigCasingList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigCasing/AddEditConfigCasing");
            }
        }

        [HttpPost]
        public IActionResult EditConfigCasing(string pcCasingId, string casingName, string price, string status, string? casingDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigCasingService.EditConfigCasing(accessToken, pcCasingId, casingName, price, status, casingDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigCasing/ViewConfigCasing",
                    _manageConfigCasingService.GetConfigCasingList());
            }
            else
            {
                SetTempDataForManageConfigCasing(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigCasing/AddEditConfigCasing");
            }
        }

        public IActionResult DeleteConfigCasing(string pcCasingId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigCasingService.DeleteConfigCasing(accessToken, pcCasingId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigCasing/ViewConfigCasing",
                    _manageConfigCasingService.GetConfigCasingList());
            }
            else
            {
                SetTempDataForManageConfigCasing(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigCasing/AddEditConfigCasing");
            }
        }

        private void SetTempDataForManageConfigCasing(int casingId)
        {
            ConfigCasing? foundCasing = _manageConfigCasingService.GetTempDataForAddEditConfigCasing(casingId);
            if (foundCasing != null)
            {
                TempData["selectedCasing"] = foundCasing;
            }
        }
    }
}
