using eComMaster.Models.MasterData;
using System.Collections;

namespace eComMaster.Business.Interfaces.Admin
{
    public interface IManagePcSeriesService
    {
        List<PcSeries> GetPcSeriesList();
        ArrayList GetTempDataForAddEditPcSeries(int pcSeriesId);
        string AddPcSeries(string accessToken, string seriesName, string category, string? seriesDesc);
        string EditPcSeries(string accessToken, string pcSeriesId, string seriesName, string status, string category, string? seriesDesc);
        string DeletePcSeries(string accessToken, string pcSeriesId);
    }
}
