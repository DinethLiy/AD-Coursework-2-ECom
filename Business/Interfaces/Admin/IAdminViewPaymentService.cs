using eComMaster.Models.CustomerData;

namespace eComMaster.Business.Interfaces.Admin
{
    public interface IAdminViewPaymentService
    {
        List<Payment> GetPaymentList();
    }
}
