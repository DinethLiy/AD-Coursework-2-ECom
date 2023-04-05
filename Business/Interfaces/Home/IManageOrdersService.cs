using System;
using eComMaster.Models.CustomerData;

namespace eComMaster.Business.Interfaces.Home
{
	public interface IManageOrdersService
	{
        List<Order> GetOrderList(string authToken);
        public Order GetOrder(int orderId);
        public int CancelOrder(Order order, string accessToken);
    }
}

