using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminManageConfigGraphicsController : Controller
    {
        private readonly IManageConfigGraphicsService _manageConfigGraphicsService;

        public AdminManageConfigGraphicsController(IManageConfigGraphicsService manageConfigGraphicsService)
        {
            _manageConfigGraphicsService = manageConfigGraphicsService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/ViewConfigGraphics",
                _manageConfigGraphicsService.GetConfigGraphicsList());
        }

        public IActionResult ShowAddEditConfigGraphics(int graphicsId)
        {
            SetTempDataForManageConfigGraphics(graphicsId);
            return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/AddEditConfigGraphics");
        }

        public IActionResult ShowDeleteConfigGraphics(int graphicsId)
        {
            SetTempDataForManageConfigGraphics(graphicsId);
            return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/DeleteConfigGraphics");
        }

        [HttpPost]
        public IActionResult AddConfigGraphics(string graphicsName, string price, string? graphicsDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigGraphicsService.AddConfigGraphics(accessToken, graphicsName, price, graphicsDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/ViewConfigGraphics",
                    _manageConfigGraphicsService.GetConfigGraphicsList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/AddEditConfigGraphics");
            }
        }

        [HttpPost]
        public IActionResult EditConfigGraphics(string pcGraphicsId, string graphicsName, string price, string status, string? graphicsDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigGraphicsService.EditConfigGraphics(accessToken, pcGraphicsId, graphicsName, price, status, graphicsDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/ViewConfigGraphics",
                    _manageConfigGraphicsService.GetConfigGraphicsList());
            }
            else
            {
                SetTempDataForManageConfigGraphics(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/AddEditConfigGraphics");
            }
        }

        public IActionResult DeleteConfigGraphics(string pcGraphicsId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigGraphicsService.DeleteConfigGraphics(accessToken, pcGraphicsId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/ViewConfigGraphics",
                    _manageConfigGraphicsService.GetConfigGraphicsList());
            }
            else
            {
                SetTempDataForManageConfigGraphics(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigGraphics/AddEditConfigGraphics");
            }
        }

        private void SetTempDataForManageConfigGraphics(int graphicsId)
        {
            ConfigGraphics? foundGraphics = _manageConfigGraphicsService.GetTempDataForAddEditConfigGraphics(graphicsId);
            if (foundGraphics != null)
            {
                TempData["selectedGraphics"] = foundGraphics;
            }
        }
    }
}
