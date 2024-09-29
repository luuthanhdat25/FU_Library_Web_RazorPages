using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class Introduction
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid IntroductionId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[MaxLength]
		public string Content { get; set; }
	}
}
