using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class Message
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid MessageID { get; set; }

		[Required]
		public Guid ChatRoomID { get; set; }

		[ForeignKey("ChatRoomID")]
		[Required]
		public ChatRoom ChatRoom { get; set; }


		[Required]
		public Guid FromUserId { get; set; }
		
		[Required]
		[ForeignKey("FromUserId")]
		public User FromUser { get; set; }


		[Required]
		public Guid ToUserId { get; set; }

		[Required]
		[ForeignKey("ToUserId")]
		public User ToUser { get; set; }

		[Required]
		[MaxLength]
		public string Content { get; set; }

		[Required]
		public DateTime TimeSend { get; set; }
	}
}
