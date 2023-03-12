using System.ComponentModel.DataAnnotations;

namespace eComMaster.Models.MasterData
{
    public class PcCategory : UserTrackableAttributes
    {
        [Key]
        public int PC_CATEGORY_ID { get; set; }

        [Required]
        public string PC_CATEGORY_NAME { get;set; }
        public string? PC_CATEGORY_DESCRIPTION { get; set;}
        [Required]
        public string PC_CATEGORY_STATUS { get; set; } = "ACT";
    }
}
