using System;
using eComMaster.Business.Interfaces.Auth;

namespace eComMaster.Business.Interfaces.Home
{
	public interface iManageCheckoutService
	{
		public string makeOrder(IFormCollection form, string token, IAuthService _authService, string customerID);

	}
}

