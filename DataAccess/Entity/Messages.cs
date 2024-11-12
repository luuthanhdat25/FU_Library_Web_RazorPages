namespace DataAccess.Entity
{
	public class Messages
	{
		[Key]
		public Guid MessageId { get; set; }

		[Required]
		public Guid ChatRoomId { get; set; }
		public ChatRooms ChatRoom { get; set; }
		[Required]
		public Guid FromUserId { get; set; }
		
		public Users FromUser { get; set; }

		[Required]
		public Guid ToUserId { get; set; }

		public Users ToUser { get; set; }

		[Required]
		[MaxLength]
		public string Content { get; set; }

		[Required]
		public DateTime TimeSend { get; set; }
	}
}
