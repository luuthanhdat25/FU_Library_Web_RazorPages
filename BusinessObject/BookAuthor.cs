using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class BookAuthor
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid BookAuthorId { get; set; }

		[Required]
		[StringLength(100)]
		public string FullName { get; set; }

		[Required]
		[StringLength(1000)]
		public string Description { get; set; }
	}
}
