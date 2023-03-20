namespace eComMaster.Business.Interfaces.Admin
{
    public interface IAdminHomeService
    {
        int GetPendingOrderCount();
        int GetOutOfStockModelCount();
        int GetMonthlyOrderCount();
        string GetMonthlyRevenue();
    }
}
