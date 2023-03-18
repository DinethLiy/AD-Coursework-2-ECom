using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigMiscService
    {
        List<ConfigMisc> GetConfigMiscList();
        ConfigMisc? GetTempDataForAddEditConfigMisc(int configMiscId);
        string AddConfigMisc(string accessToken, string miscName, string price, string? miscDesc);
        string EditConfigMisc(string accessToken, string miscId, string miscName, string price, string status, string? miscDesc);
        string DeleteConfigMisc(string accessToken, string miscId);
    }
}
