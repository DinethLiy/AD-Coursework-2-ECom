using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigPowerService
    {
        List<ConfigPower> GetConfigPowerList();
        ConfigPower? GetTempDataForAddEditConfigPower(int configPowerId);
        string AddConfigPower(string accessToken, string powerName, string price, string? powerDesc);
        string EditConfigPower(string accessToken, string powerId, string powerName, string price, string status, string? powerDesc);
        string DeleteConfigPower(string accessToken, string powerId);
    }
}
