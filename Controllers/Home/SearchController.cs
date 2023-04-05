using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComMaster.Business.Services.Home;
using eComMaster.Data;
using eComMaster.Models.MasterData;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComMaster.Controllers.Home
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SearchController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //private readonly ManageSearchService manageSearchService;

        //public SearchController(ManageSearchService manageSearchService)
        //{
        //    this.manageSearchService = manageSearchService;
        //}

        // GET: /<controller>/
        public IActionResult Index(string searchTerm)
        {
     
            string accessToken = Request.Cookies["access_token"] ?? "";
            var matchingModels = applicationDbContext.PcModel
              .Where(m => m.PC_MODEL_NAME.Contains(searchTerm))
              .ToList();

            return View("../../Views/Home/PcModel/Index", matchingModels);
          //  return View("../../Views/Home/PcModel/Index",manageSearchService.SearchModels(searchTerm));

            
        }
    }
}

