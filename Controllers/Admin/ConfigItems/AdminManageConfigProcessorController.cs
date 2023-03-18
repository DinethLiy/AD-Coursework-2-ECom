using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    public class AdminManageConfigProcessorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
