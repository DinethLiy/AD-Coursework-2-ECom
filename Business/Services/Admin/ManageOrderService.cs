using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Data;
using eComMaster.Models.CustomerData;
using eComMaster.Models.MasterData;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace eComMaster.Business.Services.Admin
{
    public class ManageOrderService : IManageOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public ManageOrderService(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public List<Order> GetOrderList()
        {
            return _context.Order
                .Include(o => o.PcModel)
                .Include(o => o.Customer)
                .Where(o => o.DELETED_BY == null)
                .ToList();
        }

        public Order GetTempDataForEditOrder(int orderId)
        {
            return GetOrder(orderId.ToString());
        }

        // Admins may only edit the "Status" of an order.
        public string EditOrder(string accessToken, string orderId, string status)
        {
            var foundUser = _authService.GetLoggedInUser(accessToken);
            var foundOrder = GetOrder(orderId);
            foundOrder.ORDER_STATUS = status;
            foundOrder.MODIFIED_BY = foundUser;
            foundOrder.MODIFIED_DATE = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return "success";
            }
            catch
            {
                return orderId;
            }
        }

        private Order GetOrder(string orderId) 
        {
            return _context.Order
                        .Include(o => o.PcModel)
                        .Include(o => o.Customer)
                        .Where(o => o.ORDER_ID == int.Parse(orderId))
                        .FirstOrDefault();
        }
    }
}
