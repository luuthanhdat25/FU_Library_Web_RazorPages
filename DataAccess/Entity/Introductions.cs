namespace DataAccess.Entity
{
	public class Introductions
	{
		[Key]
		public Guid IntroductionId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[MaxLength]
		public string Content { get; set; }
	}
}
