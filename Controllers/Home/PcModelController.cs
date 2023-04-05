using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComMaster.Controllers.Home
{
    public class PcModelController : Controller
    {
        private readonly IManageModelService _manageModelService;
        private int _pcSeriesID;
        public PcModelController(IManageModelService manageModelService)
        {
           
            this._manageModelService = manageModelService;
        }

        public IActionResult Index(int pcSeriesId)
        {
            string accessToken = Request.Cookies["access_token"] ?? "";
            _pcSeriesID = pcSeriesId;
            return View("../../Views/Home/PcModel/Index", _manageModelService.GetPcModels(pcSeriesId,accessToken));
        }

        // GET: PcModel/View/5
        public ActionResult View(int id)
        {
            SetViewBagsForManagePcModel(id);
            return View("../../Views/Home/PcModel/View", _manageModelService.getPcModelForId(id));
        }
        private void SetViewBagsForManagePcModel(int pcModelId)
        {
            ArrayList viewBagList = _manageModelService.GetTempDataForAddEditPcModel(pcModelId);

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

        [Authorization(RequiredPrivilegeType = "CUSTOMER")]
        [HttpPost]
        public IActionResult AddCustomPcModel(string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string? modelDesc)
        {
            string accessToken = Request.Cookies["access_token"];
            string seriesM = series;
            string casingM = casing;
            string insertResult = _manageModelService.AddCustomPcModel(accessToken, modelName, series, price, quantity, casing, display, graphics, memory, misc, ports, power, processor, storage, modelDesc);
            if (insertResult == "success")
            {
                return View("../../Views/Home/PcModel/Index", _manageModelService.GetPcModels(_pcSeriesID, accessToken));

            }
            else
            {
                ModelState.AddModelError("", "Error, Please enter valid values into the fields.");
                return View("../../Views/Home/PcModel/Index", _manageModelService.GetPcModels(_pcSeriesID, accessToken));

            }
        }
    }
}

