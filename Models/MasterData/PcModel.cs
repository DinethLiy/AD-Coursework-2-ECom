using eComMaster.Models.MasterData.ConfigItems;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComMaster.Models.MasterData
{
    public class PcModel : UserTrackableAttributes
    {
        [Key]
        public int PC_MODEL_ID { get; set; }

        // PC Series foreign key
        [ForeignKey("PcSeries")]
        public PcSeries PC_SERIES_ID { get; set; }

        public string? PC_MODEL_NAME { get; set; }
        public string? PC_MODEL_DESCRIPTION { get; set; }
        public Decimal MODEL_PRICE { get; set; } = 0.0M; // Model price is the sum of config item prices by default. This attribute overrides that value.
        public int QUANTITY { get; set; }

        // Config Item foreign Keys
        // Casing
        [ForeignKey("Casing")]
        public ConfigCasing? CONFIG_CASING_ID { get; set; }
        // Display
        [ForeignKey("Display")]
        public ConfigDisplay? CONFIG_DISPLAY_ID { get; set; }
        // Graphics
        [ForeignKey("Graphics")]
        public ConfigGraphics? CONFIG_GRAPHICS_ID { get; set; }
        // Memory
        [ForeignKey("Memory")]
        public ConfigMemory? CONFIG_MEMORY_ID { get; set; }
        // Misc
        [ForeignKey("Misc")]
        public ConfigMisc? CONFIG_MISC_ID { get; set; }
        // Ports
        [ForeignKey("Ports")]
        public ConfigPorts? CONFIG_PORTS_ID { get; set; }
        // Power
        [ForeignKey("Power")]
        public ConfigPower? CONFIG_POWER_ID { get; set; }
        // Processor
        [ForeignKey("Processor")]
        public ConfigProcessor? CONFIG_PROCESSOR_ID { get; set; }
        // Storage
        [ForeignKey("Storage")]
        public ConfigStorage? CONFIG_STORAGE_ID { get; set; }

        [Required]
        public string PC_MODEL_STATUS { get; set; } = "ACT";
    }
}
