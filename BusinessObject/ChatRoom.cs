using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FU_Library_Web.Models
{
	public class ChatRoom
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ChatRoomId { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }
	}
}
