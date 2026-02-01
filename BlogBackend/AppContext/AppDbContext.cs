using BlogBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>()
        //        .HasQueryFilter(b => b.IsDeleted == 0);

        //    base.OnModelCreating(modelBuilder);
        //}


    }
}
