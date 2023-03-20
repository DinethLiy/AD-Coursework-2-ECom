using eComMaster.Business.Interfaces.Admin;
using eComMaster.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eComMaster.Business.Services.Admin
{
    public class AdminHomeService : IAdminHomeService
    {
        private readonly ApplicationDbContext _context;

        public AdminHomeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Methods that provide the summary data shown in the Admin Home/Dashboard
        public int GetPendingOrderCount() 
        {
            var pendingOrderCount = _context.Order
                .Where(o => o.ORDER_STATUS == "PENDING"
                         && o.DELETED_BY == null)
                .Count();
            return pendingOrderCount;
        }

        public int GetOutOfStockModelCount() 
        {
            // Only PC Models created by admins are considered for this count.
            var outOfStockOrderCount = _context.PcModel
                .Include(pm => pm.CREATED_BY)
                .Where(pm => pm.CREATED_BY.PRIVILEGE_TYPE == "ADMIN"
                          && pm.QUANTITY == 0
                          && pm.PC_MODEL_STATUS != "INA"
                          && pm.DELETED_BY == null)
                .Count();
            return outOfStockOrderCount;
        }

        public int GetMonthlyOrderCount() 
        {
            var monthlyOrderCount = _context.Order
                .Where(o => o.CREATED_DATE.Month == DateTime.Now.Month
                         && o.ORDER_STATUS != "CANCELLED"
                         && o.DELETED_BY == null)
                .Count();
            return monthlyOrderCount;
        }

        public string GetMonthlyRevenue() 
        {
            var monthlyRevenue = _context.Payment
                .Where(p => p.TRANSACTION_DATE.Month == DateTime.Now.Month
                         && p.PAYMENT_STATUS != "INA")
                .Sum(p => p.AMOUNT);
            // Returned as string with 2 decimal places.
            return monthlyRevenue.ToString("0.##");
        }
    }
}
