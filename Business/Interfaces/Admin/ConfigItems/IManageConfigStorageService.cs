using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigStorageService
    {
        List<ConfigStorage> GetConfigStorageList();
        ConfigStorage? GetTempDataForAddEditConfigStorage(int configStorageId);
        string AddConfigStorage(string accessToken, string storageName, string price, string? storageDesc);
        string EditConfigStorage(string accessToken, string storageId, string storageName, string price, string status, string? storageDesc);
        string DeleteConfigStorage(string accessToken, string storageId);
    }
}
