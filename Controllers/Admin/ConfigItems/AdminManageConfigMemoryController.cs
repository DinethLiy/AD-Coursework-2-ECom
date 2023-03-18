using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    public class AdminManageConfigMemoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
