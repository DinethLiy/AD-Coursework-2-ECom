using eComMaster.Business.Interfaces.Home;
using eComMaster.Models.MasterData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
          
        }

        public IActionResult Index()
        {
        
            // Get the PC model details from the sessionStorage object
            var pcModel = GetPCModelFromSessionStorage();

            return View("../../Views/Home/Cart/Index",pcModel);
        }

        [HttpPost]
        public IActionResult UpdateCart(PcModel pcModel)
        {
            // Update the PC model details in the sessionStorage object
            SetPCModelInSessionStorage(pcModel);

            // Return a success message
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            // Clear the PC model from the sessionStorage object
            ClearPCModelFromSessionStorage();

            // Return a success message
            return Json(new { success = true });
        }

        private PcModel GetPCModelFromSessionStorage()
        {
            // Get the PC model details from the sessionStorage object
            var pcModelString = HttpContext.Session.GetString("pcModel");

            // If the PC model is not found in the sessionStorage object, return null
            if (string.IsNullOrEmpty(pcModelString))
            {
                return null;
            }

            // Deserialize the PC model JSON string into a PCModel object
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PcModel>(pcModelString);
        }

        private void SetPCModelInSessionStorage(PcModel pcModel)
        {
            // Serialize the PC model object into a JSON string
            var pcModelString = Newtonsoft.Json.JsonConvert.SerializeObject(pcModel);

            // Save the PC model JSON string to the sessionStorage object
            HttpContext.Session.SetString("pcModel", pcModelString);
        }

        private void ClearPCModelFromSessionStorage()
        {
            // Remove the PC model from the sessionStorage object
            HttpContext.Session.Remove("pcModel");
        }
       
      
        }

    
}
