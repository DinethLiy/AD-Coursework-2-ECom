using System;
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
    }
}

