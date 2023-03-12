using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.CustomerData
{
    public class Payment
    {
        [Key]
        public int PAYMENT_ID { get; set; }

        // Foreign Key definition is different here due to a migration error
        // Order Foreign Key
        [ForeignKey("Order")]
        public int ORDER_ID { get; set; }
        public Order Order { get; set; }

        [Required]
        public DateTime TRANSACTION_DATE { get; set; }
        [Required]
        public string? PAYMENT_CODE { get; set; }
        [Required]
        public Decimal AMOUNT { get; set; } = 0.0M;
        [Required]
        public string PAYMENT_STATUS { get; set; } = "PENDING";
    }
}
