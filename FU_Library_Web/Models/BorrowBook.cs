using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class BorrowBook
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid BorrowBookID { get; set; }
		public DateTime? ReturnDate { get; set; } 

		[Required]
		public DateTime BorrowedDate { get; set; }

		[Required]
		public Guid BookID { get; set; }

		[ForeignKey("BookID")]
		[Required]
		public Book Book { get; set; }

		[Required]
		public string StudentID { get; set; }

		[ForeignKey("StudentID")]
		[Required]
		public Student Student { get; set; }

		[Required]
		public Guid RequestStatusID { get; set; }

		[ForeignKey("RequestStatusID")]
		[Required]
		public RequestStatus RequestStatus { get; set; } 
	}
}
