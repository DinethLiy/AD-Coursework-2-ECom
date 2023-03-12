using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData.ConfigItems
{
    public class ConfigPorts : UserTrackableAttributes
    {
        [Key]
        public int CONFIG_PORTS_ID { get; set; }

        [Required]
        public string PORTS_NAME { get; set; }
        public string? PORTS_DESCRIPTION { get; set; }
        [Required]
        public Decimal BASE_PRICE { get; set; } = 0.0M;
        [Required]
        public string PORTS_STATUS { get; set; } = "ACT";
    }
}
