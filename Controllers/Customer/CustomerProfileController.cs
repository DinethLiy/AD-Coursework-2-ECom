using Microsoft.AspNetCore.Mvc;
using eComMaster.Models.CustomerData;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data.Utility;

namespace eComMaster.Controllers.Customer
{
 
    public class CustomerProfileController : Controller
    {
        private readonly IManageProfileService manageProfileService;
        private readonly IManageHomeService _manageHomeService;


        public CustomerProfileController(IManageProfileService manageProfileService, IManageHomeService manageHomeService)
        {
            this.manageProfileService = manageProfileService;
            this._manageHomeService = manageHomeService;
        }

        [Authorization(RequiredPrivilegeType = "CUSTOMER")]
        public IActionResult Index()
        {
           
            return View("../../Views/CustomerProfile/CustomerProfileView");
        }
        [Authorization(RequiredPrivilegeType = "CUSTOMER")]
        public IActionResult Create()
        {

            return View("../../Views/CustomerProfile/Create");
        }
        [HttpPost]
        public RedirectToActionResult SignUp(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("SignUp", "CustomerProfile");
            }
            string status = manageProfileService.SignUpUser(username, password);
            
              return RedirectToAction("Index", "Auth");
            
            


        }
        public IActionResult SignUp()
        {
            string accessToken = Request.Cookies["access_token"] ?? "";
            ViewData["AccessToken"] = accessToken;
            return View("../../Views/CustomerProfile/SignUp", _manageHomeService.GetPcCategories());
        }
        [Authorization(RequiredPrivilegeType = "CUSTOMER")]
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
