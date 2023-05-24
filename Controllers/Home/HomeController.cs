using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Business.Interfaces.SuperAdmin;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComMaster.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IManageHomeService _manageHomeService;

        public HomeController(IManageHomeService manageHomeService)
        {
            _manageHomeService = manageHomeService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            string accessToken = Request.Cookies["access_token"] ?? "";
            ViewData["AccessToken"] = accessToken;
            return View("../../Views/Home/index",_manageHomeService.GetPcCategories());
        }
    }
}

