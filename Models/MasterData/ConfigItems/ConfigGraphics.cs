using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigGraphics : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_GRAPHICS_ID { get; set; }

        [Required]
        public string GRAPHICS_NAME { get; set; }
        public string? GRAPHICS_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string GRAPHICS_STATUS { get; set; } = "ACT";
    }
}
