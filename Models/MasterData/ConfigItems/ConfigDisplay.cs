using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigDisplay : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_DISPLAY_ID { get; set; }

        [Required]
        public string DISPLAY_NAME { get; set; }
        public string? DISPLAY_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string DISPLAY_STATUS { get; set; } = "ACT";
    }
}
