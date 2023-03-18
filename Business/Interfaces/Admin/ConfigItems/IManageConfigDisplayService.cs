using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigDisplayService
    {
        List<ConfigDisplay> GetConfigDisplayList();
        ConfigDisplay? GetTempDataForAddEditConfigDisplay(int configDisplayId);
        string AddConfigDisplay(string accessToken, string displayName, string price, string? displayDesc);
        string EditConfigDisplay(string accessToken, string displayId, string displayName, string price, string status, string? displayDesc);
        string DeleteConfigDisplay(string accessToken, string displayId);
    }
}
