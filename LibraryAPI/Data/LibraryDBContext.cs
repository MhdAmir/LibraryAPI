using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryDBContext(DbContextOptions<LibraryDBContext> options) : DbContext(options)
    {
        public DbSet<Library> LibraryList => Set<Library>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Library>().HasData(
                new Library
                {
                    Id = 1,
                    Title = "Test1",
                    Writer = "Ada1",
                    Publisher = "Computer"
                },
            new Library
            {
                Id = 2,
                Title = "Test2",
                Writer = "Ada2",
                Publisher = "Computer"
            },
            new Library
            {
                Id = 3,
                Title = "Test3",
                Writer = "Ada3",
                Publisher = "Computer"
            },
            new Library
            {
                Id = 4,
                Title = "Test4",
                Writer = "Ada4",
                Publisher = "Computer"
            }
            );
            }
    }
    
}
