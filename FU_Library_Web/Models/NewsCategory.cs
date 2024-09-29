using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class NewsCategory
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid NewsCategoryId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }
	}
}
