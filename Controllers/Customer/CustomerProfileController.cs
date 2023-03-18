using Microsoft.AspNetCore.Mvc;

namespace eComMaster.Controllers.Customer
{
    public class CustomerProfileController : Controller
    {
        public IActionResult Index()
        {
           
            return View("../../Views/CustomerProfile/CustomerProfileView");
        }
    }
}
