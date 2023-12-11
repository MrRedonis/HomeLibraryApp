using HomeLibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeLibraryApp.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
		public DbSet<Author> Authors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AuthorLibraryItem> AuthorLibraryItems { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublisherLibraryItem> PublisherLibraryItems { get; set; }
        public DbSet<KeywordLibraryItem> KeywordLibraryItems { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
			);

            builder.Entity<Models.Attribute>().HasData(
	            new Models.Attribute { Id = 1, Name = "Liczba stron" },
	            new Models.Attribute { Id = 2, Name = "Numer ISBN" }
            );

			builder.Entity<Models.Attribute>()
                .HasKey(x => x.Id);

            builder.Entity<Image>()
                .HasKey(x => x.Id);

            builder.Entity<AttributeValue>()
	            .HasKey(x => x.Id);

			builder.Entity<Author>()
                .HasKey(x => x.Id);

            builder.Entity<AuthorLibraryItem>()
                .HasKey(x => x.Id);

            builder.Entity<Keyword>()
                .HasKey(x => x.Id);

            builder.Entity<LibraryItem>()
                .HasKey(x => x.Id);

            builder.Entity<Position>()
                .HasKey(x => x.Id);

            builder.Entity<PublisherLibraryItem>()
                .HasKey(x => x.Id);

            builder.Entity<KeywordLibraryItem>()
                .HasKey(x => x.Id);

            builder.Entity<AuthorLibraryItem>()
                .HasOne(x => x.LibraryItem)
                .WithMany(x => x.AuthorLibraryItems)
                .HasForeignKey(x => x.LibraryItemId);

            builder.Entity<AuthorLibraryItem>()
                .HasOne(x => x.Author)
                .WithMany(x => x.AuthorLibraryItems)
                .HasForeignKey(x => x.AuthorId);

            builder.Entity<Position>()
                .HasOne(x => x.LibraryItem)
                .WithMany(x => x.Positions)
                .HasForeignKey(x => x.LibraryItemId);

            builder.Entity<PublisherLibraryItem>()
                .HasOne(x => x.Publisher)
                .WithMany(x => x.PublisherLibraryItems)
                .HasForeignKey(x => x.PublisherId);

            builder.Entity<PublisherLibraryItem>()
                .HasOne(x => x.LibraryItem)
                .WithMany(x => x.PublisherLibraryItems)
                .HasForeignKey(x => x.LibraryItemId);

            builder.Entity<AttributeValue>()
	            .HasOne(x => x.LibraryItem)
	            .WithMany(x => x.AttributeValues)
	            .HasForeignKey(x => x.LibraryItemId);

            builder.Entity<AttributeValue>()
	            .HasOne(x => x.Attribute)
	            .WithMany(x => x.AttributeValues)
	            .HasForeignKey(x => x.AttributeId);

            builder.Entity<LibraryItem>()
                .HasOne(x => x.Image)
                .WithMany(x => x.LibraryItems)
                .HasForeignKey(x => x.ImageId);

            builder.Entity<KeywordLibraryItem>()
                .HasOne(x => x.LibraryItem)
                .WithMany(x => x.KeywordLibraryItems)
                .HasForeignKey(x => x.LibraryItemId);

            builder.Entity<KeywordLibraryItem>()
                .HasOne(x => x.Keyword)
                .WithMany(x => x.KeywordLibraryItems)
                .HasForeignKey(x => x.KeywordId);
        }
    }
}
