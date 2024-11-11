namespace FU_Library_Web
{
	public class DatabaseContext : DbContext
	{
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Books> Books { get; set; }
		public DbSet<BookAuthors> BookAuthors { get; set; }
		public DbSet<BookCategories> BookCategories { get; set; }
		public DbSet<BorrowBooks> BorrowBooks { get; set; }
		public DbSet<Campuses> Campuses { get; set; }
		public DbSet<ChatRooms> ChatRooms { get; set; }
		public DbSet<Introductions> Introductions { get; set; }
		public DbSet<Messages> Messages { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }
		public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining primary keys
            modelBuilder.Entity<Books>().HasKey(b => b.BookId);
            modelBuilder.Entity<BookAuthors>().HasKey(ba => ba.BookAuthorId);
            modelBuilder.Entity<BookCategories>().HasKey(bc => bc.BookCategoryId);
            modelBuilder.Entity<BorrowBooks>().HasKey(bb => bb.BorrowBookId);
            modelBuilder.Entity<Campuses>().HasKey(c => c.CampusId);
            modelBuilder.Entity<ChatRooms>().HasKey(cr => cr.ChatRoomId);
            modelBuilder.Entity<Introductions>().HasKey(i => i.IntroductionId);
            modelBuilder.Entity<Messages>().HasKey(m => m.MessageId);
            modelBuilder.Entity<News>().HasKey(n => n.NewsId);
            modelBuilder.Entity<RequestStatus>().HasKey(rs => rs.RequestStatusId);
            modelBuilder.Entity<Users>().HasKey(u => u.UserId);
        }

    }
}
