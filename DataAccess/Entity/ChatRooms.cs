namespace DataAccess.Entity
{
	public class ChatRooms
	{
		[Key]
		public Guid ChatRoomId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }
	}
}
