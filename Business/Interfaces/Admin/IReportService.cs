using eComMaster.Models.MasterData;

namespace eComMaster.Business.Interfaces.Admin
{
    public interface IReportService
    {
        List<PcSeries> GetPcSeriesList();
        List<PcModel> GetPcModelList();
        MemoryStream GenerateOrderReport(string price);
        MemoryStream GeneratePcModelReport(string pcSeriesId);
        MemoryStream GeneratePaymentReport(string pcModelId);
    }
}
