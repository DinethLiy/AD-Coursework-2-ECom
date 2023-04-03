using System;
using eComMaster.Models.CustomerData;

namespace eComMaster.Business.Interfaces.Home
{
	public interface IManageProfileService
	{
		string CreateCustomerProfile(Customer customer, string accessToken);
		string customerID(string accessToken);
        string findCustomerID(string accessToken);
    }
}

