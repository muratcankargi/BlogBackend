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

    }
}
