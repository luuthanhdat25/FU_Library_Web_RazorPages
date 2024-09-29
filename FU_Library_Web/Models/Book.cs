using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FU_Library_Web.Models
{
	public class Book
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid BookID { get; set; }

		[Required]
		[StringLength(150)]
		public string Title { get; set; }

		[Required]
		[StringLength(50)]
		public string ISBN { get; set; }

		[StringLength(50)]
		public string Edition { get; set; }

		[Required]
		[StringLength(255)]
		public string Publisher { get; set; }

		[Required]
		public DateTime PublicationYear { get; set; }

		[Required]
		[MaxLength]
		public string Description { get; set; }

		[Required]
		public bool AvailabilityStatus { get; set; }

		
		[ForeignKey("BookAuthorId")]
		public BookAuthor BookAuthor { get; set; }
		
		[Required]
		public Guid BookCategoryId { get; set; }

		[ForeignKey("BookCategoryId")]
		public BookCategory BookCategory { get; set; }
	}
}
