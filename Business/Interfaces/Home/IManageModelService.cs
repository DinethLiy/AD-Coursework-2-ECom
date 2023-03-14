using System;
using eComMaster.Models.MasterData;

namespace eComMaster.Business.Interfaces.Home
{
	public interface IManageModelService
    {
		List<Models.MasterData.PcModel> GetPcModels(int pcSeriesId);
	}
}

