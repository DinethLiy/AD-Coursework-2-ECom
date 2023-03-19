using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.SuperAdmin;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace eComMaster.Controllers.SuperAdmin
{
    [Authorization(RequiredPrivilegeType = "SUPER_ADMIN")]
    public class ManageAdminsController : Controller
    {
        private readonly IManageAdminsService _manageAdminsService;

        public ManageAdminsController(IManageAdminsService manageAdminsService)
        {
            _manageAdminsService = manageAdminsService;
        }

        public IActionResult Index()
        {
            return View("../../Views/SuperAdmin/ManageAdmins/ViewAdmins",
                _manageAdminsService.GetAdminList());
        }

        public IActionResult ShowAddEditAdmin(int userId, string encryptedPassword) 
        {
            ArrayList? tempDataList = _manageAdminsService.GetTempDataForAddEditAdmins(userId, encryptedPassword);
            if (tempDataList != null) 
            {
                TempData["selectedAdmin"]= (AuthUser)tempDataList[0];
                TempData["decryptedPassword"] = (string)tempDataList[1];
            }
            return View("../../Views/SuperAdmin/ManageAdmins/AddEditAdmin");
        }

        [HttpPost]
        public IActionResult AddAdmin(string username, string password, string confirmPassword, string type)
        {
            string insertResult = _manageAdminsService.AddAdmin(username, password, confirmPassword, type);
            if (insertResult == "success")
            {
                return View("../../Views/SuperAdmin/ManageAdmins/ViewAdmins",
                    _manageAdminsService.GetAdminList());
            }
            else 
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/SuperAdmin/ManageAdmins/AddEditAdmin");
            }
        }

        [HttpPost]
        public IActionResult EditAdmin(string userId, string username, string password, string confirmPassword, string type, string status) 
        {
            string editResult = _manageAdminsService.EditAdmin(userId, username, password, confirmPassword, type, status);
            if (editResult == "success")
            {
                return View("../../Views/SuperAdmin/ManageAdmins/ViewAdmins",
                    _manageAdminsService.GetAdminList());
            }
            else 
            {
                ArrayList? tempDataList = _manageAdminsService.GetTempDataForAddEditAdmins(int.Parse(userId), null);
                TempData["selectedAdmin"] = (AuthUser)tempDataList[0];
                TempData["decryptedPassword"] = editResult;
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/SuperAdmin/ManageAdmins/AddEditAdmin");
            }
        }
    }
}
