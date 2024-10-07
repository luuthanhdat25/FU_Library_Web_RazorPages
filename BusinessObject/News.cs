using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class News
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid NewsId { get; set; }

		[Required]
		[StringLength(150)]
		public string Title { get; set; }

		[Required]
		[MaxLength]
		public string Content { get; set; }

		[Required]
		public DateTime PublishDate { get; set; }
	}
}
