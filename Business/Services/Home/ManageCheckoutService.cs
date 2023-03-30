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
        public string makeOrder(IFormCollection form, string token, IAuthService _authService)
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
               CUSTOMER_ID = user.USER_ID,
            
               ORDER_AMOUNT = orderAmount,
               ORDER_STATUS = "PENDING",
               CREATED_BY = user,
               CREATED_DATE = DateTime.Now
           };

            // Add the order object to the context and save changes to the database
            _applicationDbContext.Order.Add(order);
            _applicationDbContext.SaveChanges();

            // Redirect to the current page after a delay with the form data as a post request
            //string redirectUrl = Request.Headers["Referer"].ToString();
            //TempData["formData"] = form;
            return "Success";
        }
    }
}

