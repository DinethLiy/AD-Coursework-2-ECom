using eComMaster.Models.MasterData;
using System.Collections;

namespace eComMaster.Business.Interfaces.Admin
{
    public interface IManagePcModelService
    {
        List<PcModel> GetPcModelList();
        ArrayList GetTempDataForAddEditPcModel(int pcModelId);
        string AddPcModel(string accessToken, string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string? modelDesc);
        string EditPcModel(string accessToken, string pcModelId, string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string status, string? modelDesc);
        string DeletePcModel(string accessToken, string pcModelId);
    }
}
