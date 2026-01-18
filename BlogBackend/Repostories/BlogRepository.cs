using BlogBackend.AppContext;
using BlogBackend.Entities;
using BlogBackend.Repostories.Interfaces;

namespace BlogBackend.Repostories
{
    public class BlogRepository : EFRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
