using FU_Library_Web.Models;
using Microsoft.EntityFrameworkCore;

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
		public DbSet<Librarian> Librarians { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<NewsCategory> NewsCategories { get; set; }
		public DbSet<RequestStatus> RequestStatuses { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserType> UserTypes { get; set; }

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
			modelBuilder.Entity<Message>()
				.HasOne(m => m.ChatRoom)
				.WithMany()
				.HasForeignKey(m => m.ChatRoomID)
				.OnDelete(DeleteBehavior.Restrict); 

			modelBuilder.Entity<Message>()
				.HasOne(m => m.FromUser)
				.WithMany()
				.HasForeignKey(m => m.FromUserId)
				.OnDelete(DeleteBehavior.Restrict); 

			modelBuilder.Entity<Message>()
				.HasOne(m => m.ToUser)
				.WithMany()
				.HasForeignKey(m => m.ToUserId)
				.OnDelete(DeleteBehavior.Restrict); 
		}

	}
}
