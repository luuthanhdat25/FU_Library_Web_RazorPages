namespace DataAccess.Entity
{
    public class Users
	{
		[Key]
		public Guid UserId { get; set; }

		[Required]
		[StringLength(100)]
		public string FullName { get; set; }

		[Required]
		[StringLength(100)]
		public string Password { get; set; }

		[Required]
		[StringLength(100)]
		public string Email { get; set; }

		[Required]
		public bool Status { get; set; }
		
		[Required]
		public UserType UserType { get; set; }
		
		[Required]
		public Guid CampusId { get; set; }

		[ForeignKey("CampusId")]
		[Required]
		public Campuses Campus { get; set; }
	}

    
}
