namespace DataAccess.Entity
{
	public class Campuses
	{
		[Key]
		public Guid CampusId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(100)]
		public string Address { get; set; }
	}
}
