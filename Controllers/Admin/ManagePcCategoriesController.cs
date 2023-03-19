using eComMaster.Business.Interfaces.Admin;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
using eComMaster.Models.MasterData;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace eComMaster.Controllers.Admin
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class ManagePcCategoriesController : Controller
    {
        private readonly IManagePcCategoriesService _managePcCategoriesService;

        public ManagePcCategoriesController(IManagePcCategoriesService managePcCategoriesService)
        {
            _managePcCategoriesService = managePcCategoriesService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ManagePcCategories/ViewPcCategories",
                _managePcCategoriesService.GetPcCategoriesList());
        }

        public IActionResult ShowAddEditPcCategory(int pcCategoryId)
        {
            SetTempDataForManagePcCategory(pcCategoryId);
            return View("../../Views/Admin/ManagePcCategories/AddEditPcCategory");
        }

        public IActionResult ShowDeletePcCategory(int pcCategoryId) 
        {
            SetTempDataForManagePcCategory(pcCategoryId);
            return View("../../Views/Admin/ManagePcCategories/DeletePcCategory");
        }

        [HttpPost]
        public IActionResult AddPcCategory(string categoryName, string? categoryDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _managePcCategoriesService.AddPcCategory(accessToken, categoryName, categoryDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ManagePcCategories/ViewPcCategories",
                    _managePcCategoriesService.GetPcCategoriesList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ManagePcCategories/AddEditPcCategory");
            }
        }

        [HttpPost]
        public IActionResult EditPcCategory(string pcCategoryId, string categoryName, string status, string? categoryDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _managePcCategoriesService.EditPcCategory(accessToken, pcCategoryId, categoryName, status, categoryDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ManagePcCategories/ViewPcCategories",
                    _managePcCategoriesService.GetPcCategoriesList());
            }
            else
            {
                SetTempDataForManagePcCategory(int.Parse(editResult));
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Admin/ManagePcCategories/AddEditPcCategory");
            }
        }

        public IActionResult DeletePcCategory(string pcCategoryId) 
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _managePcCategoriesService.DeletePcCategory(accessToken, pcCategoryId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ManagePcCategories/ViewPcCategories",
                    _managePcCategoriesService.GetPcCategoriesList());
            }
            else
            {
                SetTempDataForManagePcCategory(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ManagePcCategories/DeleteEditPcCategory");
            }
        }

        private void SetTempDataForManagePcCategory(int pcCategoryId) 
        {
            PcCategory? foundCategory = _managePcCategoriesService.GetTempDataForAddEditPcCategory(pcCategoryId);
            if (foundCategory != null)
            {
                TempData["selectedCategory"] = foundCategory;
            }
        }
    }
}
