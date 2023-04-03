using System;
using System.Collections;
using eComMaster.Models.MasterData;

namespace eComMaster.Business.Interfaces.Home
{
	public interface IManageModelService
    {
		List<Models.MasterData.PcModel> GetPcModels(int pcSeriesId, string accessToken);
        ArrayList GetTempDataForAddEditPcModel(int pcModelId);
        PcModel getPcModelForId(int id);
        string AddCustomPcModel(string accessToken, string modelName, string series, string price, string quantity, string casing, string display, string graphics, string memory, string misc, string ports, string power, string processor, string storage, string? modelDesc);

    }
}

