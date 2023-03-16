using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComMaster.Business.Interfaces.Home;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComMaster.Controllers.Home
{
    public class SeriesController : Controller
    {
        private readonly IManageSeriesService manageSeriesService;

        public SeriesController(IManageSeriesService manageSeriesService)
        {
            this.manageSeriesService = manageSeriesService;
        }


        // GET: /<controller>/
        public IActionResult Index(string categoryId)
        {

            
            //string jsCode = "<string>alert('Hello World');</script>";
            //return Content(jsCode, "text/html");
            return View("../../Views/Home/Series/index", manageSeriesService.GetPcSeries(categoryId));
        }
    }
}

