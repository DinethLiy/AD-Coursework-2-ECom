using eComMaster.Models.MasterData;

namespace eComMaster.Business.Interfaces.Admin
{
    public interface IManagePcCategoriesService
    {
        List<PcCategory> GetPcCategoriesList();
        PcCategory? GetTempDataForAddEditPcCategory(int pcCategoryId);
        string AddPcCategory(string accessToken, string categoryName, string? categoryDesc);
        string EditPcCategory(string accessToken, string pcCategoryId, string categoryName, string status, string? categoryDesc);
        string DeletePcCategory(string accessToken, string pcCategoryId);
    }
}
