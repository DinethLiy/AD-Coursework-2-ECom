using System;
using System.Net.NetworkInformation;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Data;
using eComMaster.Models.CustomerData;
using Microsoft.EntityFrameworkCore;

namespace eComMaster.Business.Services.Home
{
	public class ManageOrdersService: IManageOrdersService
	{
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageOrdersService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        public List<Order> GetOrderList(string authToken)
        {
            var user = _authService.GetLoggedInUser(authToken);

           
            return _context.Order
                .Include(o => o.PcModel)
                .Include(o => o.Customer)
                .Where(o => o.DELETED_BY == null && o.CREATED_BY == user)
                .ToList();
        }
        public Order GetOrder(int orderId)
        {
            // your code to find the order by id
            var order = _context.Order.FirstOrDefault(o => o.ORDER_ID == orderId);


            // pass the order to the view
            return order;
        }
        public int CancelOrder(Order order, string accessToken) {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundOrder = GetOrder(order.ORDER_ID);
            foundOrder.ORDER_STATUS = "CANCELLED";
            foundOrder.MODIFIED_BY = foundUser;
            foundOrder.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
       
        }
    }
}

