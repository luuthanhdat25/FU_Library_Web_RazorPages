namespace DataAccess.Entity
{
	public class BorrowBooks
	{
		[Key]
		public Guid BorrowBookId { get; set; }
		public DateTime? ReturnDate { get; set; } 

		[Required]
		public DateTime BorrowedDate { get; set; }

		[Required]
		public Guid BookId { get; set; }

		[ForeignKey("BookId")]
		[Required]
		public Books Book { get; set; }

		[Required]
		public Guid UserId { get; set; }

		[ForeignKey("UserId")]
		[Required]
		public Users User { get; set; }

		[Required]
		public Guid RequestStatusId { get; set; }

		[ForeignKey("RequestStatusId")]
		[Required]
		public RequestStatus RequestStatus { get; set; } 
	}
}
