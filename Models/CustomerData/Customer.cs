using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using eComMaster.Models.Auth;

namespace eComMaster.Models.CustomerData
{
    public class Customer
    {
        [Key]
        public int CUSTOMER_ID { get; set; }

        //User foreign key
        [ForeignKey("AuthUser")]
        public AuthUser USER_ID { get; set; }

        [Required]
        public string NAME { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string GENDER { get; set; }
        [Required]
        public string NIC { get; set; }
        public string? ADDRESS { get; set; }
        public string? CONTACT_NUM { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]
        public Decimal PENALTY_FEE { get; set; } = 0.0M; // Stores the accumulated penalty fee of the customer due to cancelling orders - Added to their next order.
        [Required]
        public string CUSTOMER_STATUS { get; set; } = "ACT";
    }
}
