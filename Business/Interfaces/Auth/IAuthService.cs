using eComMaster.Models.Auth;

namespace eComMaster.Business.Interfaces.Auth
{
	public interface IAuthService
	{
		string LoginUser(string username, string password);
		string GetToken();
		CookieOptions GetCookieOptions();
		string GetPrivilegeType();
		AuthUser? GetLoggedInUser(string accessToken);
    }
}
