using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigCasing : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_CASING_ID { get; set; }

        [Required]
        public string CASING_NAME { get; set; }
        public string? CASING_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string CASING_STATUS { get; set; } = "ACT";
    }
}
