using eComMaster.Models.CustomerData;

namespace eComMaster.Business.Interfaces.Admin
{
    public interface IManageOrderService
    {
        List<Order> GetOrderList();
        Order GetTempDataForEditOrder(int orderId);
        string EditOrder(string accessToken, string orderId, string status);
    }
}
