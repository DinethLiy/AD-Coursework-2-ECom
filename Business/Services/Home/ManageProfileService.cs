using System;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using eComMaster.Models.CustomerData;

namespace eComMaster.Business.Services.Home
{
	public class ManageProfileService: IManageProfileService
    {
		private readonly ApplicationDbContext _applicationDbContext;
        private readonly IAuthService _authService;
        public ManageProfileService(ApplicationDbContext applicationDbContext, IAuthService authService)
        {
            this._applicationDbContext = applicationDbContext;
            this._authService = authService;
        }
        
        public string CreateCustomerProfile(Customer customer, string accessToken) {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            if (foundUser == null)
            {
                return "error, no user";
            }
            else
            {

                customer.USER_ID = foundUser;
               
                _applicationDbContext.Customer.Add(customer);
                try
                {
                    _applicationDbContext.SaveChanges();
                    return "success";
                }
                catch(Exception ex)
                {
                    return ex.ToString();
                }
              
            }
        }

        public string customerID(string accessToken)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            if (foundUser == null)
            {
                return "error";
            }
            else {
                var customer = _applicationDbContext.Customer.FirstOrDefault(c => c.USER_ID == foundUser);
                
                if (customer == null)
                {
                    return "error";
                }
                return customer.CUSTOMER_STATUS.ToString();
            }
        }
    }
}

