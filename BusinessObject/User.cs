using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FU_Library_Web.Models
{
    public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid UserId { get; set; }

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
		public UserType UserType { get; set; }
		
		[Required]
		public Guid CampusId { get; set; }

		[ForeignKey("CampusId")]
		[Required]
		public Campus Campus { get; set; }
	}

    public enum UserType
    {
        ADMIN,
        MEMBER,
        STAFF
    }
}
