using eComMaster.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComMaster.Models
{
	public class UserTrackableAttributes
	{
		[ForeignKey("CreatedBy")]
		public AuthUser CREATED_BY { get; set; }
		[Required]
		public DateTime CREATED_DATE { get; set; }

		[ForeignKey("ModifiedBy")]
		public AuthUser? MODIFIED_BY { get; set; }
		[Required]
		public DateTime? MODIFIED_DATE { get; set; }

		[ForeignKey("DeletedBy")]
		public AuthUser? DELETED_BY { get; set; }
		[Required]
		public DateTime? DELETED_DATE { get; set; }
	}
}
