namespace DataAccess.Entity
{
	public class News
	{
		[Key]
		public Guid NewsId { get; set; }

		[Required]
		[StringLength(150)]
		public string Title { get; set; }

		[Required]
		[MaxLength]
		public string Content { get; set; }

		[Required]
		public DateTime PublishDate { get; set; }
	}
}
