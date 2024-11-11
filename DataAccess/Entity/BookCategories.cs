namespace DataAccess.Entity
{
	public class BookCategories
	{
		[Key]
		public Guid BookCategoryId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }
	}
}
