namespace DataAccess.Entity
{
	public class Books
	{
		[Key]
		public Guid BookId { get; set; }

		[Required]
		[StringLength(150)]
		public string Title { get; set; }

		[Required]
		[StringLength(50)]
		public string ISBN { get; set; }

		[StringLength(50)]
		public string Edition { get; set; }

		[Required]
		[StringLength(255)]
		public string Publisher { get; set; }

		[Required]
		public DateOnly PublicationYear { get; set; }

		[Required]
		[MaxLength]
		public string Description { get; set; }

		[Required]
		public bool AvailabilityStatus { get; set; }
		public string ImageUrl { get; set; }
		public BookAuthors BookAuthor { get; set; }
		
		[Required]
		public Guid BookCategoryId { get; set; }
		public BookCategories BookCategory { get; set; }
	}
}
