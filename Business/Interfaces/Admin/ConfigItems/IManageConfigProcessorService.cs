using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigProcessorService
    {
        List<ConfigProcessor> GetConfigProcessorList();
        ConfigProcessor? GetTempDataForAddEditConfigProcessor(int configProcessorId);
        string AddConfigProcessor(string accessToken, string processorName, string price, string? processorDesc);
        string EditConfigProcessor(string accessToken, string processorId, string processorName, string price, string status, string? processorDesc);
        string DeleteConfigProcessor(string accessToken, string processorId);
    }
}
