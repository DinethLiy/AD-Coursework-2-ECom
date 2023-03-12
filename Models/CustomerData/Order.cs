using eComMaster.Models.MasterData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComMaster.Models.CustomerData
{
    public class Order : UserTrackableAttributes
    {
        [Key]
        public int ORDER_ID { get; set; }

        // Foreign Key definition is different here due to a migration error
        // Pc Model Foreign Key
        [ForeignKey("PcModel")]
        public int PC_MODEL_ID { get; set; }
        public PcModel PcModel { get; set; }

        // Customer Foreign Key
        [ForeignKey("Customer")]
        public int CUSTOMER_ID { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public Decimal ORDER_AMOUNT { get; set; } = 0.0M; // Gets and adds penalty fees from customer, if available.
        [Required]
        public string ORDER_STATUS { get; set; } = "PENDING";
    }
}
