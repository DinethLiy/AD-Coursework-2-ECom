using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigMemoryService
    {
        List<ConfigMemory> GetConfigMemoryList();
        ConfigMemory? GetTempDataForAddEditConfigMemory(int configMemoryId);
        string AddConfigMemory(string accessToken, string memoryName, string price, string? memoryDesc);
        string EditConfigMemory(string accessToken, string memoryId, string memoryName, string price, string status, string? memoryDesc);
        string DeleteConfigMemory(string accessToken, string memoryId);
    }
}
