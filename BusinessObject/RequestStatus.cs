using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FU_Library_Web.Models
{
	public class RequestStatus
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid RequestStatusId { get; set; }

		[Required]
		[StringLength(100)]
		public string StatusName { get; set; }
	}
}
