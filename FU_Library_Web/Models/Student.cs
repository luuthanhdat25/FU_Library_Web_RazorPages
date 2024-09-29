using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class Student
	{
		[Key]
		[StringLength(8)]
		public string StudentId { get; set; }

		[Required]
		public DateTime DateProvide { get; set; }

		[Required]
		public DateTime ExpirationDate { get; set; }

		[Required]
		public Guid UserID { get; set; }

		[ForeignKey("UserID")]
		[Required]
		public User User { get; set; }
	}
}
