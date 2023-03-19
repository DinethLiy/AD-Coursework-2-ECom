using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminManageConfigProcessorController : Controller
    {
        private readonly IManageConfigProcessorService _manageConfigProcessorService;

        public AdminManageConfigProcessorController(IManageConfigProcessorService manageConfigProcessorService)
        {
            _manageConfigProcessorService = manageConfigProcessorService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/ViewConfigProcessor",
                _manageConfigProcessorService.GetConfigProcessorList());
        }

        public IActionResult ShowAddEditConfigProcessor(int processorId)
        {
            SetTempDataForManageConfigProcessor(processorId);
            return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/AddEditConfigProcessor");
        }

        public IActionResult ShowDeleteConfigProcessor(int processorId)
        {
            SetTempDataForManageConfigProcessor(processorId);
            return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/DeleteConfigProcessor");
        }

        [HttpPost]
        public IActionResult AddConfigProcessor(string processorName, string price, string? processorDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigProcessorService.AddConfigProcessor(accessToken, processorName, price, processorDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/ViewConfigProcessor",
                    _manageConfigProcessorService.GetConfigProcessorList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/AddEditConfigProcessor");
            }
        }

        [HttpPost]
        public IActionResult EditConfigProcessor(string pcProcessorId, string processorName, string price, string status, string? processorDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigProcessorService.EditConfigProcessor(accessToken, pcProcessorId, processorName, price, status, processorDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/ViewConfigProcessor",
                    _manageConfigProcessorService.GetConfigProcessorList());
            }
            else
            {
                SetTempDataForManageConfigProcessor(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/AddEditConfigProcessor");
            }
        }

        public IActionResult DeleteConfigProcessor(string pcProcessorId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigProcessorService.DeleteConfigProcessor(accessToken, pcProcessorId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/ViewConfigProcessor",
                    _manageConfigProcessorService.GetConfigProcessorList());
            }
            else
            {
                SetTempDataForManageConfigProcessor(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigProcessor/AddEditConfigProcessor");
            }
        }

        private void SetTempDataForManageConfigProcessor(int processorId)
        {
            ConfigProcessor? foundProcessor = _manageConfigProcessorService.GetTempDataForAddEditConfigProcessor(processorId);
            if (foundProcessor != null)
            {
                TempData["selectedProcessor"] = foundProcessor;
            }
        }
    }
}
