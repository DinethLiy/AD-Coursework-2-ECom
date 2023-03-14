using System;
using eComMaster.Models.MasterData;

namespace eComMaster.Business.Interfaces.Home
{
	public interface IManageHomeService
	{
		List<PcCategory> GetPcCategories();

    }
}

