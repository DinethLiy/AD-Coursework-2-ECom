using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigProcessor : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_PROCESSOR_ID { get; set; }

        [Required]
        public string PROCESSOR_NAME { get; set; }
        public string? PROCESSOR_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string PROCESSOR_STATUS { get; set; } = "ACT";
    }
}
