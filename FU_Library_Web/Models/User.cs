using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid UserID { get; set; }

		[Required]
		[StringLength(100)]
		public string FullName { get; set; }

		[Required]
		[StringLength(100)]
		public string Password { get; set; }

		[Required]
		[StringLength(100)]
		public string Email { get; set; }

		[Required]
		public bool Status { get; set; }
		
		[Required]
		public Guid UserTypeID { get; set; }

		[ForeignKey("UserTypeID")]
		[Required]
		public UserType UserType { get; set; }
		
		[Required]
		public Guid CampusID { get; set; }

		[ForeignKey("CampusID")]
		[Required]
		public Campus Campus { get; set; }
	}
}
