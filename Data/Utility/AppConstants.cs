namespace eComMaster.Data.Utility
{
    public class AppConstants
    {
        public enum AdminTypes
        {
            SUPER_ADMIN,
            ADMIN
        }

        public enum MainStatuses
        {
            ACT,
            INA
        }

        public enum OrderStatuses 
        {
            CANCELLED,
            PENDING,
            ASSEMBLING,
            EN_ROUTE,
            COMPLETED
        }
    }
}
