using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Models.MasterData;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComMaster.Controllers.Home
{
    public class PcModelController : Controller
    {
        private readonly IManageModelService _manageModelService;

        public PcModelController(IManageModelService manageModelService)
        {
           
            this._manageModelService = manageModelService;
        }

        public IActionResult Index(int pcSeriesId)
        {
           
            return View("../../Views/Home/PcModel/Index", _manageModelService.GetPcModels(pcSeriesId));
        }

        // GET: PcModel/View/5
        public ActionResult View(int id)
        {
           
            return View("../../Views/Home/PcModel/View", _manageModelService.getPcModelForId(id));
        }

    }
}

