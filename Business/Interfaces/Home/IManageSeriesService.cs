using System;
using eComMaster.Models.MasterData;

namespace eComMaster.Business.Interfaces.Home
{
    public interface IManageSeriesService
    {

       List<PcSeries> GetPcSeries(string categoryId);
        
    }
}

