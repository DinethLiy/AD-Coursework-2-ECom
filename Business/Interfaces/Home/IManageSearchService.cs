using System;
using eComMaster.Models.MasterData;

namespace eComMaster.Business.Interfaces.Home
{
	public interface IManageSearchService
	{
		public List<PcModel> SearchModels(string term);
	}
}

