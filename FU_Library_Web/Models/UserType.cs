using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class UserType
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid UserTypeID { get; set; }

		[Required]
		[StringLength(100)]
		public string TypeName { get; set; }
	}
}
