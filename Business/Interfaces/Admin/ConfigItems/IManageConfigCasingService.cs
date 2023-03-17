using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigCasingService
    {
        List<ConfigCasing> GetConfigCasingList();
        ConfigCasing? GetTempDataForAddEditConfigCasing(int configCasingId);
        string AddConfigCasing(string accessToken, string casingName, string price, string? casingDesc);
        string EditConfigCasing(string accessToken, string casingId, string casingName, string price, string status, string? casingDesc);
        string DeleteConfigCasing(string accessToken, string casingId);
    }
}
