using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComMaster.Models.MasterData
{
    public class PcSeries : UserTrackableAttributes
    {
        [Key]
        public int PC_SERIES_ID { get; set; }

        //PcCategory foreign key
        [ForeignKey("PcCategory")]
        public PcCategory PC_CATEGORY_ID { get; set; }

        [Required]
        public string PC_SERIES_NAME { get; set; }
        public string? PC_SERIES_DESCRIPTION { get; set; }
        [Required]
        public string PC_SERIES_STATUS { get; set; } = "ACT";
    }
}
