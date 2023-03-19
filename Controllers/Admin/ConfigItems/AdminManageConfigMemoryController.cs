using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminManageConfigMemoryController : Controller
    {
        private readonly IManageConfigMemoryService _manageConfigMemoryService;

        public AdminManageConfigMemoryController(IManageConfigMemoryService manageConfigMemoryService)
        {
            _manageConfigMemoryService = manageConfigMemoryService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigMemory/ViewConfigMemory",
                _manageConfigMemoryService.GetConfigMemoryList());
        }

        public IActionResult ShowAddEditConfigMemory(int memoryId)
        {
            SetTempDataForManageConfigMemory(memoryId);
            return View("../../Views/Admin/ConfigItems/ManageConfigMemory/AddEditConfigMemory");
        }

        public IActionResult ShowDeleteConfigMemory(int memoryId)
        {
            SetTempDataForManageConfigMemory(memoryId);
            return View("../../Views/Admin/ConfigItems/ManageConfigMemory/DeleteConfigMemory");
        }

        [HttpPost]
        public IActionResult AddConfigMemory(string memoryName, string price, string? memoryDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigMemoryService.AddConfigMemory(accessToken, memoryName, price, memoryDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigMemory/ViewConfigMemory",
                    _manageConfigMemoryService.GetConfigMemoryList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigMemory/AddEditConfigMemory");
            }
        }

        [HttpPost]
        public IActionResult EditConfigMemory(string pcMemoryId, string memoryName, string price, string status, string? memoryDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigMemoryService.EditConfigMemory(accessToken, pcMemoryId, memoryName, price, status, memoryDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigMemory/ViewConfigMemory",
                    _manageConfigMemoryService.GetConfigMemoryList());
            }
            else
            {
                SetTempDataForManageConfigMemory(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigMemory/AddEditConfigMemory");
            }
        }

        public IActionResult DeleteConfigMemory(string pcMemoryId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigMemoryService.DeleteConfigMemory(accessToken, pcMemoryId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigMemory/ViewConfigMemory",
                    _manageConfigMemoryService.GetConfigMemoryList());
            }
            else
            {
                SetTempDataForManageConfigMemory(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigMemory/AddEditConfigMemory");
            }
        }

        private void SetTempDataForManageConfigMemory(int memoryId)
        {
            ConfigMemory? foundMemory = _manageConfigMemoryService.GetTempDataForAddEditConfigMemory(memoryId);
            if (foundMemory != null)
            {
                TempData["selectedMemory"] = foundMemory;
            }
        }
    }
}
