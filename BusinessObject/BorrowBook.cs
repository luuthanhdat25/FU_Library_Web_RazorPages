using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class BorrowBook
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid BorrowBookId { get; set; }
		public DateTime? ReturnDate { get; set; } 

		[Required]
		public DateTime BorrowedDate { get; set; }

		[Required]
		public Guid BookId { get; set; }

		[ForeignKey("BookId")]
		[Required]
		public Book Book { get; set; }

		[Required]
		public Guid UserId { get; set; }

		[ForeignKey("UserId")]
		[Required]
		public User User { get; set; }

		[Required]
		public Guid RequestStatusId { get; set; }

		[ForeignKey("RequestStatusId")]
		[Required]
		public RequestStatus RequestStatus { get; set; } 
	}
}
