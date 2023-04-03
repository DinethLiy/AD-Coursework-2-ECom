using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Business.Services.Home;
using eComMaster.Data.Utility;
using eComMaster.Models.CustomerData;
using eComMaster.Models.MasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eComMaster.Controllers.Home
{
    [Authorization(RequiredPrivilegeType = "CUSTOMER")]
    public class PayController : Controller
    {
        private readonly IAuthService _authService;
        private readonly iManageCheckoutService _manageCheckoutService;
        private readonly IManageProfileService _manageProfileService;
        public PayController(IAuthService authService, iManageCheckoutService iManageCheckoutService, IManageProfileService manageProfileService)
        {
            this._manageProfileService = manageProfileService;
            _authService = authService;
            _manageCheckoutService = iManageCheckoutService;
        }

        public ActionResult Index(string pcModel, string count)
        {

            string accessToken = Request.Cookies["access_token"];
            if (_manageProfileService.customerID(accessToken) != "ACT")
            {
                return View("../../Views/CustomerProfile/Create");
            }
            else
            {

                var pcModelObject = JsonConvert.DeserializeObject(pcModel);

                // Store the pcModel and count values in ViewData to pass them to the view
                ViewData["pcModel"] = pcModelObject;
                ViewData["count"] = count;

                return View("../../Views/Home/Pay/Index");
            }
        }
        // GET: Pay
        [HttpPost]
        public ActionResult Index([FromBody] dynamic data)
        {
            // Get the PC model and count from the data object
            string pcModelJson = data.pcModel.ToString();
            int count = (int)data.count;

            // Convert the JSON string to an object
            var pcModel = JsonConvert.DeserializeObject<PcModel>(pcModelJson);

            // Do something with the PC model and count
            
            // Return the payment page URL
            //return Ok(new { url = "/Payment" });
            return View("../../Views/Home/Pay/Index");
        }
        [HttpPost]
        public ActionResult Checkout(Microsoft.AspNetCore.Http.IFormCollection form)
        {
            ViewBag.FormCollection = form;
            // sending previously received form data including billing, shipping and product information

            
            return View("../../Views/Home/Pay/Checkout");
        }
       
        [HttpPost]
        public IActionResult Index(string billing_name, string billing_address, string billing_city, string billing_state, string billing_zip,
           string shipping_name, string shipping_address, string shipping_city, string shipping_state, string shipping_zip,
           bool same_address, string payment_method)
        {
            // Do something with the form data
            // For example, you could save it to a database or process a payment using the payment_method

            return RedirectToAction("Confirmation");
        }
        [HttpPost]
        public IActionResult SecuredPay(IFormCollection form) {
            string accessToken = Request.Cookies["access_token"];
            string customer_id = _manageProfileService.findCustomerID(accessToken);


            if (customer_id == null)
            {
                return View("../../Views/CustomerProfile/Create");
            }
            string result = _manageCheckoutService.makeOrder(form, accessToken, _authService, customer_id);
            
        

            return View("../../Views/Home/Pay/SecuredPay");
             }
      
        public ActionResult PaymentSuccess()
        {
            return View("../../Views/Home/Pay/Success");
        }
    }
}


