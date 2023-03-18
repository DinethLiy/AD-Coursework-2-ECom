using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    public class AdminManageConfigStorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
