using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminManageConfigStorageController : Controller
    {
        private readonly IManageConfigStorageService _manageConfigStorageService;

        public AdminManageConfigStorageController(IManageConfigStorageService manageConfigStorageService)
        {
            _manageConfigStorageService = manageConfigStorageService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigStorage/ViewConfigStorage",
                _manageConfigStorageService.GetConfigStorageList());
        }

        public IActionResult ShowAddEditConfigStorage(int storageId)
        {
            SetTempDataForManageConfigStorage(storageId);
            return View("../../Views/Admin/ConfigItems/ManageConfigStorage/AddEditConfigStorage");
        }

        public IActionResult ShowDeleteConfigStorage(int storageId)
        {
            SetTempDataForManageConfigStorage(storageId);
            return View("../../Views/Admin/ConfigItems/ManageConfigStorage/DeleteConfigStorage");
        }

        [HttpPost]
        public IActionResult AddConfigStorage(string storageName, string price, string? storageDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigStorageService.AddConfigStorage(accessToken, storageName, price, storageDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigStorage/ViewConfigStorage",
                    _manageConfigStorageService.GetConfigStorageList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigStorage/AddEditConfigStorage");
            }
        }

        [HttpPost]
        public IActionResult EditConfigStorage(string pcStorageId, string storageName, string price, string status, string? storageDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigStorageService.EditConfigStorage(accessToken, pcStorageId, storageName, price, status, storageDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigStorage/ViewConfigStorage",
                    _manageConfigStorageService.GetConfigStorageList());
            }
            else
            {
                SetTempDataForManageConfigStorage(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigStorage/AddEditConfigStorage");
            }
        }

        public IActionResult DeleteConfigStorage(string pcStorageId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigStorageService.DeleteConfigStorage(accessToken, pcStorageId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigStorage/ViewConfigStorage",
                    _manageConfigStorageService.GetConfigStorageList());
            }
            else
            {
                SetTempDataForManageConfigStorage(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigStorage/AddEditConfigStorage");
            }
        }

        private void SetTempDataForManageConfigStorage(int storageId)
        {
            ConfigStorage? foundStorage = _manageConfigStorageService.GetTempDataForAddEditConfigStorage(storageId);
            if (foundStorage != null)
            {
                TempData["selectedStorage"] = foundStorage;
            }
        }
    }
}
