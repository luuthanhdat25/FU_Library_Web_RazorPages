namespace FU_Library_Web
{
	public class DatabaseContext : DbContext
	{

		public DbSet<Book> Books { get; set; }
		public DbSet<BookAuthor> BookAuthors { get; set; }
		public DbSet<BookCategory> BookCategories { get; set; }
		public DbSet<BorrowBook> BorrowBooks { get; set; }
		public DbSet<Campus> Campuses { get; set; }
		public DbSet<ChatRoom> ChatRooms { get; set; }
		public DbSet<Introduction> Introductions { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }
		public DbSet<User> Users { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

				optionsBuilder.UseSqlServer(connectionString);
			}
		}

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
