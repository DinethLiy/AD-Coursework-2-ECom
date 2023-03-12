using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigMisc : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_MISC_ID { get; set; }

        [Required]
        public string MISC_NAME { get; set; }
        public string? MISC_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string MISC_STATUS { get; set; } = "ACT";
    }
}
