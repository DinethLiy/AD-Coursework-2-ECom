using System;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data.Utility;
using eComMaster.Models.MasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Home
{
    [Authorization(RequiredPrivilegeType = "CUSTOMER")]
    public class OrdersController: Controller
	{
        private readonly IManageOrdersService manageOrdersService;

       
        public OrdersController(IManageOrdersService manageOrdersService)
        {
            this.manageOrdersService = manageOrdersService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            string accessToken = Request.Cookies["access_token"] ?? "";
            

            return View("../../Views/Home/Orders/Index",manageOrdersService.GetOrderList(accessToken));
            //return View("../../Views/Home/index", _manageHomeService.GetPcCategories());
        }
    }
}

