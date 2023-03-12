using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigMemory : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_MEMORY_ID { get; set; }

        [Required]
        public string MEMORY_NAME { get; set; }
        public string? MEMORY_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string MEMORY_STATUS { get; set; } = "ACT";
    }
}
