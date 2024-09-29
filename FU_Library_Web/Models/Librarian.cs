using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class Librarian
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid LibrarianID { get; set; }

		[Required]
		public Guid UserID { get; set; }

		[Required]
		[ForeignKey("UserID")]
		public User User { get; set; }
	}
}
