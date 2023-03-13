using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Services.Admin;
using eComMaster.Models.MasterData;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace eComMaster.Controllers.Admin
{
    public class ManagePcSeriesController : Controller
    {
        private readonly IManagePcSeriesService _managePcSeriesService;

        public ManagePcSeriesController(IManagePcSeriesService managePcSeriesService)
        {
            _managePcSeriesService = managePcSeriesService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ManagePcSeries/ViewPcSeries",
                _managePcSeriesService.GetPcSeriesList());
        }

        public IActionResult ShowAddEditPcSeries(int pcSeriesId)
        {
            SetTempDataForManagePcSeries(pcSeriesId);
            return View("../../Views/Admin/ManagePcSeries/AddEditPcSeries");
        }

        public IActionResult ShowDeletePcSeries(int pcSeriesId)
        {
            SetTempDataForManagePcSeries(pcSeriesId);
            return View("../../Views/Admin/ManagePcSeries/DeletePcSeries");
        }

        [HttpPost]
        public IActionResult AddPcSeries(string category, string seriesName, string? seriesDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _managePcSeriesService.AddPcSeries(accessToken, seriesName, category, seriesDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ManagePcSeries/ViewPcSeries",
                    _managePcSeriesService.GetPcSeriesList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                SetTempDataForManagePcSeries(-1);
                return View("../../Views/Admin/ManagePcSeries/AddEditPcSeries");
            }
        }

        [HttpPost]
        public IActionResult EditPcSeries(string pcSeriesId, string category, string seriesName, string status, string? seriesDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _managePcSeriesService.EditPcSeries(accessToken, pcSeriesId, seriesName, status, category, seriesDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ManagePcSeries/ViewPcSeries",
                    _managePcSeriesService.GetPcSeriesList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                SetTempDataForManagePcSeries(int.Parse(editResult));
                return View("../../Views/Admin/ManagePcSeries/AddEditPcSeries");
            }
        }

        public IActionResult DeletePcSeries(string pcSeriesId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _managePcSeriesService.DeletePcSeries(accessToken, pcSeriesId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ManagePcSeries/ViewPcSeries",
                    _managePcSeriesService.GetPcSeriesList());
            }
            else
            {
                SetTempDataForManagePcSeries(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ManagePcSeries/DeleteEditPcSeries");
            }
        }

        private void SetTempDataForManagePcSeries(int pcSeriesId)
        {
            ArrayList tempDataList = _managePcSeriesService.GetTempDataForAddEditPcSeries(pcSeriesId);
            TempData["categoryList"] = (List<PcCategory>)tempDataList[0];
            if (pcSeriesId != -1)
            {
                TempData["selectedSeries"] = (PcSeries)tempDataList[1];
            }
        }
    }
}
