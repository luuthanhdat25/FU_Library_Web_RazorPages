using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FU_Library_Web.Models
{
	public class Campus
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid CampusID { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(100)]
		public string Address { get; set; }
	}
}
