using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigStorage : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_STORAGE_ID { get; set; }

        [Required]
        public string STORAGE_NAME { get; set; }
        public string? STORAGE_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string STORAGE_STATUS { get; set; } = "ACT";
    }
}
