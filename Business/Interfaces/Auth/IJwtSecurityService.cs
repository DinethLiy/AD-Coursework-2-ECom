using eComMaster.Models.Auth;

namespace eComMaster.Business.Interfaces.Auth
{
    public interface IJwtSecurityService
    {
        string JwtAuthentication(AuthUser user);
    }
}
