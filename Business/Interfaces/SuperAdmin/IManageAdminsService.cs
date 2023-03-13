using eComMaster.Models.Auth;
using System.Collections;

namespace eComMaster.Business.Interfaces.SuperAdmin
{
    public interface IManageAdminsService
    {
        List<AuthUser> GetAdminList();
        ArrayList? GetTempDataForAddEditAdmins(int userId, string? encryptedPassword);
        string AddAdmin(string username, string password, string confirmPassword, string type);
        string EditAdmin(string userId, string username, string password, string confirmPassword, string type, string status);
    }
}
