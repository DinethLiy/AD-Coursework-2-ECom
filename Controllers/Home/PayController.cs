using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eComMaster.Data.Utility;
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
        public ActionResult Index(string pcModel, string count)
        {
            var pcModelObject = JsonConvert.DeserializeObject(pcModel);

            // Store the pcModel and count values in ViewData to pass them to the view
            ViewData["pcModel"] = pcModelObject;
            ViewData["count"] = count;
           // Console.WriteLine("hii");

//            @{
//                // Get the pcModel and count values from the ViewData
//                var pcModel = ViewData["pcModel"];
//                var count = ViewData["count"];
//            }

//< h1 > Index Page </ h1 >
//< p > pcModel: @pcModel </ p >
//< p > count: @count </ p >
            return View("../../Views/Home/Pay/Index");
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
            // Get the search parameters from the URL

            //string billingName = form["billing_name"];
            //string billingAddress = form["billing_address"];
            //string billingCity = form["billing_city"];
            //string billingState = form["billing_state"];
            //string billingZip = form["billing_zip"];

            //string shippingName = form["shipping_name"];
            //string shippingAddress = form["shipping_address"];
            //string shippingCity = form["shipping_city"];
            //string shippingState = form["shipping_state"];
            //string shippingZip = form["shipping_zip"];

            //string paymentMethod = form["payment_method"];

            ViewBag.FormCollection = form;
            // Do something with the form data

            //  return RedirectToAction("Confirmation");
            return View("../../Views/Home/Pay/Checkout");
        }
        public ActionResult Test()
        {
            return View("../../Views/Home/Pay/Test");
        }
        // POST: Pay
        //[HttpPost]
        //public ActionResult Index(FormCollection form)
        //{
        //    // Retrieve form values
        //    string nameOnCard = form["name"];
        //    string cardNumber = form["card-number"];
        //    string expiry = form["expiry"];
        //    string cvv = form["cvv"];
        //    string streetAddress = form["street-address"];
        //    string city = form["city"];
        //    string state = form["state"];
        //    string zipCode = form["zip-code"];

        //    // Process payment and save billing information

        //    // Redirect to success page
        //    return RedirectToAction("PaymentSuccess");
        //}

        [HttpPost]
        public IActionResult Index(string billing_name, string billing_address, string billing_city, string billing_state, string billing_zip,
           string shipping_name, string shipping_address, string shipping_city, string shipping_state, string shipping_zip,
           bool same_address, string payment_method)
        {
            // Do something with the form data
            // For example, you could save it to a database or process a payment using the payment_method

            return RedirectToAction("Confirmation");
        }

        //[HttpPost]
        //public IActionResult Checkout(FormCollection form)
        //{
            // create a new instance of your model
            //var model = new CheckoutViewModel();

            //// retrieve the form values and assign them to the model properties
            //model.BillingName = form["billing_name"];
            //model.BillingAddress = form["billing_address"];
            //model.BillingCity = form["billing_city"];
            //model.BillingState = form["billing_state"];
            //model.BillingZip = form["billing_zip"];
            //model.ShippingName = form["shipping_name"];
            //model.ShippingAddress = form["shipping_address"];
            //model.ShippingCity = form["shipping_city"];
            //model.ShippingState = form["shipping_state"];
            //model.ShippingZip = form["shipping_zip"];
            //model.PaymentMethod = form["payment_method"];

            // pass the model to the next view
            //return View("Confirmation", model);
      //  }

        public ActionResult PaymentSuccess()
        {
            return View();
        }
    }
}



//public class CheckoutController : Controller
//{
//    [HttpPost]
//    public IActionResult Index(CheckoutViewModel model)
//    {
//        if (ModelState.IsValid)
//        {
//            // Save the checkout details to the database or do other processing here
//            return RedirectToAction("ThankYou");
//        }

//        return View(model);
//    }

//    public IActionResult ThankYou()
//    {
//        return View();
//    }
//}

//public class CheckoutViewModel
//{
//    // Billing Address
//    [Required]
//    public string BillingName { get; set; }

//    [Required]
//    public string BillingAddress { get; set; }

//    [Required]
//    public string BillingCity { get; set; }

//    [Required]
//    public string BillingState { get; set; }

//    [Required]
//    public string BillingZip { get; set; }

//    // Shipping Address
//    public bool SameAddress { get; set; }

//    public string ShippingName { get; set; }

//    public string ShippingAddress { get; set; }

//    public string ShippingCity { get; set; }

//    public string ShippingState { get; set; }

//    public string ShippingZip { get; set; }

//    // Payment Method
//    [Required]
//    public string PaymentMethod { get; set; }
//}
