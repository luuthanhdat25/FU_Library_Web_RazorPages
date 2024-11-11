namespace DataAccess.Entity
{
	public class RequestStatus
	{
		[Key]
		public Guid RequestStatusId { get; set; }

		[Required]
		[StringLength(100)]
		public string StatusName { get; set; }
	}
}
