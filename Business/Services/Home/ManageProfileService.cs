using System;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using eComMaster.Data.Utility;
using eComMaster.Models.Auth;
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
        public string SignUpUser(string username, string password)
        {
            EncryptDecryptText encryptDecryptText = new();
            string encryptedPassword = "";
            if (password != null)
            {
                encryptedPassword = encryptDecryptText.EncryptText(password);
            }
            AuthUser authUser = new AuthUser();
            // Set default values
            authUser.PRIVILEGE_TYPE = "CUSTOMER";
            authUser.USER_STATUS = "ACT";
            authUser.USERNAME = username;
            authUser.PASSWORD = encryptedPassword;
            // Add the new user to the context
            _applicationDbContext.AuthUser.Add(authUser);
            _applicationDbContext.SaveChanges();
            return "Success";

        }

        public string customerID(string accessToken)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            if (foundUser == null)
            {
                return "error";
            }
            else
            {
                var customer = _applicationDbContext.Customer.FirstOrDefault(c => c.USER_ID == foundUser);

                if (customer == null)
                {
                    return "error";
                }
                return customer.CUSTOMER_STATUS.ToString();
            }
        }
            public string findCustomerID(string accessToken)
            {
                var foundUser = _authService.GetLoggedInUser(accessToken);
                if (foundUser == null)
                {
                    return "error";
                }
                else
                {
                    var customer = _applicationDbContext.Customer.FirstOrDefault(c => c.USER_ID == foundUser);

                    if (customer == null)
                    {
                        return "error";
                    }
                    return customer.CUSTOMER_ID.ToString();
                }
        }
        public string findCustomerEmail(string accessToken)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            if (foundUser == null)
            {
                return "error";
            }
            else
            {
                var customer = _applicationDbContext.Customer.FirstOrDefault(c => c.USER_ID == foundUser);

                if (customer == null)
                {
                    return "error";
                }
                return customer.EMAIL.ToString();
            }

        }

    }
}

