using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigPower : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_POWER_ID { get; set; }

        [Required]
        public string POWER_NAME { get; set; }
        public string? POWER_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string POWER_STATUS { get; set; } = "ACT";
    }
}
