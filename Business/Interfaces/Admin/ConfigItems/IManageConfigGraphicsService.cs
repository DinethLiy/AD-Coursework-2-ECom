using eComMaster.Models.MasterData.ConfigItems;

namespace eComMaster.Business.Interfaces.Admin.ConfigItems
{
    public interface IManageConfigGraphicsService
    {
        List<ConfigGraphics> GetConfigGraphicsList();
        ConfigGraphics? GetTempDataForAddEditConfigGraphics(int configGraphicsId);
        string AddConfigGraphics(string accessToken, string graphicsName, string price, string? graphicsDesc);
        string EditConfigGraphics(string accessToken, string graphicsId, string graphicsName, string price, string status, string? graphicsDesc);
        string DeleteConfigGraphics(string accessToken, string graphicsId);
    }
}
