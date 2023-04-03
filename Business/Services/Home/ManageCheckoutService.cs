using System;
using System.Text.Json;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using eComMaster.Models.CustomerData;
using eComMaster.Models.MasterData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eComMaster.Business.Services.Home
{
	public class ManageCheckoutService: iManageCheckoutService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public ManageCheckoutService(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public decimal price { get; set; }
            public int quantity { get; set; }
        }
        public string Create([Bind("ORDER_ID,PC_MODEL_ID,CUSTOMER_ID,ORDER_AMOUNT,ORDER_STATUS,CREATED_DATE,MODIFIED_DATE,DELETED_DATE")] Order order)
        {
           
            _applicationDbContext.Add(order);
            return "success";
            
        }
        public string makeOrder(IFormCollection form, string token, IAuthService _authService, string customerID)
        {
            var user = _authService.GetLoggedInUser(token);

            string jsonString = form["pcModel"];
            string trimmedString = jsonString.TrimStart().TrimEnd();
            dynamic jsonObj = JsonConvert.DeserializeObject(trimmedString);
            int id = jsonObj.id;
            if (id == null)
            {
                
                return "error";
            }


         
            int customerId = user.USER_ID;
            decimal orderAmount = decimal.Parse(form["final_price"]);

         
            Customer customer = _applicationDbContext.Customer.Find(customerId);
            PcModel pcModel = _applicationDbContext.PcModel.Find(id);
            var id_pc_model = pcModel.PC_MODEL_ID;

           // Create a new order object with the necessary data
           Order order = new Order
           {
               
               PC_MODEL_ID = id_pc_model,
               CUSTOMER_ID = customerId,
            
               ORDER_AMOUNT = orderAmount,
               ORDER_STATUS = "PENDING",
               CREATED_BY = user,
               CREATED_DATE = DateTime.Now
           };

            // Add the order object to the context and save changes to the database
            _applicationDbContext.Order.Add(order);
            _applicationDbContext.SaveChanges();
            int orderId = order.ORDER_ID;
            Payment payment = new Payment {
                ORDER_ID = orderId,
                TRANSACTION_DATE = DateTime.Now,
                PAYMENT_CODE = Guid.NewGuid().ToString(),
                PAYMENT_STATUS = "PAID",
                AMOUNT = order.ORDER_AMOUNT
            };
            _applicationDbContext.Payment.Add(payment);
            _applicationDbContext.SaveChanges();

            CheckoutModel checkoutModel = new CheckoutModel();
            checkoutModel.NameBilling = form["billing_name"];
            checkoutModel.BillingAddress = form["billing_address"];
            checkoutModel.BillingCity = form["billing_city"];
            checkoutModel.BillingState = form["billing_province"];
            checkoutModel.BillingZip = form["billing_zip"];
            checkoutModel.NameShipping = form["shipping_name"];
            checkoutModel.ShippingAddress = form["shipping_address"];
            checkoutModel.ShippingCity = form["shipping_city"];
            checkoutModel.ShippingState = form["shipping_province"];
            checkoutModel.ShippingZip = form["shipping_zip"];
            checkoutModel.ORDER_ID = orderId;
            checkoutModel.PaymentMethod = "CARD";
            
            if (form["same_address"] == "on")
            {
                checkoutModel.SameAddress = true;
            }
            else
            {
                checkoutModel.SameAddress = false;
            }
            _applicationDbContext.CheckoutModel.Add(checkoutModel);
            _applicationDbContext.SaveChanges();

            /*
             * 
             *  @Html.Hidden("billing_name", billing_name)
                                @Html.Hidden("billing_address", billing_address)
                                @Html.Hidden("billing_city", billing_city)
                                @Html.Hidden("billing_province", billing_province)
                                @Html.Hidden("billing_zip", billing_zip)
                                @Html.Hidden("shipping_name", shipping_name)
                                @Html.Hidden("shipping_address", shipping_address)
                                @Html.Hidden("shipping_city", shipping_city)
                                @Html.Hidden("shipping_province", shipping_province)
                                @Html.Hidden("shipping_zip", shipping_zip)
                                @Html.Hidden("same_address", formCollection["same_address"])
                                @Html.Hidden("final_price", final_price)
                                @Html.Hidden("pcModel", formCollection["pcModel"])
                   public int CHECKOUT_ID { get; set; }
        public string? NameBilling { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingZip { get; set; }

        public string? NameShipping { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingState { get; set; }
        public string? ShippingZip { get; set; }

        [ForeignKey("Order")]
        public int ORDER_ID { get; set; }
        public Order Order { get; set; }

        public bool SameAddress { get; set; }

        public string PaymentMethod { get; set; }
            */
            // Redirect to the current page after a delay with the form data as a post request
            //string redirectUrl = Request.Headers["Referer"].ToString();
            //TempData["formData"] = form;
            return "success";
        }
    }
}

