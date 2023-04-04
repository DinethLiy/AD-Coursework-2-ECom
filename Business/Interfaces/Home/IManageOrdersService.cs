using System;
using eComMaster.Models.CustomerData;

namespace eComMaster.Business.Interfaces.Home
{
	public interface IManageOrdersService
	{
        List<Order> GetOrderList(string authToken);
    }
}

