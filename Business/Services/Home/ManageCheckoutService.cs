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
            

            //if (pcModelIdToken != null)
            //{
            //    string pcModelId = pcModelIdToken.Value<string>();
            //    // Do something with pcModelId
            //}
            //else
            //{
            //    // Handle the case where the key does not exist in the JObject
            //}

            //// Retrieve the necessary data from the form
            ////int pcModelId = int.Parse(form["PC_MODEL_ID"]);
            //int customerId = user.USER_ID;
            //decimal orderAmount = decimal.Parse(form["final_price"]);

            //// Retrieve the corresponding PC model and customer from the database
            ////PcModel pcModel = form;
            //Customer customer = _context.Customers.Find(customerId);

            //// Create a new order object with the necessary data
            //Order order = new Order
            //{
            //    PcModel = pcModel,
            //    Customer = customer,
            //    ORDER_AMOUNT = orderAmount,
            //    ORDER_STATUS = "PENDING"
            //};

            //// Add the order object to the context and save changes to the database
            //_context.Orders.Add(order);
            //_context.SaveChanges();

            //// Redirect to the current page after a delay with the form data as a post request
            //string redirectUrl = Request.Headers["Referer"].ToString();
            //TempData["formData"] = form;
            return "";
        }
    }
}

