using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Admin.ConfigItems
{
    public class AdminManageConfigDisplayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
