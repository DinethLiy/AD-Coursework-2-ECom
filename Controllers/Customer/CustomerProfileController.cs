using Microsoft.AspNetCore.Mvc;
using eComMaster.Models.CustomerData;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data.Utility;

namespace eComMaster.Controllers.Customer
{
    [Authorization(RequiredPrivilegeType = "CUSTOMER")]
    public class CustomerProfileController : Controller
    {
        private readonly IManageProfileService manageProfileService;


        public CustomerProfileController(IManageProfileService manageProfileService)
        {
            this.manageProfileService = manageProfileService;
        }

        public IActionResult Index()
        {
           
            return View("../../Views/CustomerProfile/CustomerProfileView");
        }
        public IActionResult Create()
        {

            return View("../../Views/CustomerProfile/Create");
        }
        [HttpPost]
        public ActionResult Save(eComMaster.Models.CustomerData.Customer model)
        {
            // Save the form data to the database or perform any other necessary operations
            // Here, CustomerModel represents the model that you use to bind the form data to the server-side code
            string accessToken = Request.Cookies["access_token"];


            var result = manageProfileService.CreateCustomerProfile(model, accessToken);
            
            return RedirectToAction("Index", "Cart"); // Redirect to the home page after successful form submission
        }
    }
}
