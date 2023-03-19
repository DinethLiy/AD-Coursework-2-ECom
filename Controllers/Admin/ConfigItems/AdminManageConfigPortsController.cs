using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class AdminManageConfigPortsController : Controller
    {
        private readonly IManageConfigPortsService _manageConfigPortsService;

        public AdminManageConfigPortsController(IManageConfigPortsService manageConfigPortsService)
        {
            _manageConfigPortsService = manageConfigPortsService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ConfigItems/ManageConfigPorts/ViewConfigPorts",
                _manageConfigPortsService.GetConfigPortsList());
        }

        public IActionResult ShowAddEditConfigPorts(int portsId)
        {
            SetTempDataForManageConfigPorts(portsId);
            return View("../../Views/Admin/ConfigItems/ManageConfigPorts/AddEditConfigPorts");
        }

        public IActionResult ShowDeleteConfigPorts(int portsId)
        {
            SetTempDataForManageConfigPorts(portsId);
            return View("../../Views/Admin/ConfigItems/ManageConfigPorts/DeleteConfigPorts");
        }

        [HttpPost]
        public IActionResult AddConfigPorts(string portsName, string price, string? portsDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _manageConfigPortsService.AddConfigPorts(accessToken, portsName, price, portsDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigPorts/ViewConfigPorts",
                    _manageConfigPortsService.GetConfigPortsList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigPorts/AddEditConfigPorts");
            }
        }

        [HttpPost]
        public IActionResult EditConfigPorts(string pcPortsId, string portsName, string price, string status, string? portsDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _manageConfigPortsService.EditConfigPorts(accessToken, pcPortsId, portsName, price, status, portsDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigPorts/ViewConfigPorts",
                    _manageConfigPortsService.GetConfigPortsList());
            }
            else
            {
                SetTempDataForManageConfigPorts(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ConfigItems/ManageConfigPorts/AddEditConfigPorts");
            }
        }

        public IActionResult DeleteConfigPorts(string pcPortsId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _manageConfigPortsService.DeleteConfigPorts(accessToken, pcPortsId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ConfigItems/ManageConfigPorts/ViewConfigPorts",
                    _manageConfigPortsService.GetConfigPortsList());
            }
            else
            {
                SetTempDataForManageConfigPorts(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ConfigItems/ManageConfigPorts/AddEditConfigPorts");
            }
        }

        private void SetTempDataForManageConfigPorts(int portsId)
        {
            ConfigPorts? foundPorts = _manageConfigPortsService.GetTempDataForAddEditConfigPorts(portsId);
            if (foundPorts != null)
            {
                TempData["selectedPorts"] = foundPorts;
            }
        }
    }
}
