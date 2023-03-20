using eComMaster.Business.Interfaces.Admin;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace eComMaster.Controllers.Admin
{
    [Authorization(RequiredPrivilegeType = "ADMIN")]
    public class ManagePcModelController : Controller
    {
        private readonly IManagePcModelService _managePcModelService;

        public ManagePcModelController(IManagePcModelService managePcModelService)
        {
            _managePcModelService = managePcModelService;
        }

        public IActionResult Index()
        {
            return View("../../Views/Admin/ManagePcModel/ViewPcModel",
                _managePcModelService.GetPcModelList());
        }

        public IActionResult ShowAddEditPcModel(int pcModelId)
        {
            SetViewBagsForManagePcModel(pcModelId);
            return View("../../Views/Admin/ManagePcModel/AddEditPcModel");
        }

        public IActionResult ShowDeletePcModel(int pcModelId)
        {
            SetViewBagsForManagePcModel(pcModelId);
            return View("../../Views/Admin/ManagePcModel/DeletePcModel");
        }

        [HttpPost]
        public IActionResult AddPcModel(string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string? modelDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string insertResult = _managePcModelService.AddPcModel(accessToken, modelName, series, price, quantity, casing, display, graphics, memory, misc, ports, power, processor, storage, modelDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Admin/ManagePcModel/ViewPcModel",
                    _managePcModelService.GetPcModelList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                SetViewBagsForManagePcModel(-1);
                return View("../../Views/Admin/ManagePcModel/AddEditPcModel");
            }
        }

        [HttpPost]
        public IActionResult EditPcModel(string pcModelId, string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string status, string? modelDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string editResult = _managePcModelService.EditPcModel(accessToken, pcModelId, modelName, series, price, quantity, casing, display, graphics, memory, misc, ports, power, processor, storage, status, modelDesc);
            if (editResult == "success")
            {
                return View("../../Views/Admin/ManagePcModel/ViewPcModel",
                    _managePcModelService.GetPcModelList());
            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                SetViewBagsForManagePcModel(int.Parse(editResult));
                return View("../../Views/Admin/ManagePcModel/AddEditPcModel");
            }
        }

        public IActionResult DeletePcModel(string pcModelId)
        {
            string accessToken = Request.Cookies["access_token"];
            string deleteResult = _managePcModelService.DeletePcModel(accessToken, pcModelId);
            if (deleteResult == "success")
            {
                return View("../../Views/Admin/ManagePcModel/ViewPcModel",
                    _managePcModelService.GetPcModelList());
            }
            else
            {
                SetViewBagsForManagePcModel(int.Parse(deleteResult));
                ModelState.AddModelError("", "System Error, please contact Administration");
                return View("../../Views/Admin/ManagePcModel/DeleteEditPcModel");
            }
        }

        private void SetViewBagsForManagePcModel(int pcModelId)
        {
            ArrayList viewBagList = _managePcModelService.GetTempDataForAddEditPcModel(pcModelId);

            // ViewBags are used here instead of TempData because TempData cannot store this much different data types.
            ViewBag.seriesList = (List<PcSeries>)viewBagList[0];
            ViewBag.casingList = (List<ConfigCasing>)viewBagList[1];
            ViewBag.displayList = (List<ConfigDisplay>)viewBagList[2];
            ViewBag.graphicsList = (List<ConfigGraphics>)viewBagList[3];
            ViewBag.memoryList = (List<ConfigMemory>)viewBagList[4];
            ViewBag.miscList = (List<ConfigMisc>)viewBagList[5];
            ViewBag.portsList = (List<ConfigPorts>)viewBagList[6];
            ViewBag.powerList = (List<ConfigPower>)viewBagList[7];
            ViewBag.processorList = (List<ConfigProcessor>)viewBagList[8];
            ViewBag.storageList = (List<ConfigStorage>)viewBagList[9];

            if (pcModelId != -1)
            {
                ViewBag.selectedModel = (PcModel)viewBagList[10];
            }
        }
    }
}
