using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigPortsService
    {
        List<ConfigPorts> GetConfigPortsList();
        ConfigPorts? GetTempDataForAddEditConfigPorts(int configPortsId);
        string AddConfigPorts(string accessToken, string portsName, string price, string? portsDesc);
        string EditConfigPorts(string accessToken, string portsId, string portsName, string price, string status, string? portsDesc);
        string DeleteConfigPorts(string accessToken, string portsId);
    }
}
