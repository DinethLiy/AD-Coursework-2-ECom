using eComMaster.Business.Interfaces.Admin;
using eComMaster.Data;
using eComMaster.Models.CustomerData;
using Microsoft.EntityFrameworkCore;

namespace eComMaster.Business.Services.Admin
{
    public class AdminViewPaymentService : IAdminViewPaymentService
    {
        private readonly ApplicationDbContext _context;

        public AdminViewPaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Payment> GetPaymentList()
        {
            return _context.Payment
                .Include(p => p.Order)
                .ToList();
        }
    }
}
