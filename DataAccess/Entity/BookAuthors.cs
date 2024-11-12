namespace DataAccess.Entity
{
	public class BookAuthors
	{
		[Key]
		public Guid BookAuthorId { get; set; }

		[Required]
		[StringLength(100)]
		public string FullName { get; set; }

		[Required]
		[StringLength(1000)]
		public string Description { get; set; }
	}
}
