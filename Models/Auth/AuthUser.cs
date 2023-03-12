using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.Auth
{
    public class AuthUser
    {
        [Key]
        public int USER_ID { get; set; }
        [Required]
        public string USERNAME { get; set; }
        [Required]
        public string PASSWORD { get; set; }
        [Required]
        public string PRIVILEGE_TYPE { get; set; } = "CUSTOMER";
        [Required]
        public string USER_STATUS { get; set; } = "ACT";
    }
}
